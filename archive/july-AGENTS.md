# AGENTS.md
# Emaratech KPI Dashboard — Problems SLA Software Factory

## Mandatory Factory Workflow

For the Problems SLA Dashboard work, always follow:

- `problems_sla_dashboard_srs.md`
- `ai_software_factory_kit_problems_sla/README.md`
- `ai_software_factory_kit_problems_sla/factory/workflow-protocol.md`
- `ai_software_factory_kit_problems_sla/factory/shared-log.md`

## Mandatory Rule

Do not start coding immediately.

For every role:

1. Read the SRS.
2. Read the shared log.
3. Read the role-specific skill file.
4. Prepare a plan.
5. Stop and wait for user approval.
6. After approval, execute only the approved scope.
7. Append the result to the shared log.

## Role Skill Files

Product Owner:

`ai_software_factory_kit_problems_sla/skills/product-owner/skill.md`

Solution Architect:

`ai_software_factory_kit_problems_sla/skills/solution-architect/skill.md`

Developer:

`ai_software_factory_kit_problems_sla/skills/developer/skill.md`

QA / Static Analysis:

`ai_software_factory_kit_problems_sla/skills/qa-static-analysis/skill.md`

## Architecture Rules

Follow the existing KPI Dashboard architecture.

Backend:

- .NET Core Web API
- Application services/interfaces
- Infrastructure services
- EF Core / SQL Server migrations
- Tests project

Frontend:

- Angular SPA
- Feature components
- Core services
- Component specs/tests

Use the existing AppSec SLA module as a reference pattern, but do not copy AppSec-specific statuses or SLA rules into Problems SLA.

## Business Rules

- Validate scope before calculation.
- Use Jira changelog transitions for SLA timing.
- Use `Resolved` as the main engineering completion milestone.
- Use `Done` only for closure SLA unless the Product Owner changes the rule.
- Separate engineering delay from `Parked`, `Pending Vendor`, `Pending Verification`, and `Backlog` delay.
- Do not silently exclude missing owners, unmatched contributors, or unconfigured projects.
- Every role must append to `ai_software_factory_kit_problems_sla/factory/shared-log.md`.

## Recommended Codex Start Prompt

```text
You are working inside the AI Software Factory for the Emaratech KPI Dashboard Problems SLA module.

First, read:
1. problems_sla_dashboard_srs.md
2. ai_software_factory_kit_problems_sla/factory/shared-log.md
3. Your role skill.md

Do not start implementation immediately.

Prepare your role-specific plan, list assumptions, list files you expect to inspect or modify, and stop for my review.
```