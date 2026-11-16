---
name: test-strategy-selection
description: Use when choosing the right automated and manual test mix for a project, module, or rescue effort.
triggers:
  - test strategy
  - test planning
  - coverage approach
  - risk-based testing
  - regression scope
---

# Overview

This skill selects the right testing approach for the system shape and risk profile instead of defaulting to shallow or generic test coverage.

# When to Use

Use this skill:
- before planning implementation
- during rescue of an incomplete project
- before review when coverage feels misaligned with risk
- when choosing between unit, integration, workflow, UI, and mutation integrity tests

# Inputs Required

- project spec
- architecture shape
- critical business rules
- integrations and external dependencies
- UI scope and platform scope
- rescue assessment when applicable

# Process

1. Classify the project shape.
2. Identify highest-risk failure modes.
3. Select the most relevant test strategy pack or combination of packs.
4. Define mandatory backend, web, mobile, integration, and regression tests.
5. Map chosen tests into the plan and traceability matrix.
6. Reassess after rescue findings or major scope shifts.

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Unit tests are enough | Many systems fail in workflows, integrations, UI mutation flows, and permissions |
| End-to-end tests will catch everything | They are slower, harder to debug, and insufficient alone |
| We can just write a few smoke tests | Smoke tests do not prove business rule correctness |

# Red Flags

- no explicit project-level test strategy
- CRUD workflows with no mutation integrity tests
- role-sensitive systems with no permission matrix tests
- mobile app with no state transition or offline tests when relevant
- integration-heavy systems with no contract or failure-path tests

# Verification

- selected test strategy pack is documented
- required test types are captured in the plan
- high-risk rules have dedicated tests
- rescue plans include regression scope

# Outputs

- project-level test strategy note
- mapped test expectations per slice or module
- selected strategy packs and rationale
