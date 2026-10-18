---
name: cross-platform-parity
description: Use when web and mobile are both in scope.
triggers:
  - parity
  - web and mobile
  - angular flutter
---

# Overview

This skill prevents web/mobile divergence for in-scope behavior and makes differences explicit and reviewable.

# When to Use

Use during PLAN, BUILD, VERIFY, and REVIEW whenever Angular and Flutter are both expected to support the same module.

# Inputs Required

- module scope
- web screens
- mobile screens
- validations
- role rules

# Process

1. List in-scope modules for both clients
2. Compare screen and behavior coverage
3. Compare validations and visibility rules
4. Compare loading, empty, error, and success states
5. Record approved differences explicitly
6. Add parity evidence

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Mobile will catch up later | That is parity drift unless approved |
| The clients do not need to match exactly | Differences must be deliberate and documented |

# Red Flags

- feature exists on one client only
- validation differs silently
- auth/session differs silently
- missing parity evidence

# Verification

- parity map exists
- approved differences are explicit
- parity evidence exists

# Outputs

- parity section in plan, evidence, and review
