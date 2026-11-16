---
name: using-starter-kit
description: Use when beginning any work inside ProjectStarterKit V7.
triggers:
  - start project
  - new kit run
  - workflow selection
---

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.


# Overview

This skill ensures the kit is used as a governed system rather than as an unstructured prompt folder.

# When to Use

Use at the start of any new project, major feature, or rescue effort.

# Inputs Required

- authoritative project spec
- stack expectations
- known constraints

# Process

1. Read `AGENTS.md`
2. Identify the authoritative spec under `specs/`
3. Identify lifecycle phase
4. Activate the relevant skills
5. Define required artifacts before coding begins
6. Record any unclear assumptions explicitly

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| I can just improvise the process | V7 depends on explicit routing and evidence |
| The templates are enough as inputs | Templates are scaffolds, not project truth |

# Red Flags

- no spec under `specs/`
- work starts from a template instead of a project file
- coding starts before planning artifacts exist

# Verification

- lifecycle phase is identified
- relevant skills are selected
- authoritative spec path is clear

# Outputs

- selected skill set
- initial project artifact map
- explicit source-of-truth reference

## Unified approval and closure contract
Read governance/protocol.md. G3 precedes BUILD. TEST is the VERIFY command alias. Independent QA follows developer tests and precedes acceptance. Every role, including the coordinator closing a task, needs its own explicit user-approved scope/revision-bound plan. Append only a planning record before approval; no substantive execution. Canonical progression is PASS/BLOCKED; mandatory nonPASS checks block. After handoff or approved closure, stop.
