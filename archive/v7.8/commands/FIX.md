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
