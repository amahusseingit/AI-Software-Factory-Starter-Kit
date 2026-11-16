> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Command: RESCUE-PROJECT

Use this command when a generated project, module, or slice is incomplete, misleadingly complete, or drifting from the required stack and quality bar.

## Objective

Determine whether the current implementation should be salvaged, partially rebuilt, or restarted from spec/plan, then produce a controlled recovery path.

## Activate these skills
- `skills/using-starter-kit/SKILL.md`
- `skills/project-rescue-and-completion/SKILL.md`
- `skills/debugging-and-recovery/SKILL.md`
- `skills/source-grounding/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/test-strategy-selection/SKILL.md`
- `skills/review-gates/SKILL.md`

## Required inputs
- authoritative spec under `specs/`
- current implementation state
- existing tests and evidence
- stack requirements

## Required rescue outputs
- `reviews/<project>-rescue-assessment.md`
- `plans/<project>-salvage-vs-rebuild-decision.md`
- `plans/<project>-rescue-recovery-plan.md`
- updated `evidence/ui-action-inventory.md` when UI exists
- updated traceability rows for impacted requirements
- updated project test strategy and regression scope

## Procedure
1. Identify the authoritative spec and current project scope.
2. Classify gaps using `references/rescue-gap-taxonomy.md`.
3. Evaluate salvage vs rebuild using `references/salvage-vs-rebuild-guidance.md`.
4. Instantiate the decision and recovery templates.
5. Select the right test strategy pack for the recovery effort.
6. Define regression scope before implementing fixes.
7. Re-enter BUILD / TEST only after recovery plan approval.

## Non-negotiable rules
- Do not continue feature work before rescue assessment is written.
- Do not accept narrative claims of completeness without behavioral proof.
- Do not salvage blindly when architecture or contracts are fundamentally wrong.
- Do not rescue without defining regression scope.


## V7.7 Additions

During rescue:
- decide whether the change should be surgical or module-rebuild scoped
- do not mix targeted repair with unrelated cleanup
- document why any widened scope is necessary
- use the surgical change plan template for focused repair paths

## Unified execution boundary
Before execution, read governance/protocol.md and the selected role plan. Require explicit user approval bound to role, task, scope, plan and input revision. G3 must pass before BUILD. Use only PASS/BLOCKED progression decisions. Execution ends at evidence handoff and stop; no automatic next role or closure. Commands are subordinate methods, never authority to approve themselves.
