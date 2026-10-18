# AI Software Factory — Reusable Role Prompts

This package contains reusable generic prompts for the Emaratech KPI Dashboard AI Software Factory workflow.

Use these prompts repeatedly as the project progresses. The only part you normally change is the **Task Context** section.

Each prompt assumes the role will read:

- `AGENTS.md`
- The relevant SRS / BRD / requirements document
- `ai_software_factory_kit_problems_sla/factory/shared-log.md`
- The relevant handoff from the previous role
- The role-specific `skill.md`

The role should discover what to do next from the shared log and handoff notes, instead of you repeating all instructions every time.

## Recommended Usage

1. Open Codex Desktop in the repository root.
2. Pick the correct role prompt.
3. Replace the placeholder under **Task Context**.
4. Paste the prompt into Codex.
5. Review the plan.
6. Approve execution only when the plan is acceptable.

## Files

| File | Purpose |
|---|---|
| `00-common-operating-protocol.md` | Shared rules for all roles |
| `01-product-owner-reusable-prompt.md` | Generic PO prompt |
| `02-solution-architect-reusable-prompt.md` | Generic Architect prompt |
| `03-developer-reusable-prompt.md` | Generic Developer prompt |
| `04-qa-static-analysis-reusable-prompt.md` | Generic QA prompt |
| `05-remediation-developer-reusable-prompt.md` | Generic Developer remediation prompt |
| `06-qa-regression-reusable-prompt.md` | Generic QA regression prompt |
| `07-slice-closure-reusable-prompt.md` | Generic slice closure prompt |
| `08-quick-task-context-examples.md` | Examples of task context blocks |
