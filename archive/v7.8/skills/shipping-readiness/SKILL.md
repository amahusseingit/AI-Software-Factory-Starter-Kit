---
name: shipping-readiness
description: Use to prepare completed work for deployment and support.
triggers:
  - ship
  - release
  - deploy
---

# Overview

This skill packages delivery into something that can be deployed, tested, rolled back, and supported.

# When to Use

Use after review passes or as part of final release planning.

# Inputs Required

- reviewed implementation
- migrations
- configuration changes
- environment notes

# Process

1. Identify scope included in the release
2. List environment changes and migration requirements
3. Define deployment order
4. Define rollback plan
5. Define smoke test checks
6. Record known risks and monitoring points

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Deployment details can be figured out by ops | Application changes often require app-specific notes |
| Rollback is obvious | Rollback must be explicit before release |

# Red Flags

- no migration notes
- no smoke test path
- no rollback notes
- hidden config dependencies

# Verification

- release-readiness document exists
- deployment and rollback notes are explicit

# Outputs

- `releases/<release>-readiness.md`
