#!/usr/bin/env python3
"""Offline structural branch record check; no GitHub calls or approval authentication.

This intentionally does not auto-pass bootstrap exceptions or frozen release
snapshot branches. Such paths require separate review, not guessed permission.
"""
import argparse
import json
from pathlib import Path
import re

SHA = re.compile(r"[0-9a-f]{40}\Z")
TASK_ID = re.compile(r"[a-z][a-z0-9]*-[0-9]+\Z")
SLUG = re.compile(r"[a-z0-9]+(?:-[a-z0-9]+)*\Z")


def nonempty(value):
    return isinstance(value, str) and bool(value.strip())


def validate_branch_record(record):
    """Return all structural errors. User assertions never establish authorization."""
    if not isinstance(record, dict):
        return ["record must be an object"]
    errors = []
    mode = record.get("mode")
    if mode not in ("task", "release", "hotfix", "reconcile"):
        errors.append("unsupported promotion mode")
    task_id = record.get("task_id")
    if not isinstance(task_id, str) or not TASK_ID.fullmatch(task_id):
        errors.append("task_id must be a lowercase unique registry ID such as fac-42")
    for field in ("base_sha", "head_sha", "target_sha", "tested_merge_sha", "approved_head_sha", "approved_base_sha", "tested_target_sha"):
        if not isinstance(record.get(field), str) or not SHA.fullmatch(record[field]):
            errors.append("missing or invalid full SHA: " + field)
    if record.get("approved_head_sha") != record.get("head_sha"):
        errors.append("approval is not bound to current head")
    if record.get("approved_base_sha") != record.get("base_sha"):
        errors.append("approval is not bound to current base")
    if record.get("tested_target_sha") != record.get("target_sha"):
        errors.append("tested merge is not bound to current target")
    for field in ("approval_reference", "review_reference"):
        if not nonempty(record.get(field)):
            errors.append("missing " + field)
    source = record.get("source_branch")
    target = record.get("target_branch")
    base_ref = record.get("base_ref")
    if mode in ("task", "hotfix", "reconcile"):
        prefix = "task/" + str(task_id) + "-"
        slug = source[len(prefix):] if isinstance(source, str) and source.startswith(prefix) else ""
        if not SLUG.fullmatch(slug):
            errors.append("source must be task/<task-id>-<lowercase-slug>")
        if mode == "hotfix" and not slug.startswith("hotfix-"):
            errors.append("hotfix slug must start hotfix-")
        if mode == "reconcile" and not slug.startswith("reconcile-"):
            errors.append("reconcile slug must start reconcile-")
    if mode in ("task", "reconcile"):
        if base_ref != "develop" or target != "develop":
            errors.append("normal/reconcile task must start from and target approved develop")
    if mode == "release":
        if source != "develop" or base_ref != "develop" or target != "main":
            errors.append("release must promote pinned develop to main")
        if record.get("release_candidate_sha") != record.get("head_sha"):
            errors.append("release candidate is not pinned to current head")
    if mode == "hotfix":
        tag = record.get("production_tag")
        if not nonempty(tag) or not tag.startswith("refs/tags/") or len(tag) <= len("refs/tags/"):
            errors.append("hotfix needs exact refs/tags/ production tag")
        if base_ref != tag or record.get("production_sha") != record.get("base_sha"):
            errors.append("hotfix base must match resolved production tag SHA")
        if not nonempty(record.get("production_evidence")):
            errors.append("missing verified production provenance reference")
        if target != "main":
            errors.append("hotfix must target main")
    if mode == "reconcile":
        if not isinstance(record.get("hotfix_sha"), str) or not SHA.fullmatch(record["hotfix_sha"]):
            errors.append("missing original hotfix SHA")
        if not nonempty(record.get("hotfix_reference")):
            errors.append("missing hotfix release/reconciliation reference")
    required = record.get("required_checks")
    if not isinstance(required, list) or not required or not all(nonempty(x) for x in required):
        errors.append("required_checks must be a nonempty list of exact check names")
        required = []
    elif len(set(required)) != len(required):
        errors.append("duplicate required check names")
    checks = record.get("checks")
    if not isinstance(checks, list):
        errors.append("checks must be a list")
        checks = []
    for name in required:
        matches = [c for c in checks if isinstance(c, dict) and c.get("name") == name]
        if len(matches) != 1:
            errors.append("missing or duplicate required check: " + name)
            continue
        check = matches[0]
        if check.get("state") != "PASS":
            errors.append("required check did not PASS: " + name)
        if check.get("revision") != record.get("tested_merge_sha"):
            errors.append("required check is not bound to tested merge: " + name)
        if not nonempty(check.get("evidence")):
            errors.append("missing check evidence: " + name)
    return errors


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--record", required=True, type=Path)
    args = parser.parse_args()
    try:
        errors = validate_branch_record(json.loads(args.record.read_text(encoding="utf-8")))
    except (OSError, ValueError, TypeError, RecursionError) as exc:
        errors = ["unreadable or malformed record: " + str(exc)]
    print(json.dumps({"decision": "BLOCKED" if errors else "PASS", "errors": errors}))
    return int(bool(errors))


if __name__ == "__main__":
    raise SystemExit(main())
