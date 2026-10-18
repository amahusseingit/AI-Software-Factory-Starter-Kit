
# AGENTS.md Append Section
# Problems SLA Dashboard — AI Software Factory Instructions

Append this section to the existing repository-level `AGENTS.md`. Do not replace the existing `AGENTS.md`.

---

## Problems SLA Dashboard — AI Software Factory Instructions

### Scope

These instructions apply only when working on the Problems SLA Dashboard module.

Primary requirement source:

- `problems_sla_dashboard_srs.md`

Factory kit location:

- `ai_software_factory_kit_problems_sla/`

### Mandatory Factory Workflow

For Problems SLA Dashboard work, always read:

1. `problems_sla_dashboard_srs.md`
2. `ai_software_factory_kit_problems_sla/README.md`
3. `ai_software_factory_kit_problems_sla/factory/workflow-protocol.md`
4. `ai_software_factory_kit_problems_sla/factory/agent-loop-protocol.md`
5. `ai_software_factory_kit_problems_sla/factory/shared-log.md`
6. The active role skill file under `ai_software_factory_kit_problems_sla/skills/`

### Agent Loop Protocol

Every role must follow:

```text
Observe → Understand → Plan → Stop Gate → Execute → Self-Check → Log → Handoff → Stop
```

No role may skip the Stop Gate. No role may start execution before the user approves the plan. No role may continue into the next role after completing its own work.

The shared log remains the coordination source of truth:

```text
ai_software_factory_kit_problems_sla/factory/shared-log.md
```

### Architecture Rules

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

### Business Rules

- Validate scope before calculation.
- Use Jira changelog transitions for SLA timing.
- Use `Resolved` as the main engineering completion milestone.
- Use `Done` only for closure SLA unless the Product Owner changes the rule.
- Separate engineering delay from `Parked`, `Pending Vendor`, `Pending Verification`, and `Backlog` delay.
- Do not silently exclude missing owners, unmatched contributors, or unconfigured projects.
- Every role must append to `ai_software_factory_kit_problems_sla/factory/shared-log.md`.
