# AI Software Factory: unified-1.0.0-draft.1

This is a new draft unification of pinned V7.8 and the recovered July protocols, not a recovered V9. It is generic and does not authorize application implementation or publication by itself.

## Authority
Follow explicit current user scope and applicable safety/security constraints. Approved project SRS and ADRs supply project behavior; they cannot silently relax the Factory approval and evidence controls. The sole process authority is [governance/protocol.md](governance/protocol.md), with [security-policy.md](governance/security-policy.md) for severity/exception rules and [gate-contract.json](governance/gate-contract.json) for decision vocabulary. If authorities conflict, stop for an explicit scoped resolution; do not infer a waiver.

[ORCHESTRATOR.md](ORCHESTRATOR.md) routes work, [roles/](roles/) defines role responsibilities, commands select lifecycle activities, and skills/packs/templates supply subordinate detailed techniques. Archived sources and examples are never authority, approval or evidence.

## Mandatory controls
- Every role, including QA, remediation, regression and closure coordinator, presents a scope/revision-bound plan and waits for explicit user approval before execution. No self-signoff or invented human approval.
- Before approval, only read-only planning and one narrowly permitted append-only planning record are allowed; see the protocol for its exact boundary.
- Unknown, failed, not-run, stale, missing-evidence and scope-mismatch states block. Template rows never count as evidence.
- Use a new `task/<unique-id>-<slug>` branch for every coding, configuration and documentation task; no direct main/develop writes. Record actual upstream base and head. No synthetic ancestry. See [branch-environment-policy.md](governance/branch-environment-policy.md).
- Developer tests precede independent QA; QA precedes acceptance. Closure, merge and deployment are separately authorized actions.
- No default stack or business rules. Select approved project profiles explicitly. Existing architecture is the baseline until a scoped change is approved.
- Never claim application tests, security assessment, branch protection or deployment controls were verified by documentation validators.

## Routing
Always consider orchestration-and-lifecycle-control, using-starter-kit, spec-driven-delivery, planning-and-task-breakdown, traceability-governance and test-strategy-selection under skills/.
Select API, data, Angular, Flutter, authentication, recurrence or integration skills only when the approved project scope requires them. Mobile parity applies only to in-scope clients. Always apply source grounding, ambiguity control, incremental vertical slices, test enforcement and independent review to their relevant phases. Security applicability assessment is mandatory; selected security checks cannot silently be skipped.
For defects, use debugging-and-recovery and surgical-change-control; large rescue or rewrite needs its own approval.

## Entry
Read [ORCHESTRATOR.md](ORCHESTRATOR.md), the canonical protocol and the selected role. Identify the approved SRS/ADRs and their hashes; if missing, plan clarification rather than inventing requirements. Do not implement merely because a workflow says to execute.
