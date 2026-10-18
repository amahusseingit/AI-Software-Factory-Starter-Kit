---
name: review-gates
description: Use before claiming a module or project is complete.
triggers:
  - review
  - definition of done
  - gate
---

# Overview

This skill applies multi-axis quality gates and blocks premature completion.

# When to Use

Use during REVIEW and before SHIP.

# Inputs Required

- spec
- plan
- implementation
- tests
- evidence

# Process

1. Review against the spec
2. Review functional completeness
3. Review business rules and persistence
4. Review stack conformance
5. Review Angular and Flutter parity
6. Review tests and evidence
7. Review release-readiness implications
8. Produce pass/fail outcome

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The reviewer can infer the rest | Review must inspect implemented behavior, not hope |
| It is good enough for now | In-scope work must meet declared acceptance criteria |

# Red Flags

- dead actions
- partial CRUD marked complete
- stack drift
- missing tests
- missing parity
- missing evidence

# Verification

- review report exists
- pass/fail is explicit
- blockers are captured if failed

# Outputs

- `reviews/<module>-review-report.md`
- pass/fail decision
