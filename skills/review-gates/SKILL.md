---
name: review-gates
description: Use before claiming a module or project is complete.
triggers:
  - review
  - definition of done
  - gate
---

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.


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
5. Review parity only between approved in-scope clients
6. Review tests and evidence
7. Review release-readiness implications
8. Produce PASS/BLOCKED progression decision

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
- PASS/BLOCKED is explicit
- blockers are captured if failed

# Outputs

- `reviews/<module>-review-report.md`
- PASS/BLOCKED decision
