---
name: api-contract-design
description: Use to design or refine backend API contracts before implementation.
triggers:
  - api
  - contract
  - endpoint
  - request response
---

# Overview

This skill turns workflows into clear, testable API contracts.

# When to Use

Use during DEFINE and PLAN for systems with backend APIs or external integrations.

# Inputs Required

- workflows
- actors
- validations
- error rules
- authorization rules

# Process

1. Identify operations by workflow
2. Define request and response models
3. Define status codes and validation failures
4. Define authorization requirements
5. Define idempotency needs where retries or duplicate submissions matter
6. Record the contract

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The UI can drive the API later | Unplanned APIs often mismatch workflows |
| The endpoint shape is obvious | Edge cases and failure models are not obvious |

# Red Flags

- ambiguous request/response models
- no validation error model
- no authorization notes
- retry risk without idempotency thought

# Verification

- API spec exists
- endpoints map to workflows
- errors and auth are explicit

# Outputs

- API contract notes or spec updates
