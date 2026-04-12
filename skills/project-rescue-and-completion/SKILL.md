---
name: project-rescue-and-completion
description: Use when a project already exists but is incomplete, partially generated, inconsistent, or needs recovery from shallow implementation.
---

# Overview

This skill is for rescuing systems that look presentable but are not behaviorally complete.

# When to Use
- partially generated projects
- CRUD screens with missing handlers
- stack drift from the required platform
- Angular and Flutter parity gaps
- TODOs inside in-scope behavior
- evidence and tests are weak or missing

# Inputs Required
- authoritative spec
- current source code
- known defects or gap reports
- required stack
- scope boundaries

# Process
1. Confirm authoritative source material
2. Build rescue assessment report
3. Build stack conformance report
4. Build UI action inventory
5. Build parity report
6. Re-slice remaining work by behavior
7. Implement and test module by module
8. Re-run review gates
9. Produce rescue closure report

# Rationalizations to Reject
| Excuse | Why invalid |
|---|---|
| The button is visible so the screen is mostly done | Visible UI without behavior is incomplete |
| We can fix mobile later | Parity cannot be deferred for in-scope features |
| The API exists so the screen is basically done | UI mutation flow, validation, and feedback are still required |
| Tests compile so quality is fine | Tests must prove behavior, not existence |

# Red Flags
- TODO add dialog later
- placeholder floating action buttons
- service methods unused by the screen
- save without persistence
- delete without refresh
- list exists but no create/edit/delete
- wrong database provider

# Verification
- rescue artifacts exist
- missing actions are either implemented or explicitly removed
- in-scope mutations work end to end
- parity and stack conformance reports are updated
- review gates passed

# Outputs
- rescue assessment
- rescue slice plan
- parity report
- updated evidence and review reports
