# Role execution handoff

Use after approved execution and self-check. Apply [canonical protocol](../governance/protocol.md) and [security policy](../governance/security-policy.md). This is evidence and a next-role recommendation, not approval to execute that next role.

## Identity and authorization
- Role, slice/story/finding IDs and candidate/artifact version:
- Approved plan ID/revision and actual user approval reference:
- Previous handoff and shared-log entries actually read:
- Canonical state/result fields, using protocol vocabulary:

## Work and decisions
- Included/excluded scope and completion summary:
- Requirement/story/criterion/design versions used:
- Decisions, assumptions and unresolved questions:
- Files inspected and changed:
- Deviations and their explicit authorization, or blockers:

## Command and validation evidence
| Actual command/check | Environment and version | Exit/result | Evidence location | Limitations |
|---|---|---|---|---|
| | | | | |

Keep planned/unexecuted commands clearly separate. Record the reason and impact for each unexecuted check. Never fabricate execution evidence.

| Requirement/story/criterion or finding | Expected behavior | Actual evidence | Canonical result | Remaining action |
|---|---|---|---|---|
| | | | | |

## Findings and risks
| Finding/risk | Impact and canonical severity | Owner | Disposition and approval evidence | Retest needed |
|---|---|---|---|---|
| | | | | |

## Role-specific completeness
- PO: epics/stories, Given/When/Then criteria, quality/scope/reconciliation rules, dependencies, tests and requirement traceability.
- Architect: inspected patterns, components/contracts/data, algorithms, migrations, authorization, failure/quality handling, tests and implementation order.
- Developer: scoped implementation, tests, actual build results, changed files, deviations and QA validation needs.
- QA: review/static analysis/test evidence, criterion matrix, reproducible findings, regression risk and one canonical recommendation.
- Remediation: finding/root-cause/change/test mapping and remaining findings.
- Regression: independently verified fixes, impacted criteria, residual/new defects and canonical recommendation.
- Coordinator: consolidated scope, evidence, open criteria/defects, authorized risk decisions and closure recommendation.
- Independent reviewer: named independent actor, exact candidate, scope/design/test adequacy review and findings.
- Security reviewer: assessed surfaces, methods, sanitized evidence, findings, gaps and remediation/retest needs.
- Release owner: candidate identity, gates/approvers, readiness, migration/rollback/support evidence and outstanding release decisions.

## Self-check and next action
- Approved scope followed; only authorized files/actions changed:
- Architecture and requirement boundaries preserved:
- Output verified and limitations recorded:
- Shared log appended, with new entry ID:
- Exact next role and its required inputs:
- Blocking decisions or evidence:
- Explicit stop: no successor role, slice or release has been started.

## Provenance
Merged from `archive/july-prior/ai_software_factory_kit_problems_sla/factory/handoff-checklist.md`, both versions' role completion/log requirements and reusable prompts' detailed handoffs; see [source mapping](../roles/README.md#source-mapping).

## Branch and promotion binding
Use the [branch record](branch-record-template.md): repository, unique task ID, source branch, approved base ref/SHA, output head, intended target/observed SHA and tested integration result. Record bootstrap exceptions explicitly. Changes invalidate affected approvals/evidence; no direct main/develop writes. Publication, merge, release and deployment remain separate authorized actions.
