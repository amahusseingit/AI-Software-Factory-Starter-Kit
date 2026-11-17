# FACT-005 approved developer execution

Task ID: fact-005. Role: developer, with coordinator recording execution and publication evidence. Input base: develop `7ed5858e44bafbabf083022397ef97a4bb827dd2`. Branch: `task/fact-005-integrate-dotnet-runtime`. Approved readiness content source: `685cf8784fff62b862a13552f02c7773d3115dae`, carried by genuine cherry-pick `e7f1a1f8410e9a384ebbf683a88d4e485c7a85d5`; no synthetic ancestry or main/develop writes.

## Actual authorization

The current authenticated conversation supplies two distinct approvals: user `Approved` following the exact specification/architecture decision request for readiness commit 685cf8784fff62b862a13552f02c7773d3115dae; then user `Go ahead` following the explicit FACT-005 developer execution request. The latter explicitly includes the pinned develop base, exact readiness document carry-forward, delegated implementation, real build/test/security checks and task-branch/draft-PR publication into develop. Expiry is completion of this bounded developer task. Stable source message IDs and original issued timestamps are not exposed by the interface; preserve this limitation rather than fabricate them or assert a GitHub/legal identity. Observation timestamps and hashes are recorded separately.

Approved immutable input hashes (SHA256): SRS `4fea76ffa442f399ee43da2baa0add275ebd289ad2516adf1f7640e61e2bf2e8`; ADR `65613d60701d7697a48ff9c7a0722ec82edbddadf4da5b69638825a766b386d5`; developer plan `b58390db974b10b058d30d25962afc31f504d509d3306bbf49cb1b00d284f7ac`. The original candidate files remain byte-identical, so their historical PENDING labels are superseded only by this real authorization record, not silently rewritten.

## Boundaries and delegation

Execute [the approved developer plan](fact-004b-developer-plan.md), [SRS](../specs/factory-runtime-phase1.md), [ADR](../adrs/factory-runtime-phase1.md) and AC-01 through AC-10, within the plan's file allowlist. Root coordinator owns CI, tool setup, plans/evidence, append-only shared log, final evidence, commits and draft PR. Delegated implementation agent `/root/fact005_runtime` owns runtime/dotnet source, configuration, sample, lockfiles, meaningful tests and README. This is an agent in the current managed Codex Cloud workspace; there is no exposed separate external Codex-task launch API. Workspace folder is factory-dotnet10; managed environment naming is unverified and not changed.

Developer checks are not independent QA/security/review. Independent roles are not authorized or represented by this delegation. No real model calls, production data, arbitrary source execution, GitHub tools in the runtime, merge, deployment or close. No persistent environment/repository settings changes. SDK and security tools are installed task-locally with verified published digests. New package versions, failed mandatory checks requiring scope changes, or changed input base trigger a stop/replan, not blanket authority to upgrade or weaken checks.

The current develop SHA and absence of the proposed task branch were verified via Git fetch/ls-remote before creating a new genuine worktree. All workflow triggers at the input base were inspected: existing documentation/evaluator jobs, no deployment trigger. New implementation/test/CI content receives developer evidence only; exact-output independent acceptance remains BLOCKED until separately approved roles run.

## Execution and handoff

Implement the bounded workflow, run pinned SDK restore/build/tests/format/dependency audit, gitleaks and CodeQL, preserve raw outcomes and AC mappings, publish the approved task branch and draft PR into develop, report actual head/tested integration revision/checks and stop. Unavailable/failed required tools are NOT_RUN/FAILED and progression is BLOCKED; a draft PR may expose the blocker without claiming completion or acceptance. Handoff must state all unexecuted checks and no fabricated QA evidence.
