"""Synthetic fixtures test offline contracts, not a deployed enforcement system."""
import copy
from datetime import datetime, timezone
import hashlib
import json
from pathlib import Path
import tempfile
import unittest

from validate_factory import BINDINGS, validate_record, validate_repository

NOW = datetime(2026, 10, 18, tzinfo=timezone.utc)
START = "2026-10-17T00:00:00Z"
END = "2026-10-19T00:00:00Z"


def fixture():
    record = dict(action="gate", phase="REVIEW", role="reviewer", task="T-1",
                  scope_hash="scope-1", plan_hash="plan-1", candidate_revision="rev-1",
                  executor="orchestrator", developer="developer", user="user",
                  owner="owner", security_owner="security-owner", security_findings=[], expected_acceptance_criteria=["AC-1"])
    record["approval"] = {key: record[key] for key in BINDINGS}
    record["approval"].update(action="gate", explicit=True, source="user-message:approved-123", approver="user", approved_at=START, expires_at=END)
    record["mandatory_checks"] = [dict(name=name, state="PASS", evidence=dict(
        scope_hash="scope-1", candidate_revision="rev-1", reviewer=name + "-reviewer",
        observed_at=START, expires_at=END, acceptance_criteria=["AC-1"], reference="evidence/" + name + ".json")) for name in ("qa", "security", "review")]
    return record


class GateTests(unittest.TestCase):
    def setUp(self):
        self.record = fixture()

    def blocked(self):
        self.assertTrue(validate_record(self.record, NOW))

    def test_positive_gate(self):
        self.assertEqual([], validate_record(self.record, NOW))

    def test_missing_approval(self):
        del self.record["approval"]
        self.blocked()

    def test_expired_approval(self):
        self.record["approval"]["expires_at"] = START
        self.blocked()

    def test_future_approval(self):
        self.record["approval"]["approved_at"] = END
        self.blocked()

    def test_approval_wrong_action_or_identity(self):
        for key, value in (("action", "execute"), ("approver", "stranger"), ("explicit", False)):
            with self.subTest(key=key):
                self.record = fixture()
                self.record["approval"][key] = value
                self.blocked()

    def test_each_approval_binding(self):
        for key in BINDINGS:
            with self.subTest(key=key):
                self.record = fixture()
                self.record[key] = "changed"
                self.blocked()

    def test_every_nonpass_state(self):
        for state in ("FAILED", "UNKNOWN", "NOT_RUN", "SCOPE_MISMATCH", "SKIPPED", None):
            with self.subTest(state=state):
                self.record = fixture()
                self.record["mandatory_checks"][0]["state"] = state
                self.blocked()

    def test_empty_checks(self):
        self.record["mandatory_checks"] = []
        self.blocked()

    def test_missing_required_check(self):
        self.record["mandatory_checks"].pop()
        self.blocked()

    def test_duplicate_checks(self):
        self.record["mandatory_checks"].append(copy.deepcopy(self.record["mandatory_checks"][0]))
        self.blocked()

    def test_missing_evidence(self):
        del self.record["mandatory_checks"][0]["evidence"]
        self.blocked()

    def test_stale_evidence(self):
        self.record["mandatory_checks"][0]["evidence"]["expires_at"] = START
        self.blocked()

    def test_mismatched_evidence(self):
        for key in ("scope_hash", "candidate_revision"):
            with self.subTest(key=key):
                self.record = fixture()
                self.record["mandatory_checks"][0]["evidence"][key] = "other"
                self.blocked()

    def test_self_signoff(self):
        self.record["executor"] = "user"
        self.blocked()

    def test_qa_and_security_independence(self):
        for index in (0, 1, 2):
            for identity in ("developer", "orchestrator"):
                with self.subTest(index=index, identity=identity):
                    self.record = fixture()
                    self.record["mandatory_checks"][index]["evidence"]["reviewer"] = identity
                    self.blocked()

    def test_critical_never_exception(self):
        self.record["security_findings"] = [dict(id="C1", severity="CRITICAL", status="OPEN", exception={"approved": True})]
        self.blocked()

    def high_exception(self):
        self.record["security_findings"] = [dict(id="H1", severity="HIGH", status="OPEN", exception=dict(
            finding_id="H1", scope_hash="scope-1", candidate_revision="rev-1", approved_at=START,
            expires_at=END, owner_approver="owner", owner_approved=True,
            security_owner_approver="security-owner", security_owner_approved=True,
            compensating_controls="Disable exposed endpoint and alert on attempts",
            rationale="Mitigation bounds exposure", evidence="evidence/exception-H1.json",
            remediation_owner="remediation-owner", remediation_deadline=END,
            owner_approval_source="message:owner-1", security_owner_approval_source="message:security-1",
            policy_permits=True))]

    def test_high_without_exception(self):
        self.record["security_findings"] = [dict(id="H1", severity="HIGH", status="OPEN")]
        self.blocked()

    def test_high_bounded_exception(self):
        self.high_exception()
        self.assertEqual([], validate_record(self.record, NOW))

    def test_invalid_high_exceptions(self):
        for key, value in (("finding_id", "*"), ("scope_hash", "*"), ("candidate_revision", "old"),
                           ("expires_at", START), ("compensating_controls", ""),
                           ("owner_approved", False), ("security_owner_approved", False),
                           ("security_owner_approver", "owner"), ("policy_permits", False),
                           ("owner_approval_source", ""), ("remediation_deadline", START)):
            with self.subTest(key=key):
                self.record = fixture()
                self.high_exception()
                self.record["security_findings"][0]["exception"][key] = value
                self.blocked()

    def test_medium_and_low_require_disposition(self):
        for severity in ("MEDIUM", "LOW"):
            self.record = fixture()
            self.record["security_findings"] = [dict(id="M1", severity=severity, status="OPEN")]
            self.blocked()
            self.record["security_findings"][0].update(owner="owner", due_date=END, disposition="Tracked remediation", evidence="evidence/M1.json")
            self.assertEqual([], validate_record(self.record, NOW))

    def test_resolved_finding_requires_specific_retest(self):
        self.record["security_findings"] = [dict(id="C1", severity="CRITICAL", status="RESOLVED")]
        self.blocked()
        self.record["mandatory_checks"][1]["evidence"]["retested_findings"] = ["other"]
        self.blocked()
        self.record["mandatory_checks"][1]["evidence"]["retested_findings"] = ["C1"]
        self.assertEqual([], validate_record(self.record, NOW))

    def test_unknown_security_blocks(self):
        self.record["security_findings"] = [dict(severity="Unknown", status="OPEN")]
        self.blocked()

    def test_missing_security_inventory(self):
        del self.record["security_findings"]
        self.blocked()

    def test_close_requires_separate_approval(self):
        self.record.update(action="close", phase="CLOSE")
        self.blocked()

    def test_close_with_current_independent_evidence(self):
        self.record.update(action="close", phase="CLOSE")
        self.record["approval"]["action"] = "close"
        self.assertEqual([], validate_record(self.record, NOW))
        self.record["mandatory_checks"][1]["evidence"]["expires_at"] = START
        self.blocked()

    def test_close_cannot_be_execute(self):
        self.record.update(action="execute", phase="CLOSE")
        self.record["approval"]["action"] = "execute"
        self.blocked()

    def test_planning_append_record_only(self):
        self.record = dict(action="planning_append", phase="PLAN", record_only=True,
                           user="user", append_only=True, modifies_existing_entries=False,
                           task="T-1", role="planner", actor="planner-agent", time=START,
                           scope_hash="scope-1", plan_hash="plan-1", proposed_paths=["governance/log.md"],
                           approval_request_reference="message:request-1",
                           repository_authorization=dict(explicit=True, approver="user", source="user-message:repo-1",
                                                         approved_at=START, expires_at=END))
        self.assertEqual([], validate_record(self.record, NOW))
        self.record["artifact_execution"] = True
        self.blocked()

    def test_planning_append_requires_all_record_fields(self):
        valid = dict(action="planning_append", phase="PLAN", record_only=True, user="user",
                     append_only=True, modifies_existing_entries=False, task="T-1", role="planner",
                     actor="planner-agent", time=START, scope_hash="scope-1", plan_hash="plan-1",
                     proposed_paths=["log.md"], approval_request_reference="message:request",
                     repository_authorization=dict(explicit=True, approver="user", source="message:repo",
                                                   approved_at=START, expires_at=END))
        self.assertEqual([], validate_record(valid, NOW))
        for field in ("task", "role", "actor", "time", "scope_hash", "plan_hash", "proposed_paths", "approval_request_reference"):
            with self.subTest(field=field):
                self.record = copy.deepcopy(valid)
                del self.record[field]
                self.blocked()
        self.record = copy.deepcopy(valid)
        self.record["repository_authorization"]["expires_at"] = START
        self.blocked()

    def test_planning_append_wrong_phase(self):
        self.record = dict(action="planning_append", phase="BUILD", record_only=True)
        self.blocked()

    def test_malformed_inputs_fail_closed(self):
        for value in (None, [], {}, {"action": "gate", "mandatory_checks": [None]}):
            with self.subTest(value=value):
                self.assertTrue(validate_record(value, NOW))

    def test_incomplete_acceptance_coverage(self):
        self.record["expected_acceptance_criteria"].append("AC-2")
        self.blocked()

    def test_expected_acceptance_criteria_missing(self):
        del self.record["expected_acceptance_criteria"]
        self.blocked()

    def test_review_required_for_close(self):
        self.record.update(action="close", phase="CLOSE")
        self.record["approval"]["action"] = "close"
        self.record["mandatory_checks"].pop()
        self.blocked()

    def test_missing_original_approval_source(self):
        del self.record["approval"]["source"]
        self.blocked()

    def test_evidence_without_acceptance_criteria(self):
        del self.record["mandatory_checks"][0]["evidence"]["acceptance_criteria"]
        self.blocked()

    def test_planning_append_needs_repository_authorization(self):
        self.record = dict(action="planning_append", phase="PLAN", record_only=True,
                           append_only=True, modifies_existing_entries=False)
        self.blocked()

    def test_planning_append_cannot_edit_history(self):
        self.record = dict(action="planning_append", phase="PLAN", record_only=True,
                           user="user", append_only=True, modifies_existing_entries=True,
                           repository_authorization=dict(explicit=True, approver="user", source="message:1",
                                                         approved_at=START, expires_at=END))
        self.blocked()

    def test_timezone_required(self):
        self.record["approval"]["expires_at"] = "2026-10-19T00:00:00"
        self.blocked()


class RepositoryTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        (self.root / "governance").mkdir()
        contract = Path(__file__).resolve().parents[1] / "governance/gate-contract.json"
        (self.root / "governance/gate-contract.json").write_text(contract.read_text())
        for name in ("protocol.md", "security-policy.md"):
            (self.root / "governance" / name).write_text("# Canonical\n")
        for name in ("AGENTS.md", "ORCHESTRATOR.md", "governance/approval-gates.md"):
            (self.root / name).write_text("See protocol.md and security-policy.md\n")

        self.source = self.root / "source.txt"
        self.source.write_text("original")
        (self.root / "SOURCE_MANIFEST.json").write_text(json.dumps({"sources": [{"path": "source.txt", "sha256": hashlib.sha256(self.source.read_bytes()).hexdigest()}]}))

    def test_repository_with_manifest(self):
        self.assertEqual([], validate_repository(self.root))

    def test_repository_without_manifest(self):
        (self.root / "SOURCE_MANIFEST.json").unlink()
        self.assertTrue(validate_repository(self.root))

    def test_broken_local_link(self):
        (self.root / "link.md").write_text("[missing](missing.md)")
        self.assertTrue(validate_repository(self.root))

    def test_missing_pointer(self):
        (self.root / "AGENTS.md").write_text("Nothing")
        self.assertTrue(validate_repository(self.root))

    def test_contract_drift(self):
        path = self.root / "governance/gate-contract.json"
        data = json.loads(path.read_text())
        data["decisions"].append("CONDITIONAL")
        path.write_text(json.dumps(data))
        self.assertTrue(validate_repository(self.root))

    def test_manifest_hashes(self):
        source = self.root / "source.txt"
        source.write_text("original")
        manifest = {"sources": [{"path": "source.txt", "sha256": hashlib.sha256(source.read_bytes()).hexdigest()}]}
        (self.root / "SOURCE_MANIFEST.json").write_text(json.dumps(manifest))
        self.assertEqual([], validate_repository(self.root))
        source.write_text("changed")
        self.assertTrue(validate_repository(self.root))


if __name__ == "__main__":
    unittest.main()
