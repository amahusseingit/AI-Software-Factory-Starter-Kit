---
name: debugging-and-recovery
description: Use when behavior is broken, incomplete, or inconsistent with the spec.
triggers:
  - bug fix
  - debug
  - recovery
  - regression
---

# Overview

This skill drives disciplined bug investigation, root-cause identification, and regression protection.

# When to Use

Use for defects, missing implementations, parity drift, or post-review failures.

# Inputs Required

- reported defect
- source behavior
- logs or screenshots
- relevant tests

# Process

1. Reproduce the problem
2. Confirm expected behavior from source materials
3. Form root-cause hypotheses
4. Fix the confirmed cause, not only symptoms
5. Add regression tests
6. Update evidence and review

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| A quick patch is enough | Symptom-only fixes often regress |
| The reviewer can re-test manually | Regression protection still needs tests |

# Red Flags

- bug not reproduced
- fix without root cause
- no regression test
- parity impact ignored

# Verification

- root cause is explicit
- regression test exists
- updated evidence and review exist

# Outputs

- fix notes
- regression tests
- updated evidence and review
