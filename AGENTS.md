# AGENTS.md

This file governs execution inside ProjectStarterKit V7.

## Operating principle

Use the starter kit as a **governed, orchestrated delivery operating system**, not as an unstructured prompt pack.

The operating model has four layers:

1. `AGENTS.md` = governance rules
2. `ORCHESTRATOR.md` = human-facing orchestration guide
3. `commands/` = lifecycle phases
4. `skills/` = specialist execution workflows

In addition, the AI should use:
- `references/`
- `templates/`
- `packs/`
- `adr-packs/`
- `devops-packs/`
- `test-strategy-packs/`

when relevant.

## Mandatory orchestration rule

Before major work begins, the AI must use the orchestration layer to determine:
- project state
- lifecycle entry point
- active commands
- active skills
- active packs/templates
- minimum artifact expectations

Use:
- `ORCHESTRATOR.md`
- `skills/orchestration-and-lifecycle-control/`
- `skills/codex-factory-adapter/SKILL.md` when work is being routed through Codex

Do not implement directly when a defined command or skill applies.

## Lifecycle

1. DEFINE
2. PLAN
3. BUILD
4. VERIFY
5. REVIEW
6. SHIP

Lifecycle command mapping:

- `START-PROJECT` enters DEFINE for a new project.
- `SPEC` normalizes and assesses requirements within DEFINE.
- `PLAN` produces implementation slices and planning artifacts.
- `BUILD` implements approved vertical slices.
- `VERIFY` is the lifecycle gate; `commands/TEST.md` is its execution command.
- `REVIEW` evaluates completeness and readiness.
- `SHIP` prepares release readiness.

## Project mode defaults

Unless the authoritative project spec explicitly says otherwise, assume:

- Backend: .NET 8 / ASP.NET Core Web API
- Database: Microsoft SQL Server
- Web: Angular
- Mobile: Flutter
- Authentication: JWT access token + refresh token
- External auth when needed: Google Sign-In

## Mandatory routing rules

### New system or large feature
Always activate:
- `skills/orchestration-and-lifecycle-control/SKILL.md`
- `skills/codex-factory-adapter/SKILL.md` when using Codex
- `skills/using-starter-kit/SKILL.md`
- `skills/spec-driven-delivery/SKILL.md`
- `skills/planning-and-task-breakdown/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/test-strategy-selection/SKILL.md`

### API or integration work
Also activate as applicable:
- `skills/api-contract-design/SKILL.md`
- `skills/dotnet-api-delivery/SKILL.md`
- `skills/enterprise-integration-and-orchestration/SKILL.md`
- `skills/observability-and-audit/SKILL.md`

### Data layer work
Also activate:
- `skills/sqlserver-data-delivery/SKILL.md`

### Angular web work
Also activate:
- `skills/angular-ui-engineering/SKILL.md`

### Flutter mobile work
Also activate:
- `skills/flutter-ui-engineering/SKILL.md`

### Authentication work
Also activate:
- `skills/auth-jwt-refresh-google-signin/SKILL.md`

### Financial and recurrence logic
Also activate:
- `skills/recurring-rules-engine/SKILL.md`

### Build and completion
Always activate:
- `skills/incremental-implementation/SKILL.md`
- `skills/test-enforcement/SKILL.md`
- `skills/cross-platform-parity/SKILL.md`
- `skills/review-gates/SKILL.md`
- `skills/shipping-readiness/SKILL.md`

The applicable command file must repeat its active-skill set and required gate inputs.

### Defects and recovery
When troubleshooting:
- `skills/orchestration-and-lifecycle-control/SKILL.md`
- `skills/debugging-and-recovery/SKILL.md`
- `skills/source-grounding/SKILL.md`
- `skills/project-rescue-and-completion/SKILL.md`
- `skills/surgical-change-control/SKILL.md`

### Ambiguity and assumptions
When requirements are unclear:
- `skills/orchestration-and-lifecycle-control/SKILL.md`
- `skills/spec-quality-analysis/SKILL.md`
- `skills/assumption-and-ambiguity-control/SKILL.md`

### Security-sensitive projects
Also activate as applicable:
- `skills/appsec-testing-and-remediation/SKILL.md`
- `skills/penetration-testing-readiness/SKILL.md`

## Hard rules

- Do not silently invent missing business rules.
- Do not accept visual UI as functional completion.
- Do not leave placeholder CRUD for in-scope modules.
- Do not over-engineer with speculative abstractions.
- Do not perform uncontrolled rescue or broad rewrite when surgical change control is required.
- Do not claim review or release readiness without evidence artifacts.

## Final rule

Use the starter kit in this control order:
1. governance from `AGENTS.md`
2. orchestration from `ORCHESTRATOR.md`
3. lifecycle selection through `commands/`
4. detailed execution through `skills/`
5. evidence and progression through project artifacts
