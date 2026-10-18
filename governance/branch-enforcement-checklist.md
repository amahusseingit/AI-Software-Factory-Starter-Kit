# Branch enforcement: proposed setup and verification

This checklist is a **proposal**, subordinate to the [branch policy](branch-environment-policy.md) and canonical protocol. It grants no permission to change settings. Complete one instance per repository. Do not copy project-specific deployment assumptions into the generic Factory.

## Read-only baseline first

Record repository/default branch, current refs/SHAs, existing rulesets/classic protections, supported plan/features and current CI/deployment triggers. Check API permission failures separately from unsupported features: neither proves enforcement. Record exact actor capabilities without secret values. Name independent reviewers and human release/merge approvers; do not invent CODEOWNERS identities.

## Exact settings to request approval for

For both main and adopted develop, propose:
- Require pull requests; at least one independent approving review; dismiss stale approvals when new commits arrive; require approval of the latest reviewable push by someone other than its pusher where supported.
- Require resolved conversations and the approved exact status-check names from trusted producers. Require branches up to date, or an approved merge queue with its own tested result and checks.
- Block force pushes and branch deletion; prevent direct pushes and restrict bypass actors. Include administrators in enforcement where supported; record any unavoidable owner/bypass exception honestly.
- Apply CODEOWNERS-required review only after identities and ownership paths are confirmed. An automated reviewer is not a human GitHub approval.
- Protect release tags from overwrite/deletion using a separately approved rule where available. Restrict production deployment and use environment reviewers only after hosting mapping and permissions are known.

Do not require linear history while prescribing merge-based task updates unless the merge strategy is explicitly reconciled. Auto-merge, automatic branch deletion and workflow token write permissions are not part of this proposal.

## Minimal CI proposal, not installed

Proposed workflow triggers: all pull requests to main/develop and pushes to approved task/**, release/**, main and develop refs; no path filters that silently omit a required check. Confirm whether merge_group coverage is needed before enabling a merge queue. Retain other branch triggers only for verified dependencies.

Use read-only `contents: read`, no production environment/secrets, and no `pull_request_target` execution of untrusted branch code. Do not let a PR's self-declared approval/required-check list establish authorization. A trusted job must derive branch/head/base from the event and verified repository policy, and a human must verify approval sources and completeness. Dependency actions/tools need approved pinned versions.

Proposed exact jobs:
1. `factory-docs`: `python3 tools/validate_factory.py`.
2. `factory-gate-tests`: `python3 -m unittest discover -s tools -p 'test_factory*.py' -v`.
3. `factory-branch-contract`: run `python3 tools/validate_branch_record.py --record <reviewed-record.json>` against a record assembled/verified independently of untrusted PR assertions. The branch evaluator is an offline design aid until this trusted producer exists; do not mark it as an enforced required check now.

If using an aggregate check, it must run even when dependencies fail/skip and fail unless every required dependency succeeded. Exercise failed, missing, skipped and outdated-check cases. Observe actual successful job contexts and producer identities on the exact candidate before installing required-check settings. Documentation checks are not application or deployment validation.

## Verification and fallback

After separately approved configuration, read back the settings, verify applicability to both refs and relevant actors, and test rejection paths in an authorized disposable test scenario. Verify an outdated approval, failed/missing check and direct/force push cannot bypass the intended control without changing protected history. Do not perform these write tests without approval.

When protections are unavailable, report the exact limitation. Ask the owner to choose between deferring promotion and a documented weaker owner-controlled manual PR/release checklist. Never call manual process enforced branch protection. Do not upgrade a plan, expose a private repository, or create broader credentials to work around the limitation.
