> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# SPEC Command

Use this command to normalize, strengthen, and assess the project specification before planning or implementation.

## Required actions
1. Identify the authoritative spec under `specs/`.
2. Run the `spec-quality-analysis` skill.
3. Create:
   - `reviews/spec-gap-report.md`
   - `reviews/spec-readiness-scorecard.md`
4. If the spec includes screenshots, wireframes, PDFs, or Word content, instantiate as needed:
   - `templates/ui-workflow-template.md`
   - `templates/screenshot-annotation-template.md`
   - `templates/screen-inventory-template.md`
   - `templates/mobile-navigation-map-template.md`
   - `templates/web-module-map-template.md`
5. Do not proceed to PLAN if the recommendation is No-Go.

## Unified execution boundary
Before execution, read governance/protocol.md and the selected role plan. Require explicit user approval bound to role, task, scope, plan and input revision. G3 must pass before BUILD. Use only PASS/BLOCKED progression decisions. Execution ends at evidence handoff and stop; no automatic next role or closure. Commands are subordinate methods, never authority to approve themselves.
