---
name: test-enforcement
description: Use whenever behavior is implemented or fixed.
triggers:
  - tests
  - verification
  - coverage
---

# Overview

This skill ensures meaningful automated tests exist for critical behavior and regressions.

# When to Use

Use during BUILD, VERIFY, and FIX.

# Inputs Required

- acceptance criteria
- implemented behavior
- known failure paths

# Process

1. Identify critical business behaviors
2. Write or update backend tests
3. Write or update Angular tests where web is in scope
4. Write or update Flutter tests where mobile is in scope
5. Cover negative and mutation paths
6. Record test evidence

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The backend tests are enough | UI and client behavior also matter |
| We can add tests after demo | Missing tests allow regressions and hide incomplete work |

# Red Flags

- tests only cover list loading
- no mutation tests
- no validation tests
- no regression tests for fixed defects

# Verification

- create/edit/delete or equivalent critical flows are covered
- validation failures are covered
- regression risk is addressed
- test evidence is recorded

# Outputs

- backend, Angular, and Flutter test updates as applicable
- test evidence summary
