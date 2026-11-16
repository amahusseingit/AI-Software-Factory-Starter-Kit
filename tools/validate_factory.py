#!/usr/bin/env python3
"""Offline governance record validator; never performs execution or GitHub enforcement.

Usage: python3 tools/validate_factory.py [--root PATH] [--record RECORD.json]
Output is JSON {decision: PASS|BLOCKED, errors: [...]}; exit 0 or 1 respectively.
Record timestamps are ISO 8601 with timezone. All checks are mandatory. Evidence
references identify reviewable artifacts; supplied assertions are not authentication.
Required SOURCE_MANIFEST.json: {"sources": [{"path": "relative/file", "sha256": "..."}]}.
"""
import argparse
from datetime import datetime, timezone
import hashlib
import json
from pathlib import Path
import re
import sys
from urllib.parse import unquote, urlsplit

LIFECYCLE = ["DEFINE", "PLAN", "BUILD", "VERIFY", "REVIEW", "SHIP", "CLOSE"]
STATES = ["PASS", "FAILED", "UNKNOWN", "NOT_RUN", "SCOPE_MISMATCH"]
BINDINGS = ["role", "task", "scope_hash", "plan_hash", "candidate_revision"]
ACTIONS = ["execute", "gate", "close", "planning_append"]


def timestamp(value):
    if not isinstance(value, str):
        raise ValueError("timestamp must be a string")
    result = datetime.fromisoformat(value.replace("Z", "+00:00"))
    if result.tzinfo is None:
        raise ValueError("timestamp must include timezone")
    return result


def validate_record(record, now=None):
    """Return errors, never infer approval or promote a non-PASS check."""
    errors = []
    now = now or datetime.now(timezone.utc)
    if not isinstance(record, dict):
        return ["record must be an object"]
    action = record.get("action")
    if action not in ACTIONS:
        errors.append("unknown action")
    if record.get("phase") not in LIFECYCLE:
        errors.append("unknown lifecycle phase")
    if action == "planning_append":
        for field in ("task", "role", "actor", "scope_hash", "plan_hash", "approval_request_reference"):
            if not isinstance(record.get(field), str) or not record[field].strip():
                errors.append("planning record missing " + field)
        try:
            if timestamp(record.get("time")) > now:
                errors.append("planning record time cannot be in the future")
        except (ValueError, TypeError, OverflowError):
            errors.append("planning record requires timezone-aware time")
        paths = record.get("proposed_paths")
        if not isinstance(paths, list) or not paths or not all(isinstance(path, str) and path.strip() for path in paths):
            errors.append("planning record proposed_paths missing")
        auth = record.get("repository_authorization")
        if not isinstance(auth, dict) or auth.get("explicit") is not True or not record.get("user") or auth.get("approver") != record.get("user") or not isinstance(auth.get("source"), str) or not auth["source"].strip():
            errors.append("planning_append requires original explicit repository user authorization")
        else:
            try:
                if not timestamp(auth.get("approved_at")) <= now < timestamp(auth.get("expires_at")):
                    errors.append("repository authorization is not current")
            except (ValueError, TypeError, OverflowError):
                errors.append("repository authorization requires valid timestamps")
        if record.get("append_only") is not True or record.get("modifies_existing_entries") is not False:
            errors.append("planning_append cannot edit previous entries")
        if record.get("phase") != "PLAN" or record.get("record_only") is not True:
            errors.append("planning_append is limited to PLAN record_only:true")
        if any(record.get(k) for k in ("artifact_execution", "execute", "artifact_changes")):
            errors.append("planning_append cannot authorize artifact execution or changes")
        return errors
    if action == "close" and record.get("phase") != "CLOSE":
        errors.append("close requires CLOSE phase")
    if record.get("phase") == "CLOSE" and action != "close":
        errors.append("CLOSE requires separate close approval")
    for key in BINDINGS + ["executor", "developer", "user"]:
        if not isinstance(record.get(key), str) or not record[key].strip():
            errors.append("missing or invalid " + key)
    if record.get("executor") == record.get("user"):
        errors.append("user approver cannot be executor")

    def current(obj, label, start="observed_at"):
        try:
            begin, end = timestamp(obj.get(start)), timestamp(obj.get("expires_at"))
            if not begin <= now < end:
                errors.append(label + " is stale, expired, or future-dated")
        except (ValueError, TypeError, OverflowError):
            errors.append(label + " requires valid timezone-aware timestamps")

    def binding(obj, keys, label):
        for key in keys:
            if not obj.get(key) or obj.get(key) != record.get(key):
                errors.append(label + " binding mismatch: " + key)

    approval = record.get("approval")
    if not isinstance(approval, dict):
        errors.append("explicit user approval missing")
    else:
        if not isinstance(approval.get("source"), str) or not approval["source"].strip():
            errors.append("approval original user authorization source missing")
        if approval.get("explicit") is not True or approval.get("approver") != record.get("user"):
            errors.append("approval must be explicit and from user")
        if approval.get("approver") == record.get("executor"):
            errors.append("self-signoff forbidden")
        if approval.get("action") != action:
            errors.append("approval action mismatch; closure needs separate close approval")
        binding(approval, BINDINGS, "approval")
        current(approval, "approval", "approved_at")

    checks = record.get("mandatory_checks")
    if not isinstance(checks, list) or not checks:
        errors.append("mandatory checks missing")
        checks = []
    names = set()
    covered_criteria = set()
    retested_findings = set()
    for check in checks:
        if not isinstance(check, dict):
            errors.append("check must be object")
            continue
        name = check.get("name")
        if not isinstance(name, str) or not name or name in names:
            errors.append("check name missing or duplicate")
            name = "invalid"
        names.add(name)
        if check.get("state") != "PASS":
            errors.append(name + " is not PASS (unknown states also block)")
        evidence = check.get("evidence")
        if not isinstance(evidence, dict):
            errors.append(name + " evidence missing")
            continue
        if name == "security":
            retests = evidence.get("retested_findings", [])
            if isinstance(retests, list) and all(isinstance(item, str) and item for item in retests):
                retested_findings.update(retests)
            else:
                errors.append("security retested_findings must be a list of finding IDs")
        binding(evidence, ["scope_hash", "candidate_revision"], name + " evidence")
        current(evidence, name + " evidence")
        if not isinstance(evidence.get("reference"), str) or not evidence["reference"].strip():
            errors.append(name + " evidence reference missing")
        criteria = evidence.get("acceptance_criteria")
        if not isinstance(criteria, list) or not criteria or not all(isinstance(item, str) and item.strip() for item in criteria):
            errors.append(name + " evidence acceptance criteria links missing")
        else:
            covered_criteria.update(criteria)
        reviewer = evidence.get("reviewer")
        if not isinstance(reviewer, str) or not reviewer:
            errors.append(name + " reviewer missing")
        if reviewer == record.get("executor"):
            errors.append(name + " self-signoff forbidden")
        if name in ("qa", "security", "review") and reviewer == record.get("developer"):
            errors.append(name + " must be independent from developer")
    if action in ("gate", "close"):
        for name in ("qa", "security", "review"):
            if name not in names:
                errors.append("required " + name + " check missing")

    expected = record.get("expected_acceptance_criteria")
    if not isinstance(expected, list) or not expected or not all(isinstance(item, str) and item.strip() for item in expected):
        errors.append("expected acceptance criteria must be an explicit nonempty list")
    elif not set(expected).issubset(covered_criteria):
        errors.append("evidence does not cover all expected acceptance criteria")

    findings = record.get("security_findings")
    if not isinstance(findings, list):
        errors.append("security_findings must be an explicit list")
        findings = []
    finding_ids = set()
    for finding in findings:
        if not isinstance(finding, dict):
            errors.append("invalid security finding")
            continue
        finding_id = finding.get("id")
        if not isinstance(finding_id, str) or not finding_id.strip() or finding_id in finding_ids:
            errors.append("security finding ID must be nonempty and unique")
        else:
            finding_ids.add(finding_id)
        severity, status = finding.get("severity"), finding.get("status")
        if severity not in ("CRITICAL", "HIGH", "MEDIUM", "LOW") or status not in ("OPEN", "RESOLVED"):
            errors.append("unknown security severity/status")
            continue
        # Resolution must be backed by the current independent security check.
        if status == "RESOLVED":
            if not isinstance(finding.get("id"), str) or finding["id"] not in retested_findings:
                errors.append("resolved finding requires finding-specific current security retest evidence")
            continue
        if severity == "CRITICAL":
            errors.append("open Critical finding always blocks")
        elif severity == "HIGH":
            exception = finding.get("exception")
            if not isinstance(exception, dict):
                errors.append("open High finding requires bounded exception")
                continue
            for field in ("rationale", "evidence", "remediation_owner", "owner_approval_source", "security_owner_approval_source"):
                if not isinstance(exception.get(field), str) or not exception[field].strip():
                    errors.append("High exception missing " + field)
            if exception.get("policy_permits") is not True:
                errors.append("High exception requires organizational policy permission")
            try:
                if timestamp(exception.get("remediation_deadline")) <= now:
                    errors.append("High remediation deadline is overdue")
            except (ValueError, TypeError, OverflowError):
                errors.append("High remediation deadline missing or invalid")
            binding(exception, ["scope_hash", "candidate_revision"], "High exception")
            current(exception, "High exception", "approved_at")
            if not finding.get("id") or exception.get("finding_id") != finding.get("id"):
                errors.append("exception must bind one finding")
            if not isinstance(exception.get("compensating_controls"), str) or not exception["compensating_controls"].strip():
                errors.append("exception compensating controls missing")
            for key in ("owner", "security_owner"):
                if not record.get(key) or exception.get(key + "_approver") != record.get(key) or exception.get(key + "_approved") is not True:
                    errors.append("High exception requires explicit " + key + " approval")
                if record.get(key) in (record.get("executor"), record.get("developer")):
                    errors.append("exception owner self-signoff forbidden")
            if record.get("owner") == record.get("security_owner"):
                errors.append("owner and security owner must be independent")
        elif severity in ("MEDIUM", "LOW"):
            for field in ("owner", "disposition", "evidence"):
                if not isinstance(finding.get(field), str) or not finding[field].strip():
                    errors.append(severity + " finding missing " + field)
            try:
                if timestamp(finding.get("due_date")) <= now:
                    errors.append(severity + " finding due date is overdue")
            except (ValueError, TypeError, OverflowError):
                errors.append(severity + " finding due date missing or invalid")
    return errors


def inside(root, relative):
    path = (root / relative).resolve()
    if not path.is_relative_to(root.resolve()):
        raise ValueError("path escapes repository")
    return path


def validate_repository(root):
    errors = []
    contract_path = root / "governance/gate-contract.json"
    try:
        contract = json.loads(contract_path.read_text())
        for key, value in (("lifecycle", LIFECYCLE), ("decisions", ["PASS", "BLOCKED"]), ("check_states", STATES), ("actions", ACTIONS), ("binding_fields", BINDINGS), ("required_gate_checks", ["qa", "security", "review"]), ("security_severities", ["CRITICAL", "HIGH", "MEDIUM", "LOW"]), ("source_manifest", "SOURCE_MANIFEST.json")):
            if contract.get(key) != value:
                errors.append("canonical contract mismatch: " + key)
        canonical = ["governance/protocol.md", "governance/security-policy.md"]
        pointers = ["AGENTS.md", "ORCHESTRATOR.md", "governance/approval-gates.md"]
        if contract.get("canonical_documents") != canonical or contract.get("pointer_documents") != pointers:
            errors.append("canonical document/pointer list mismatch")
        for name in canonical:
            if not (root / name).is_file():
                errors.append("missing canonical document: " + name)
        for name in pointers:
            body = (root / name).read_text()
            if "protocol.md" not in body or "security-policy.md" not in body:
                errors.append("missing canonical pointers: " + name)
        for doc in root.rglob("*.md"):
            if ".git" in doc.parts:
                continue
            body = re.sub(r"```.*?```", "", doc.read_text(), flags=re.S)
            # Validate local inline Markdown links; external links and anchors are exempt.
            for target in re.findall(r"\[[^\]]*\]\(([^\s)]+)(?:\s+[^)]*)?\)", body):
                url = urlsplit(target.strip("<>"))
                if url.scheme or url.netloc or not url.path:
                    continue
                path = (doc.parent / unquote(url.path)).resolve()
                if not path.is_relative_to(root.resolve()) or not path.exists():
                    errors.append(f"broken local link in {doc.relative_to(root)}: {target}")
        manifest = root / "SOURCE_MANIFEST.json"
        if not manifest.exists():
            errors.append("required SOURCE_MANIFEST.json missing")
        else:
            data = json.loads(manifest.read_text())
            sources = data.get("sources")
            if not isinstance(sources, list) or not sources:
                errors.append("source manifest sources must be nonempty list")
            else:
                seen = set()
                for source in sources:
                    name = source["path"]
                    if name in seen:
                        errors.append("duplicate manifest source: " + name)
                    seen.add(name)
                    actual = hashlib.sha256(inside(root, name).read_bytes()).hexdigest()
                    if actual != source["sha256"]:
                        errors.append("source manifest hash mismatch: " + name)
    except (OSError, ValueError, TypeError, KeyError, AttributeError) as exc:
        errors.append("invalid repository/contract/manifest: " + str(exc))
    return errors


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--root", type=Path, default=Path(__file__).resolve().parents[1])
    parser.add_argument("--record", type=Path)
    args = parser.parse_args()
    try:
        errors = validate_record(json.loads(args.record.read_text())) if args.record else validate_repository(args.root.resolve())
    except (OSError, ValueError, TypeError) as exc:
        errors = ["invalid input: " + str(exc)]
    print(json.dumps({"decision": "BLOCKED" if errors else "PASS", "errors": errors}, indent=2))
    return bool(errors)


if __name__ == "__main__":
    sys.exit(main())
