> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# FIX

Use this for a specific defect in an existing project.

## Operator Prompt
Reproduce the defect, confirm expected behavior from source materials, identify the root cause, implement the fix, add regression coverage, and update evidence.

### Required steps
1. Confirm expected behavior from authoritative sources
2. Reproduce the defect clearly
3. Identify scope and impacted platforms
4. Implement fix on all impacted layers
5. Add regression tests
6. Update evidence and review artifacts

### Fail if
- bug is fixed on one platform but not the other when parity is required
- regression coverage is missing
- the root cause is guessed without grounding

## Unified execution boundary
Before execution, read governance/protocol.md and the selected role plan. Require explicit user approval bound to role, task, scope, plan and input revision. G3 must pass before BUILD. Use only PASS/BLOCKED progression decisions. Execution ends at evidence handoff and stop; no automatic next role or closure. Commands are subordinate methods, never authority to approve themselves.
