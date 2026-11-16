---
name: spec-driven-delivery
description: Use when turning requirements into an implementation-ready specification.
triggers:
  - spec
  - requirements
  - user stories
  - brd
  - workflows
---

# Overview

This skill ensures implementation starts from a clear, authoritative, implementation-ready specification.

# When to Use

Use when a project begins or when major new scope is introduced.

# Inputs Required

- authoritative project spec
- workflows or source stories
- roles
- validations
- business rules
- integrations
- constraints

# Process

1. Confirm the source-of-truth spec file under `specs/`
2. Normalize the spec into clear sections
3. Add workflows and alternate flows if missing
4. Add screen/module inventory
5. Add validations, integrations, and business rules
6. Add acceptance criteria
7. Record unresolved decisions in open items or ADRs

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The story titles are enough | Titles are not implementation-ready requirements |
| We can infer the workflows later | Missing workflows cause wrong UI and API behavior |

# Red Flags

- no workflows
- no validations
- no role visibility rules
- no API integration expectations
- no acceptance criteria

# Verification

- normalized spec exists
- open items are explicit
- workflows and alternate flows are documented
- acceptance criteria exist for each major behavior

# Outputs

- `specs/<project>-spec.md`
- optional ADRs
- spec quality gaps list
