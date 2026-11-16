# VERIFY Command

`VERIFY` is the lifecycle phase for proving that implemented behavior is correct.
Execute the phase through `commands/TEST.md`; do not treat TEST as a separate
lifecycle phase.

## Activate these skills

- `skills/orchestration-and-lifecycle-control/SKILL.md`
- `skills/test-enforcement/SKILL.md`
- `skills/test-strategy-selection/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/review-gates/SKILL.md`

## Required inputs

- authoritative project spec
- approved plan or rescue plan
- implemented slice or recovery scope
- selected test strategy
- traceability rows for the verified scope

## Required outputs

- automated test results
- updated requirement-to-test mapping
- evidence for the verified behavior
- explicit pass/fail disposition
- defects recorded when verification fails

## Gate rule

Do not progress to REVIEW until the verified scope has test results, evidence,
updated traceability, and an explicit disposition.
