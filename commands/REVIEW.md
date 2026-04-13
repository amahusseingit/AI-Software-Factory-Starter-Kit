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


## AppSec and PT Review Additions


The review phase must explicitly evaluate security testing status.

Review must answer:
- was AppSec testing scoped and executed appropriately?
- are there unresolved Critical/High findings?
- was PT required and, if so, was it completed?
- were findings triaged, fixed, and retested?
- does release readiness reflect the security state accurately?

Use:
- `templates/appsec-review-scorecard-template.md`
- `templates/security-review-scorecard-template.md`



## V7.7 Additions

Reviewers should explicitly evaluate:
- whether assumptions were recorded instead of silently guessed
- whether the solution is proportionate to the request
- whether speculative abstractions were introduced without justification
- whether the diff scope stayed surgical where appropriate
- whether each major step had a defined verification method and evidence
