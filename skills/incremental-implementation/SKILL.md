---
name: incremental-implementation
description: Use to build one verifiable slice at a time.
triggers:
  - build
  - implement feature
  - slice delivery
---

# Overview

This skill forces vertical slice implementation and blocks shell-first delivery.

# When to Use

Use during BUILD for any feature, module, or integration slice.

# Inputs Required

- slice definition
- API/data plan
- UI flows
- validations
- tests to implement

# Process

1. Implement backend behavior and persistence
2. Implement Angular behavior if in scope
3. Implement Flutter behavior if in scope
4. Add validations and UI states
5. Add tests
6. Produce evidence
7. Do not move to the next slice until this slice is reviewable

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The list screen is enough for now | Incomplete CRUD creates false completion |
| The button is visible so we can add behavior later | Visible dead actions are defects |

# Red Flags

- TODO in in-scope action handlers
- create without validation
- edit without preloaded data
- delete without refresh
- one client implemented, the other silently missing

# Verification

- slice works end to end
- in-scope clients are aligned
- tests exist
- evidence exists

# Outputs

- working vertical slice
- tests
- evidence file


## V7.7 Discipline

Implementation should prefer the minimum code and structure needed for the current requirement. Avoid speculative abstractions, broad cleanup, and unrequested extensibility.
