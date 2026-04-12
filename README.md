# Project Starter Kit V7.4

V7.4 adds the next reliability wave on top of V7.3:
- stronger rescue mode
- better traceability automation
- test strategy packs

The kit remains generic. It is meant to start building any system from a project-specific spec placed under `specs/`.

## What V7.4 adds
- rescue gap taxonomy and salvage-vs-rebuild guidance
- recovery planning templates for incomplete generated projects
- business rule verification matrix and requirement-to-test mapping
- project-level test strategy selection using reusable packs
- two new core skills:
  - `skills/traceability-governance/`
  - `skills/test-strategy-selection/`

## Recommended use flow
1. Put the authoritative project spec in `specs/`
2. Start with `commands/START-PROJECT.md`
3. Run `commands/SPEC.md` if the spec is weak or incomplete
4. Run `commands/PLAN.md` and instantiate traceability and test strategy artifacts
5. Run `commands/BUILD.md` and `commands/TEST.md` slice by slice
6. Run `commands/REVIEW.md`
7. Run `commands/SHIP.md`

## Recovery flow for incomplete projects
If a system was already generated but is incomplete, use:
- `commands/RESCUE-PROJECT.md`
- `references/rescue-gap-taxonomy.md`
- `references/salvage-vs-rebuild-guidance.md`
- `templates/rescue-recovery-plan-template.md`

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


## V7.5 Additions

V7.5 extends the generic kit with:
- NFR packs under `packs/`
- architecture decision packs under `adr-packs/`
- DevOps and deployment packs under `devops-packs/`
- supporting skills, templates, examples, and documentation
