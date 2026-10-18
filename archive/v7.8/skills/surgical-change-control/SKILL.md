---
name: surgical-change-control
description: Use when modifying an existing codebase, rescuing incomplete output, or applying targeted fixes where collateral changes should be minimized.
---

# Overview

This skill keeps changes proportional to the request. It minimizes unrelated edits, avoids opportunistic refactors, and preserves local consistency unless a broader refactor is explicitly required.

# When to Use

Use this skill when:
- applying bug fixes
- rescuing incomplete generated systems
- repairing one module in a larger codebase
- implementing small or medium scoped enhancements
- updating files where churn should stay reviewable

# Inputs Required

- exact problem statement or requested change
- impacted modules/files
- existing local conventions
- known regression risk areas

# Process

1. Define the exact requested outcome.
2. Identify the smallest set of files and code paths required.
3. Avoid unrelated formatting churn and broad cleanup.
4. Match existing style unless there is an explicit refactor goal.
5. Remove only artifacts made obsolete by the current change.
6. Link every changed area to the request, a defect, or a review issue.
7. Expand scope only when required for correctness, safety, or testability.

# Rationalizations to Reject

- “While I’m here, I should clean up this whole module.”
- “This is a good time to refactor everything.”
- “I’ll reformat unrelated files for consistency.”
- “I added flexibility we may need later.”

# Red Flags

- many changed files without direct linkage to the request
- new abstractions for one-time logic
- broad style churn masking a targeted fix
- rescue work that quietly turns into a rewrite without decision logging

# Verification

- change scope is traceable to the request
- unrelated modules were not touched without reason
- regression scope is explicitly stated
- review diff remains explainable and focused

# Outputs

- change scope note
- impacted files list
- regression scope note
