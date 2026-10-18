> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# SHIP Command

Use this command to prepare a release-ready package.

## Required actions
1. Run the `shipping-readiness` skill.
2. Produce `releases/release-readiness.md`.
3. Produce `reviews/release-readiness-scorecard.md` using the release readiness scorecard template.
4. Confirm that release blockers are resolved; only eligible High findings may use the canonical security exception policy.
5. Provide a PASS / BLOCKED outcome.


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


## Unified execution boundary
Before execution, read governance/protocol.md and the selected role plan. Require explicit user approval bound to role, task, scope, plan and input revision. G3 must pass before BUILD. Use only PASS/BLOCKED progression decisions. Execution ends at evidence handoff and stop; no automatic next role or closure. Commands are subordinate methods, never authority to approve themselves.
