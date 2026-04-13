# Changelog

## V7.7

Adds stronger implementation discipline to the kit:
- assumption and ambiguity control
- simplicity and complexity control
- surgical change control for rescue and maintenance work
- verification attached to each major step or slice

### Added
- `skills/assumption-and-ambiguity-control/SKILL.md`
- `skills/surgical-change-control/SKILL.md`
- `references/simplicity-and-change-discipline.md`
- `templates/assumptions-log-template.md`
- `templates/ambiguity-register-template.md`
- `templates/surgical-change-plan-template.md`
- `templates/step-verification-plan-template.md`

### Updated
- `AGENTS.md`
- `commands/PLAN.md`
- `commands/BUILD.md`
- `commands/RESCUE-PROJECT.md`
- `commands/REVIEW.md`
- planning, implementation, and rescue skills
- `README.md`

## V7.6

Integrates Application Security (AppSec) testing and Penetration Testing (PT) readiness into the governed lifecycle.

### Added
- AppSec testing and remediation skill
- PT readiness skill
- AppSec and PT packs
- AppSec/PT templates, trackers, and scorecards
- AppSec/PT integration example

### Lifecycle impact
- `PLAN` includes security planning applicability
- `TEST` includes AppSec execution and findings tracking
- `REVIEW` includes security evidence and unresolved findings
- `SHIP` includes AppSec/PT status in release readiness

## V7.5

Extends the generic kit with:
- NFR packs under `packs/`
- architecture decision packs under `adr-packs/`
- DevOps and deployment packs under `devops-packs/`
- supporting skills, templates, examples, and documentation

## V7.4

Adds the next reliability wave on top of V7.3:
- stronger rescue mode
- better traceability automation
- test strategy packs

### Added
- rescue gap taxonomy and salvage-vs-rebuild guidance
- recovery planning templates for incomplete generated projects
- business rule verification matrix and requirement-to-test mapping
- project-level test strategy selection using reusable packs
- `skills/traceability-governance/`
- `skills/test-strategy-selection/`

## V7.3

Adds stronger control and review capability:
- readiness scoring
- spec quality analysis
- UI workflow and screenshot templates
- structured review scorecards
