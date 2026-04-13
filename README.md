# AI Software Factory Starter Kit V7.7

A generic, governed AI delivery kit for building, rescuing, reviewing, testing, securing, and shipping software systems from a project-specific spec.

The kit is intentionally **generic**. It is designed to start building **any system** from an authoritative spec placed under `specs/`.

---

## What this kit is

This repository is an operating model for AI-assisted software delivery. It combines:
- lifecycle commands
- reusable delivery skills
- governance rules
- traceability and evidence patterns
- readiness scoring
- rescue workflows
- NFR, architecture, DevOps, AppSec, and PT support

It helps teams move from requirements to implementation with stronger discipline, reviewability, and release readiness.

---

## What this kit is not

This repository is not:
- a generated business application
- a domain-specific product template
- a single-stack framework implementation
- a substitute for product thinking, engineering review, or testing judgment

Project-specific requirements belong in `specs/`, not in the core kit.

---

## Current version summary

### V7.4
Added the next reliability wave on top of V7.3:
- stronger rescue mode
- better traceability automation
- test strategy packs

### V7.5
Extended the generic kit with:
- NFR packs under `packs/`
- architecture decision packs under `adr-packs/`
- DevOps and deployment packs under `devops-packs/`
- supporting skills, templates, examples, and documentation

### V7.6
Integrated **Application Security (AppSec)** and **Penetration Testing (PT)** into the governed lifecycle.

### V7.7
Strengthens implementation discipline with:
- assumption and ambiguity control
- simplicity and complexity control
- surgical change control for rescue and maintenance work
- verification attached to each major step or slice

---

## Start here

1. Add your project spec under `specs/`.
2. Read `docs/getting-started.md`.
3. Start with `commands/START-PROJECT.md`.
4. Continue through the lifecycle:
   - `commands/SPEC.md`
   - `commands/PLAN.md`
   - `commands/BUILD.md`
   - `commands/TEST.md`
   - `commands/REVIEW.md`
   - `commands/SHIP.md`
5. If the system is already partially generated or incomplete, use `commands/RESCUE-PROJECT.md`.

---

## Lifecycle overview

```text
SPEC → PLAN → BUILD → TEST → REVIEW → SHIP
          ↑
       RESCUE
```

### SPEC
Normalize and assess the project spec, identify gaps, record assumptions, and establish the authoritative source of truth.

### PLAN
Break work into behaviorally meaningful slices, select test and review strategy, and generate traceability and evidence expectations.

### BUILD
Implement in vertical slices with real behavior, minimal justified complexity, and explicit verification.

### TEST
Apply the appropriate test strategy, AppSec checks, and business-rule validation.

### REVIEW
Use scorecards and readiness scoring to evaluate functionality, architecture, UI, testing, security, and release blockers.

### SHIP
Prepare release-readiness, deployment, rollback, and operational packaging.

### RESCUE
Classify gaps in incomplete generated systems, decide salvage vs rebuild, and recover using controlled changes.

---

## Key capabilities by version

### Reliability and governance
- rescue gap taxonomy and salvage-vs-rebuild guidance
- recovery planning templates for incomplete generated projects
- business-rule verification matrix and requirement-to-test mapping
- project-level test strategy selection using reusable packs
- traceability governance and review scorecards

### Architecture, NFR, and operations
- non-functional requirement packs in `packs/`
- architecture decision packs in `adr-packs/`
- DevOps and deployment packs in `devops-packs/`

### Security lifecycle integration
- AppSec planning during `PLAN`
- AppSec execution and findings tracking during `TEST`
- security scorecards during `REVIEW`
- PT readiness and PT status in `SHIP`

Use the security additions:
- `skills/appsec-testing-and-remediation/`
- `skills/penetration-testing-readiness/`
- `packs/appsec-testing-pack.md`
- `packs/penetration-testing-pack.md`
- `templates/appsec-test-plan-template.md`
- `templates/appsec-findings-tracker-template.md`
- `templates/appsec-review-scorecard-template.md`
- `templates/penetration-test-readiness-template.md`
- `templates/penetration-test-findings-log-template.md`

### Implementation discipline
Use the V7.7 additions:
- `skills/assumption-and-ambiguity-control/`
- `skills/surgical-change-control/`
- `references/simplicity-and-change-discipline.md`
- `templates/assumptions-log-template.md`
- `templates/ambiguity-register-template.md`
- `templates/surgical-change-plan-template.md`
- `templates/step-verification-plan-template.md`

---

## Recommended use flow

1. Put the authoritative project spec in `specs/`
2. Start with `commands/START-PROJECT.md`
3. Run `commands/SPEC.md` if the spec is weak or incomplete
4. Run `commands/PLAN.md` and instantiate traceability, test strategy, and verification artifacts
5. Run `commands/BUILD.md` and `commands/TEST.md` slice by slice
6. Run `commands/REVIEW.md`
7. Run `commands/SHIP.md`

---

## Recovery flow for incomplete projects

If a system was already generated but is incomplete, use:
- `commands/RESCUE-PROJECT.md`
- `references/rescue-gap-taxonomy.md`
- `references/salvage-vs-rebuild-guidance.md`
- `templates/rescue-recovery-plan-template.md`

For targeted recovery and safer change discipline, also use:
- `skills/surgical-change-control/`
- `templates/surgical-change-plan-template.md`
- `templates/assumptions-log-template.md`
- `templates/ambiguity-register-template.md`

---

## Core outputs expected per project

- `plans/<project>-slice-plan.md`
- `plans/<project>-traceability-matrix.md`
- `plans/<project>-business-rule-verification-matrix.md` when applicable
- `plans/<project>-test-strategy.md`
- `plans/<project>-requirement-to-test-map.md`
- `evidence/stack-conformance.md`
- `evidence/<module>-functional-proof.md`
- `evidence/ui-action-inventory.md`
- `evidence/cross-platform-parity-report.md`
- `reviews/<module>-review-report.md`
- `releases/<release>-readiness.md`

Additional security outputs may include:
- `evidence/appsec-test-plan.md`
- `evidence/appsec-findings-tracker.md`
- `reviews/appsec-review-scorecard.md`
- `releases/penetration-test-readiness.md`

Additional implementation-discipline outputs may include:
- `plans/assumptions-log.md`
- `plans/ambiguity-register.md`
- `plans/step-verification-plan.md`

---

## Repository structure

```text
.
├── AGENTS.md
├── README.md
├── CHANGELOG.md
├── commands/
├── skills/
├── references/
├── templates/
├── packs/
├── adr-packs/
├── devops-packs/
├── test-strategy-packs/
├── docs/
├── specs/
├── plans/
├── evidence/
├── reviews/
├── adrs/
├── releases/
├── examples/
├── agents/
├── governance/
└── jira/
```

Notes:
- `commands/` is the primary lifecycle interface.
- `skills/` contains reusable governed workflows.
- `prompts/` is kept only for legacy compatibility and optional role-based prompting.
- `.windsurf/` is an optional editor/tool adapter layer when present.

---

## Open-source usage philosophy

This repository is designed to be:
- reusable
- extensible
- generic
- governance-friendly
- AI-tool-agnostic at the operating-model level

The most important rule is to keep the **core kit generic** and place project-specific requirements under `specs/`.

---

## Documentation

Start with:
- `docs/README.md`
- `docs/getting-started.md`
- `docs/choose-your-path.md`
- `docs/repository-structure.md`
- `docs/commands-guide.md`
- `docs/skills-guide.md`
- `docs/create-your-first-project.md`
- `docs/rescue-existing-project.md`

---

## Contributing and support

See:
- `CONTRIBUTING.md`
- `CODE_OF_CONDUCT.md`
- `SECURITY.md`
- `SUPPORT.md`
- `FAQ.md`
- `LICENSE`

---

## Guiding principle

Keep the **starter kit generic**.
Do not hard-code one business domain into the kit itself.
Each actual system should provide its own requirements through a project-specific spec under `specs/`.
