---
name: auth-jwt-refresh-google-signin
description: Use when implementing local auth, JWT, refresh token flows, or Google Sign-In.
triggers:
  - auth
  - jwt
  - refresh token
  - google sign in
---

# Overview

This skill governs secure, supportable authentication and session behavior across backend, web, and mobile.

# When to Use

Use whenever registration, login, verification, session refresh, logout, password reset, or Google auth is in scope.

# Inputs Required

- auth requirements
- roles
- token lifetimes
- session rules
- external auth requirements

# Process

1. Define auth flows and boundaries
2. Implement backend auth endpoints and token rules
3. Implement route/session guards on clients
4. Implement refresh, logout, and revocation behavior
5. Implement Google Sign-In if in scope
6. Add tests and evidence

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Access token alone is enough | Session longevity and revocation rules still matter |
| Google login can be stubbed | External auth paths must be explicit if in scope |

# Red Flags

- no refresh token lifecycle
- insecure local storage decisions without thought
- missing role/ownership enforcement
- mobile/web session drift

# Verification

- auth flows work end to end
- refresh behavior is explicit
- route/session behavior is aligned
- tests and evidence exist

# Outputs

- auth implementation
- auth tests
- evidence file
