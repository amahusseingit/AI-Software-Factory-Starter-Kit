> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# START-PROJECT Command

Use this command to initialize a new project using the generic starter kit.

## Required actions
1. Confirm that `specs/` contains the authoritative project spec.
2. Run `SPEC` before planning.
3. If the spec is visual or incomplete, instantiate the relevant UI workflow and screenshot templates.
4. Run `PLAN` only after the current requirements gate is PASS with explicit user approval.
5. Create the initial readiness baseline using `templates/readiness-scorecard-template.md`.

## Unified execution boundary
Before execution, read governance/protocol.md and the selected role plan. Require explicit user approval bound to role, task, scope, plan and input revision. G3 must pass before BUILD. Use only PASS/BLOCKED progression decisions. Execution ends at evidence handoff and stop; no automatic next role or closure. Commands are subordinate methods, never authority to approve themselves.
