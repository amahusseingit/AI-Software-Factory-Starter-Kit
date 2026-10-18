# Branch and promotion record

TEMPLATE ONLY, NOT EVIDENCE. Follow the [branch policy](../governance/branch-environment-policy.md) and [canonical protocol](../governance/protocol.md). Blank fields block; this template authorizes no action.

- Repository URL and verified remote:
- Task ID, bounded scope, role plan/revision and original user approval source:
- Mode: task / release / hotfix / reconcile:
- Source branch, approved base ref/full SHA and output full SHA:
- Target branch and observed full target SHA:
- Tested integration/merge full SHA and verification method:
- Exact required check names/producers, result, tested SHA and raw evidence links:
- Independent QA/reviewer identities and current approval/evidence links:
- Explicit merge authorization for source SHA/target and approval source:
- Bootstrap exception: exact task/branch/base/target, approval source, expiry (otherwise none):
- Release: frozen candidate SHA, immutable artifact digest, staging environment/configuration delta, QA and rollback evidence, release/deployment action approval:
- Hotfix: exact production tag, resolved SHA, observed production digest/provenance; check no unrelated main changes; reconciliation task/PR and release references:
- Branch lifecycle: retained evidence, merge/abandonment result, authorized retention/deletion policy:
- Unknown/blocked items and owner:

## Offline check input

The [reference validator](../tools/validate_branch_record.py) accepts JSON with `mode`, `task_id`, `source_branch`, `base_ref`, `base_sha`, `approved_base_sha`, `head_sha`, `target_branch`, `target_sha`, `tested_target_sha`, `tested_merge_sha`, `approved_head_sha`, `required_checks`, `checks`, `approval_reference`, and `review_reference`. Each check has `name`, `state` (`PASS` only), `revision` (tested_merge_sha) and `evidence`. The approved_base_sha must equal base_sha, tested_target_sha must equal target_sha, and approved_head_sha must equal head_sha. These assertions must be authenticated independently. All SHAs are full 40-character lowercase SHA-1 identifiers for this GitHub reference implementation.

Additional fields: release requires `release_candidate_sha` equal to head_sha; hotfix requires `production_tag`, `production_sha` equal to base_sha and `production_evidence`; reconcile requires `hotfix_sha` and `hotfix_reference`. This minimal structural check does not authenticate refs, artifact/deployment state, independence, task uniqueness, evidence content or approvals. The complete human record above is still mandatory. Bootstrap/legacy exceptions are deliberately not auto-passed: review them manually and record BLOCKED/unsupported in this validator rather than weaken its default topology.
