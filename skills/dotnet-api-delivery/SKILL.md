---
name: dotnet-api-delivery
description: Use when implementing ASP.NET Core APIs and services.
triggers:
  - dotnet api
  - asp.net core
  - web api
---

# Overview

This skill guides implementation of maintainable ASP.NET Core APIs with correct separation of concerns and testability.

# When to Use

Use during BUILD for backend APIs, service logic, auth flows, and integration endpoints.

# Inputs Required

- API contract
- data model
- business rules
- auth rules

# Process

1. Implement endpoints aligned to the API contract
2. Keep orchestration, business logic, and persistence concerns separated
3. Apply validation and authorization
4. Implement audit updates where required
5. Add tests for business-critical behavior
6. Record evidence

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Putting everything in the controller is faster | It damages maintainability and testability |
| UI validation is enough | API validation is mandatory |

# Red Flags

- fat controllers
- missing authorization checks
- API accepts invalid state transitions
- persistence side effects untested

# Verification

- endpoints work as specified
- tests exist
- evidence exists for business-critical mutations

# Outputs

- API implementation
- backend tests
- evidence file
