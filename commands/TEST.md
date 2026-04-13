# Command: TEST

Use this command to select, plan, implement, and evaluate the right tests for the current project, slice, or recovery effort.

## Objective

Apply a risk-appropriate test strategy that proves business behavior, not just superficial execution.

## Activate these skills
- `skills/test-enforcement/SKILL.md`
- `skills/test-strategy-selection/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/review-gates/SKILL.md`

## Required inputs
- authoritative spec
- current plan or rescue plan
- selected architecture shape
- critical business rules
- current implementation scope

## Required outputs
- `plans/<project>-test-strategy.md`
- updated requirement-to-test mapping
- module or slice-level automated tests
- evidence of pass results

## Procedure
1. Classify project shape and risk profile.
2. Select one or more packs from `test-strategy-packs/`.
3. Instantiate `templates/project-test-strategy-template.md`.
4. Update the requirement-to-test mapping.
5. Implement tests for the current scope.
6. Capture failures and regressions explicitly.
7. Feed results into review scorecards.

## Non-negotiable rules
- Do not default to a generic smoke-only approach.
- Do not rely on UI snapshots as proof of business correctness.
- Do not close rescue work without regression coverage.


## AppSec and PT Testing Additions


Testing must include security validation when the system risk profile requires it.

Add to the test phase:
- execute or plan AppSec activities appropriate for the system
- capture findings in the AppSec findings tracker
- perform PT readiness checks when PT is required
- ensure retest is performed after security fixes
- update requirement-to-test mapping and evidence to include security testing

Use:
- `templates/appsec-test-plan-template.md`
- `templates/appsec-findings-tracker-template.md`
- `templates/penetration-test-readiness-template.md`
- `templates/penetration-test-findings-log-template.md`

