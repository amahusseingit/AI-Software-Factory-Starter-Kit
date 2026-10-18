# Role plan

Use for every role and iteration, including closure, security review and release readiness. Follow [canonical protocol](../governance/protocol.md) and [security policy](../governance/security-policy.md). Planning is read-only with only the protocol's narrowly permitted append-only planning record. This template does not permit saving other planning files before approval.

## Identity and current state
- Role, plan ID/revision and date:
- Task context, slice/story/finding IDs:
- Canonical current state and evidence:
- Latest completed role and exact handoff/log IDs:
- Expected next role:

## Inputs actually read
| Artifact/path and version | Requirement/criterion or log IDs | Relevant evidence |
|---|---|---|
| | | |

List planned inspection separately. State missing or stale artifacts; do not certify unread inputs.

## Understanding and scope
- Outcome and requirement interpretation:
- Included stories/findings/criteria:
- Explicit exclusions and future slices:
- Dependencies and prior approvals verified:
- Decisions needing clarification:

## Proposed plan
1. Role-specific step and its output.
2. Validation and evidence step.
3. Self-check, append-only execution log, handoff and stop.

## Files and outputs
| Files inspected | Files still to inspect | Files expected to change | Intended output and reason |
|---|---|---|---|
| | | | |

## Validation and execution effects
- Acceptance criteria and expected evidence:
- Tests/review checks and proposed commands:
- Environment, external effects, data sensitivity and permissions:
- Stop/fail criteria and handling of unavailable tools:
- Compatibility, migration and rollback concerns where applicable:

## Risks, assumptions and open questions
| Item | Evidence or assumption | Impact | Owner/decision needed |
|---|---|---|---|
| | | | |

## Role-specific additions
- PO: epics, story breakdown, prioritization and criterion strategy.
- Architect: inspected patterns, components, contracts, data/migrations, security and test impact.
- Developer: implementation sequence, design instructions, tests and deviations needing approval.
- QA: review areas, static analysis, positive/negative/data-quality cases and impacted regression.
- Remediation: each finding's root cause, before/after behavior, fix and proof.
- Regression: finding-to-criterion mapping and justified impact area.
- Coordinator: evidence reconciliation, closure conditions and unresolved gate decisions.
- Independent reviewer: named independent actor, exact candidate, review method and findings evidence.
- Security reviewer: assets, trust boundaries, test restrictions and safe evidence handling.
- Release owner: candidate revision, readiness/migration/rollback/support checks and decision owners.

## Approval record
Record actual user approval only after it arrives: approver identity, message/reference, timestamp, exact plan revision/scope and any conditions, using canonical fields. Leave pending until then. Never use an agent's recommendation, this template or an earlier role approval as authorization.

## Stop gate
Plan prepared. Waiting for approval before execution.

## Provenance
Merged from `archive/july-prior/ai_software_factory_kit_problems_sla/factory/plan-template.md`, updated `archive/july-updated/ai_software_factory_kit_problems_sla/factory/agent-loop-protocol.md`, and the numbered reusable role prompts identified in [role source mapping](../roles/README.md#source-mapping).
