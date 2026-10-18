"""Synthetic branch-record tests; these are not real approvals or GitHub checks."""
import copy
import unittest

from validate_branch_record import validate_branch_record


def fixture(mode="task"):
    record = dict(mode=mode, task_id="fac-42", source_branch="task/fac-42-fix-docs",
                  base_ref="develop", base_sha="a" * 40, head_sha="b" * 40,
                  target_branch="develop", target_sha="c" * 40, tested_merge_sha="d" * 40,
                  approved_head_sha="b" * 40, approved_base_sha="a" * 40, tested_target_sha="c" * 40, approval_reference="synthetic:user-approval",
                  review_reference="synthetic:independent-review", required_checks=["docs", "tests"],
                  checks=[dict(name=n, state="PASS", revision="d" * 40, evidence="synthetic:" + n)
                          for n in ("docs", "tests")])
    if mode == "release":
        record.update(source_branch="develop", target_branch="main", release_candidate_sha="b" * 40)
    if mode == "hotfix":
        record.update(source_branch="task/fac-42-hotfix-docs", base_ref="refs/tags/v1.0.0",
                      production_tag="refs/tags/v1.0.0", production_sha="a" * 40,
                      production_evidence="synthetic:observed-release", target_branch="main")
    if mode == "reconcile":
        record.update(source_branch="task/fac-42-reconcile-docs", hotfix_sha="e" * 40,
                      hotfix_reference="synthetic:release-pr")
    return record


class BranchTests(unittest.TestCase):
    def test_supported_paths(self):
        for mode in ("task", "release", "hotfix", "reconcile"):
            with self.subTest(mode=mode):
                self.assertEqual([], validate_branch_record(fixture(mode)))

    def test_bad_names(self):
        for branch in ("main", "develop", "task/fix-docs", "task/fac-41-fix-docs",
                       "task/fac-42-Fix", "task/fac-42-", "task/fac-42-x/y", "task/fac-42-x--y", None):
            with self.subTest(branch=branch):
                r = fixture(); r["source_branch"] = branch
                self.assertTrue(validate_branch_record(r))

    def test_invalid_task_ids(self):
        for task in ("", None, "fac", "FAC-42", "fac-42\n", 42, []):
            r = fixture(); r["task_id"] = task
            self.assertTrue(validate_branch_record(r))

    def test_no_direct_main_or_unknown_base(self):
        for field, value in (("target_branch", "main"), ("target_branch", "staging"), ("base_ref", "main")):
            r = fixture(); r[field] = value
            self.assertTrue(validate_branch_record(r))

    def test_release_paths_and_pinned_head(self):
        for field, value in (("source_branch", "task/fac-42-docs"), ("target_branch", "develop"),
                             ("base_ref", "main"), ("release_candidate_sha", "a" * 40)):
            r = fixture("release"); r[field] = value
            self.assertTrue(validate_branch_record(r))

    def test_hotfix_requires_exact_production(self):
        for field, value in (("base_ref", "main"), ("production_sha", "f" * 40),
                             ("production_tag", ""), ("production_tag", "refs/tags/"),
                             ("production_evidence", ""), ("target_branch", "develop"),
                             ("source_branch", "task/fac-42-fix")):
            r = fixture("hotfix"); r[field] = value
            self.assertTrue(validate_branch_record(r))

    def test_reconciliation_requires_source_name_and_reference(self):
        for field, value in (("source_branch", "main"), ("source_branch", "task/fac-42-hotfix-docs"),
                             ("base_ref", "main"), ("hotfix_sha", None), ("hotfix_reference", "")):
            r = fixture("reconcile"); r[field] = value
            self.assertTrue(validate_branch_record(r))

    def test_malformed_sha(self):
        for field in ("base_sha", "head_sha", "target_sha", "tested_merge_sha", "approved_head_sha", "approved_base_sha", "tested_target_sha"):
            for value in (None, "a" * 7, "g" * 40, "a" * 40 + "\n", 1):
                r = fixture(); r[field] = value
                self.assertTrue(validate_branch_record(r))

    def test_changed_head_invalidates_approval(self):
        r = fixture(); r["head_sha"] = "e" * 40
        self.assertTrue(validate_branch_record(r))

    def test_changed_base_invalidates_approval(self):
        r = fixture(); r["base_sha"] = "e" * 40
        self.assertTrue(validate_branch_record(r))

    def test_changed_target_invalidates_merge_evidence(self):
        r = fixture(); r["target_sha"] = "e" * 40
        self.assertTrue(validate_branch_record(r))

    def test_changed_merge_invalidates_checks(self):
        r = fixture(); r["tested_merge_sha"] = "e" * 40
        self.assertTrue(validate_branch_record(r))

    def test_every_nonpass_check(self):
        for state in ("FAILED", "UNKNOWN", "NOT_RUN", "SKIPPED", "SCOPE_MISMATCH", "CANCELLED", "NEUTRAL", "PENDING", None):
            r = fixture(); r["checks"][0]["state"] = state
            self.assertTrue(validate_branch_record(r))

    def test_missing_check_or_evidence(self):
        for change in (lambda r: r["checks"].pop(), lambda r: r["checks"][0].update(evidence=""),
                       lambda r: r["checks"].append(copy.deepcopy(r["checks"][0]))):
            r = fixture(); change(r)
            self.assertTrue(validate_branch_record(r))

    def test_invalid_required_checks(self):
        for value in ([], None, ["docs", "docs"], [None], [[]], "docs"):
            r = fixture(); r["required_checks"] = value
            self.assertTrue(validate_branch_record(r))

    def test_missing_approval_review(self):
        for field in ("approval_reference", "review_reference"):
            r = fixture(); del r[field]
            self.assertTrue(validate_branch_record(r))

    def test_malformed_records_and_mode(self):
        for value in (None, [], "record", {}, {"mode": []}):
            self.assertTrue(validate_branch_record(value))


if __name__ == "__main__":
    unittest.main()
