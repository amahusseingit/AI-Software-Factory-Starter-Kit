---
name: traceability-governance
description: Use when a project needs reliable linkage from requirements through implementation, tests, evidence, and review outcomes.
triggers:
  - traceability
  - requirement mapping
  - business rule matrix
  - evidence linkage
  - enterprise governance
---

# Overview

This skill prevents loss of intent between the project spec and the delivered system. It ensures that each in-scope requirement, acceptance criterion, and business rule can be traced to implementation, tests, and proof.

# When to Use

Use this skill when:
- starting a new project
- planning complex features
- rescuing a partially generated system
- preparing for enterprise review or audit
- business rules affect calculations, permissions, orchestration, or data mutation integrity

# Inputs Required

- authoritative project spec under `specs/`
- acceptance criteria
- slice plan
- selected test strategy
- evidence and review artifact paths

# Process

1. Identify the authoritative requirement set.
2. Break requirements into traceable rows.
3. Map each row to one or more acceptance criteria.
4. Identify business rules that require separate verification.
5. Map each row to planned implementation areas.
6. Map each row to planned tests.
7. Map each row to evidence artifacts and review scorecards.
8. Maintain the matrix as the project evolves.
9. Fail the review gate if high-risk rows are missing tests or evidence.

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The requirement is obvious from the screen | Screens do not capture rules, validations, and failure paths fully |
| We can fill the matrix later | Late traceability creates blind spots and weak reviews |
| Tests do not need requirement linkage | Unlinked tests are harder to trust and maintain |

# Red Flags

- requirements with no acceptance criteria
- business rules with no dedicated verification row
- tests that exist but are not mapped to any requirement
- evidence files that cannot be linked to implemented behavior
- parity rows missing mobile or web mapping for in-scope features

# Verification

- traceability matrix exists and is current
- business rule verification matrix exists when rules are non-trivial
- critical rows map to implementation, tests, and evidence
- review outcomes reference traceability rows where applicable

# Outputs

- populated traceability matrix
- populated business rule verification matrix when needed
- traceability-related review notes
