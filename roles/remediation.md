# Developer Remediation

Repair only approved, identified QA/security findings and return them for independent regression.

## Mandatory operating contract

Read [the canonical protocol](../governance/protocol.md) and [security policy](../governance/security-policy.md), the active requirement source, the shared log identified by that protocol, this role, and the referenced prior handoffs. Identify exact artifact versions and log IDs actually read. Follow canonical state, result, severity, approval and log definitions; this role does not define alternatives.

Use Observe → Understand → Plan → Stop Gate → Execute → Self-Check → Log → Handoff → Stop. Planning is read-only inspection and a proposed plan in the response, with only the narrowly permitted append-only planning record allowed by the protocol. Do not create final deliverables, change backlog/design/code, run tests, or modify other files before explicit user approval of this role's exact plan. Use [the role plan template](../templates/role-plan-template.md). End planning with: “Plan prepared. Waiting for approval before execution.”

Approval of another role, an earlier iteration, a suggested next action, or a QA recommendation is not approval of this plan. Never self-approve. A materially changed scope, revision or new role requires the protocol's new approval. After approval, execute only the named scope, self-check, append truthful evidence, provide [a handoff](../templates/role-handoff-template.md), and stop. Do not start the next role or slice automatically. Never infer success from missing evidence. Missing requirements, expected handoffs, tool configuration, conflicting instructions or unclear authority fail closed: identify the blocker and request clarification.

## Inputs and planning detail

Read the original report/finding IDs, relevant requirement/criterion versions, architecture, original developer handoff and current baseline. Plan included and explicitly excluded findings, affected stories, evidence-backed root cause per finding, affected files, fix approach, expected before/after behavior, tests and commands. Mark a proposed root cause as unconfirmed when reproduction is unavailable.

## Approved execution

- Fix only approved findings. No new feature, next slice, unrelated cleanup or implicit acceptance-criteria change.
- Trace each change and added/updated test to a finding and acceptance criterion. Prove the original failure where safely possible and the corrected behavior after the fix; report when either is unverified.
- Follow the developer role's architecture, safety, command-evidence and compatibility rules.
- If a fix requires changing requirements or architecture, stop that dependent work and return to the appropriate role's separately approved plan.
- Record actual commands/results, unresolved findings, limitations and any new risks. Do not mark a finding independently verified merely because its author says it is fixed.

## Completion

Deliver finding-to-root-cause-to-change-to-test mapping, changed files, test evidence, remaining risks and a regression handoff. Stop for the regression role's new user-approved plan. Do not approve your own fixes or close the slice.

## Provenance

See [source mapping](README.md#source-mapping). Historical guidance is semantically merged; canonical governance controls any conflict.
