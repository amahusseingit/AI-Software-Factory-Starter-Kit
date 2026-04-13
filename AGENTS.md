# AGENTS.md

This file governs execution inside ProjectStarterKit V7.

## Operating principle

Do not implement directly when a defined skill applies.

The agent must identify the lifecycle phase, activate the relevant skills, and produce the required artifacts before claiming completion.

## Lifecycle

1. DEFINE
2. PLAN
3. BUILD
4. VERIFY
5. REVIEW
6. SHIP

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

### Defects and recovery
When troubleshooting:
- `skills/debugging-and-recovery/SKILL.md`
- `skills/source-grounding/SKILL.md`
- `skills/project-rescue-and-completion/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/test-strategy-selection/SKILL.md`

### Security-sensitive areas
When auth, roles, sessions, externally exposed APIs, or personal data are in scope:
- `skills/security-and-hardening/SKILL.md`

## Non-negotiable rules

- Do not start implementation before identifying the authoritative spec under `specs/`
- Do not use template files under `templates/` as the source of truth unless explicitly instantiated for the project
- Do not allow stack drift from SQL Server to another database unless the spec explicitly approves it
- Do not treat placeholder UI as completed functionality
- Do not allow visible buttons, icons, links, menu items, or FABs without working handlers
- Do not pass a CRUD module with list-only behavior
- Do not allow Angular and Flutter parity drift for in-scope features without documented approval
- Do not mark a slice complete without evidence
- Do not mark the whole project complete without review artifacts

## Anti-shortcut policy

Reject these rationalizations:

- "We can wire the buttons later."
- "The screen exists, so the slice is basically done."
- "Validation can be added in the next pass."
- "Mobile can be completed later."
- "The database provider can be changed later."
- "The tests are optional for this phase."
- "The reviewer can assume the rest of the CRUD behavior."
- "The API contract is obvious from the UI."
- "We will fix traceability at the end."
- "A few smoke tests are enough for this risky workflow."

## Evidence rule

Every completed feature must provide evidence for:

- user behavior
- persistence
- validation
- loading / empty / error / success states
- state refresh after mutations
- automated tests
- review outcome
- parity outcome when applicable

## Definition of done rule

The project is not done until:
- in-scope features are implemented end to end
- required stack is respected
- tests exist and pass
- evidence exists
- review gates pass
- release-readiness artifacts are produced

## V7.4 control rules

- Before PLAN, run spec-quality-analysis and record the result under `reviews/`.
- Use readiness scorecards for build, review, rescue, and release decisions.
- When source requirements include visual artifacts, instantiate UI workflow and screenshot templates before detailed planning.
- Review outcomes must be captured with scorecards, not only narrative summaries.
- Choose a project-level test strategy before substantial implementation begins.
- Maintain traceability artifacts during plan and build, not at the end.
- For rescue work, produce a salvage-vs-rebuild decision and regression scope before repair starts.


## Additional routing for V7.5

- When quality attributes are mentioned or implied, use `skills/nfr-selection-and-hardening`.
- When major technical choices need explicit justification, use `skills/architecture-decisioning`.
- When environments, CI/CD, deployment, migration, rollback, or operational readiness are in scope, use `skills/devops-and-deployment-readiness`.


- include AppSec testing and PT planning for systems with external exposure, auth, sensitive data, admin features, file handling, or release governance requirements
- do not call a release ready without checking AppSec and PT status when applicable


## V7.7 Implementation Discipline Rules

- Do not choose silently between multiple plausible interpretations. Record assumptions before implementation.
- Use assumption-and-ambiguity control whenever the spec, workflow, or behavior is unclear.
- Keep changes proportional to the request. Prefer the minimum solution that satisfies the requirement.
- Do not add speculative flexibility, configuration, or abstractions without a current need traceable to the spec.
- For rescue, bug-fix, and targeted enhancement work, apply surgical change control.
- Every planned slice or major step must include a verification method and expected evidence artifact.
- If implementation scope expands beyond the original request, record the reason explicitly.
