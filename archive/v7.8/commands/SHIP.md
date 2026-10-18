# SHIP Command

Use this command to prepare a release-ready package.

## Required actions
1. Run the `shipping-readiness` skill.
2. Produce `releases/release-readiness.md`.
3. Produce `reviews/release-readiness-scorecard.md` using the release readiness scorecard template.
4. Confirm that release blockers are closed or explicitly accepted.
5. Provide a Go / Conditional Go / No-Go outcome.


## V7.5 shipping additions
- Verify environment matrix, deployment checklist, migration notes, rollback guidance, and operational readiness are present.
- Ensure release readiness includes any selected NFR evidence.


## AppSec and PT Release Readiness Additions


Release readiness must include a security section.

At minimum include:
- AppSec activities executed
- open findings by severity
- unresolved release blockers
- PT status (required / not required / completed / pending)
- retest status for remediated findings
- formal risk acceptance if governance allows release with non-blocking issues

