---
name: planning-and-task-breakdown
description: Use to convert a specification into verifiable vertical slices.
triggers:
  - plan
  - task breakdown
  - slice plan
  - implementation plan
---

# Overview

This skill converts requirements into atomic, behavior-based slices that can be built and verified safely.

# When to Use

Use after the spec is normalized and before large implementation work begins.

# Inputs Required

- normalized spec
- acceptance criteria
- target stack
- parity expectations

# Process

1. Identify modules and workflows
2. Break work into vertical slices with explicit behavior
3. Map each slice to backend, data, Angular, Flutter, and tests as applicable
4. Add evidence requirements per slice
5. Add review gates per slice
6. Produce a traceability matrix

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| CRUD UI is enough as a task name | Vague names hide incomplete behavior |
| We can figure out tests later | Tests influence slice design and completeness |

# Red Flags

- tasks named by area instead of behavior
- no explicit test responsibilities
- no parity mapping
- no evidence expectations

# Verification

- every slice is behavior-based
- every slice maps to acceptance criteria
- evidence expectations exist
- parity implications are documented

# Outputs

- `plans/<project>-slice-plan.md`
- `plans/<project>-traceability-matrix.md`
