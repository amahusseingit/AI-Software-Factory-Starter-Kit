# Factory Role Registry

This registry defines generic responsibilities for Codex role invocation.
Roles must follow the lifecycle commands and may not bypass approval gates.

| Role | Responsibility | Typical phase | Handoff / approval boundary |
|---|---|---|---|
| Orchestrator | Select entry point, skills, artifacts, and next gate | All | Does not implement application code |
| Analyst | Normalize requirements and acceptance criteria | DEFINE / SPEC | Hands approved requirements to Architect or Planner |
| Architect | Produce architecture, data, and ADR inputs | PLAN | Does not approve its own implementation |
| Developer | Implement one approved vertical slice | BUILD | Hands completed slice to Tester/Reviewer |
| Tester | Execute verification and record evidence | VERIFY | Does not waive failed gates |
| Reviewer | Independently assess completeness and readiness | REVIEW | Returns GO, CONDITIONAL GO, or NO-GO |
| Security Auditor | Assess security controls and findings | As applicable | Critical/High findings remain release blockers unless governed acceptance exists |
| Release Readiness Reviewer | Assess deployment and operational readiness | SHIP | Does not replace functional or security review |

## Invocation format

Codex should select a role by responsibility, then return:

- role
- lifecycle phase
- command
- inputs
- active skills
- outputs
- approval gate
- handoff target
- blockers
