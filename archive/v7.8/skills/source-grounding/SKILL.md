---
name: source-grounding
description: Use when implementation or fixes must stay anchored to actual source materials.
triggers:
  - grounding
  - source of truth
  - verify against input
---

# Overview

This skill keeps delivery grounded in real source artifacts such as specs, screenshots, contracts, or existing code behavior.

# When to Use

Use when ambiguity exists, when debugging, or when converting external inputs into implementation decisions.

# Inputs Required

- source spec
- screenshots
- diagrams
- existing code or API docs

# Process

1. Collect the source artifacts
2. Identify what is explicit vs inferred
3. Avoid inventing behavior that source material does not support
4. Record assumptions when inference is necessary
5. Trace implementation decisions back to source inputs

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| It probably works this way | Unverified assumptions often create rework |
| The screenshot is enough without workflows | Screens rarely capture all rules and transitions |

# Red Flags

- behavior invented without evidence
- implicit roles or validations
- implementation diverges from source input without ADR

# Verification

- assumptions are explicit
- traceability to source artifacts exists

# Outputs

- grounded interpretation notes
- source-linked acceptance criteria
