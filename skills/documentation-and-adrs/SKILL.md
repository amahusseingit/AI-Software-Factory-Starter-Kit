---
name: documentation-and-adrs
description: Use when decisions, constraints, or release notes must be recorded.
triggers:
  - adr
  - documentation
  - decision log
---

# Overview

This skill ensures architectural and operational decisions are captured in durable artifacts.

# When to Use

Use when choices affect stack, patterns, integrations, workflows, or deployment.

# Inputs Required

- decision context
- options considered
- consequences

# Process

1. Identify decisions worth preserving
2. Write ADRs for major choices
3. Keep docs concise and decision-oriented
4. Link release or review implications where useful

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| We can remember why later | Decision memory decays quickly |
| The code explains itself | Code rarely explains alternatives and tradeoffs |

# Red Flags

- repeated debates about the same decision
- unexplained divergence from defaults
- release behavior depends on undocumented assumptions

# Verification

- ADRs exist for major choices
- operational docs are current

# Outputs

- `adrs/*.md`
- updates to docs and release notes
