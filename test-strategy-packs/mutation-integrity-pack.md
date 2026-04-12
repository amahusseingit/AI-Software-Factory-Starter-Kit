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
