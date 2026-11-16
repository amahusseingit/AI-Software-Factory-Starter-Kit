> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Mutation Integrity Test Strategy Pack

Use when updates, reversals, calculations, balances, inventory, counters, or cumulative side effects matter.

## Focus
- forward mutation correctness
- edit recalculation correctness
- delete/reverse correctness
- duplicate prevention
- concurrent or repeated action safety where relevant

## Minimum expectations
- deterministic backend tests for mutation rules
- negative tests for invalid transitions
- regression tests for repaired side-effect bugs
