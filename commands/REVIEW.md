# Command: REVIEW

Use this command to evaluate whether the current scope is functionally complete, traceable, adequately tested, and ready to pass to ship or further implementation.

## Activate these skills
- `skills/review-gates/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/test-enforcement/SKILL.md`
- `skills/cross-platform-parity/SKILL.md`

## Required checks
- review scorecards are completed
- traceability rows for reviewed scope are complete
- high-risk business rules have tests and evidence
- rescue findings are closed or explicitly carried forward
- parity report is updated when multiple platforms are in scope

## Required outputs
- review scorecards
- updated traceability status
- review disposition: GO / CONDITIONAL GO / NO-GO


## V7.5 review additions
- Include NFR review when applicable.
- Confirm required ADRs exist for major architecture decisions.
- Confirm deployment, migration, rollback, and operational readiness artifacts exist before release recommendation.
