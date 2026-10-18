---
name: security-and-hardening
description: Use for auth, sessions, sensitive data, externally exposed APIs, or high-risk flows.
triggers:
  - security
  - auth
  - hardening
  - sensitive data
---

# Overview

This skill adds security-focused checks and safer implementation decisions to sensitive areas.

# When to Use

Use whenever the module touches auth, authorization, tokens, personal data, external APIs, or session logic.

# Inputs Required

- auth model
- roles
- data sensitivity
- external integrations

# Process

1. Identify the security-sensitive surfaces
2. Verify auth and authorization requirements
3. Verify token/session handling
4. Verify input validation and error handling
5. Verify secret handling and configuration safety
6. Add security review notes

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| This is only an internal app | Internal apps still expose security and audit risk |
| The framework handles everything | Framework defaults do not replace explicit design |

# Red Flags

- missing ownership checks
- refresh tokens without lifecycle controls
- hardcoded secrets
- unsafe verbose errors

# Verification

- security-sensitive decisions are explicit
- authorization rules are enforced
- review notes exist

# Outputs

- security notes in review and release artifacts
