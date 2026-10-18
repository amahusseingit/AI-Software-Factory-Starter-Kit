> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# BUILD

Use this to implement one vertical slice completely.

## Operator Prompt
Implement exactly one slice to behavioral completeness. Do not move to the next slice until this slice is complete, tested, and evidenced.

### Completion requirements per slice
- backend behavior implemented
- database behavior implemented if applicable
- Angular behavior implemented if applicable
- Flutter behavior implemented if applicable
- validations implemented
- loading, empty, error, and success states implemented
- visible actions wired or removed
- tests added and passing
- evidence file updated

### Forbidden outcomes
- placeholder buttons
- TODO handlers
- dialog opens but save not wired
- save works without validation
- mutation works but UI does not refresh
- web complete but mobile parity missing for in-scope behavior


## V7.7 Additions

During implementation:
- prefer the minimum solution that satisfies the requirement
- avoid speculative abstractions and optionality
- if modifying existing code, use surgical change control
- if assumptions affect behavior, keep them visible in implementation notes and evidence
- ensure each major build step has a corresponding verification action

## Unified execution boundary
Before execution, read governance/protocol.md and the selected role plan. Require explicit user approval bound to role, task, scope, plan and input revision. G3 must pass before BUILD. Use only PASS/BLOCKED progression decisions. Execution ends at evidence handoff and stop; no automatic next role or closure. Commands are subordinate methods, never authority to approve themselves.
