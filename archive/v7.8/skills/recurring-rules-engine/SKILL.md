---
name: recurring-rules-engine
description: Use for recurring financial or scheduled transaction logic.
triggers:
  - recurrence
  - recurring rule
  - scheduler
  - financial logic
---

# Overview

This skill ensures recurring logic is modeled safely with duplicate prevention and correct balance impact.

# When to Use

Use when the system has recurring records, subscriptions, reminders, periodic tasks, or generated schedule-based data.

# Inputs Required

- recurrence rules
- generation schedule
- duplicate prevention requirements
- balance or state impact rules

# Process

1. Model recurring rule fields and statuses
2. Define generation cadence and due logic
3. Define duplicate-cycle prevention
4. Define mutation impact on balances or state
5. Add tests for edit, pause, resume, delete, and generate operations

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| A simple cron is enough | Generation correctness and duplicate protection still matter |
| We can ignore edit edge cases | Recurrence edits often cause hidden duplication or missed cycles |

# Red Flags

- no duplicate prevention
- no tests for edit/delete/pause
- hidden balance side effects

# Verification

- one-cycle-only behavior is proven
- edits and deletions behave correctly
- tests cover the risky paths

# Outputs

- recurring logic notes
- tests
- evidence file
