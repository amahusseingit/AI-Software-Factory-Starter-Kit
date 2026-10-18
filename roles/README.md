# Reusable role playbooks

These role documents restore the detailed earlier role guidance while adopting the updated observe/plan/approve/execute/self-check/log/handoff loop. [Canonical protocol](../governance/protocol.md) and [security policy](../governance/security-policy.md) control; roles are not competing state machines, permission grants or domain specifications.

| Role | Playbook | Primary approved output |
|---|---|---|
| Product Owner | [product-owner](product-owner.md) | Requirement-linked backlog and criteria |
| Architect | [architect](architect.md) | Technical design and implementation handoff |
| Developer | [developer](developer.md) | Scoped implementation and test evidence |
| QA | [qa](qa.md) | Independent validation and findings |
| Remediation | [remediation](remediation.md) | Finding-linked fixes |
| Regression | [regression](regression.md) | Independent fix/impact validation |
| Coordinator | [coordinator](coordinator.md) | Evidence reconciliation and closure summary |
| Independent reviewer | [independent-reviewer](independent-reviewer.md) | Independent candidate review and findings |
| Security reviewer | [security-reviewer](security-reviewer.md) | Security review evidence and findings |
| Release owner | [release-owner](release-owner.md) | Release-readiness decision packet |

Every role, including closure, security and release-readiness review, first presents its own plan and stops for explicit user approval. A role assignment is not that approval. No role approves itself, its successor or a release. Use canonical vocabulary rather than the historical verdict/status lists.

## Source mapping

Paths below are repository-relative archived provenance. These files are inactive historical sources; the maintained roles above govern current responsibilities.

- Earlier detailed role source root: `archive/july-prior/ai_software_factory_kit_problems_sla/`.
- Updated loop source root: `archive/july-updated/ai_software_factory_kit_problems_sla/`.
- Reusable prompt source root: `archive/july-reusable-prompts/`.
- Product Owner merges both roots' `skills/product-owner/skill.md` and reusable `01-product-owner-reusable-prompt.md`.
- Architect merges both roots' `skills/solution-architect/skill.md` and reusable `02-solution-architect-reusable-prompt.md`.
- Developer merges both roots' `skills/developer/skill.md` and reusable `03-developer-reusable-prompt.md`.
- QA merges both roots' `skills/qa-static-analysis/skill.md` and reusable `04-qa-static-analysis-reusable-prompt.md`.
- Remediation restores reusable `05-remediation-developer-reusable-prompt.md`; regression restores `06-qa-regression-reusable-prompt.md`; coordinator merges `07-slice-closure-reusable-prompt.md`, with its ungated closure behavior deliberately replaced by the canonical per-role gate.
- All roles incorporate updated `factory/agent-loop-protocol.md`, the earlier/updated `factory/workflow-protocol.md`, and reusable `00-common-operating-protocol.md` and `08-quick-task-context-examples.md` for scoped tasks and handoffs. Conflicting historical no-write/planning-log wording is resolved only by the canonical protocol's narrow append exception.
- New templates preserve earlier `factory/plan-template.md`, `factory/story-template.md` and `factory/handoff-checklist.md`, expanded with explicit approval/evidence/traceability and updated loop checks.
- Security reviewer expands repository-relative `agents/security-auditor.md`; release owner expands `agents/release-readiness-reviewer.md`. Their added details are governance integration, not claims that July supplied complete standalone roles.
- Domain-specific algorithms, names, epics, UI and QA cases are retained in [the non-authoritative Problems SLA example](../profiles/problems-sla-example.md). Technology-specific layering moves to [the optional stack profile](../profiles/dotnet-sqlserver-angular-flutter.md); neither is a default.

The shared-log append discipline and detailed earlier deliverables are retained. Historical project-specific rules, unconditional architecture assumptions, automatic next-slice implications and inconsistent result vocabularies are not reusable authority.
