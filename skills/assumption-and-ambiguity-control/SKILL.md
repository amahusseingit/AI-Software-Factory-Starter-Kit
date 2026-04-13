---
name: assumption-and-ambiguity-control
description: Use when requirements, behavior, integrations, or constraints have multiple plausible interpretations and silent guessing would create delivery risk.
---

# Overview

This skill prevents silent guessing. It requires ambiguity detection, explicit assumption logging, alternative interpretation surfacing, and a conscious decision about whether work can proceed safely.

# When to Use

Use this skill when:
- the spec is incomplete, inconsistent, or underspecified
- there are multiple plausible interpretations
- workflows, validations, or business rules are unclear
- the requested stack, integration, or operating constraints are uncertain
- rescue work reveals contradictory code and requirement intent

# Inputs Required

- authoritative spec path
- related notes, screenshots, or reference documents
- current implementation state if rescue work is involved
- explicit constraints already known

# Process

1. Identify ambiguity points.
2. For each ambiguity, write:
   - ambiguous statement
   - plausible interpretations
   - delivery risk if guessed incorrectly
3. Decide whether the ambiguity is:
   - blocking
   - non-blocking but assumption-sensitive
   - low-risk and operationally safe to proceed with a stated assumption
4. Record assumptions in a project assumptions log or spec-gap report.
5. If proceeding, ensure downstream planning and implementation explicitly reference the chosen assumption.
6. Revisit assumptions during review and rescue if new evidence appears.

# Rationalizations to Reject

- “It is probably fine.”
- “The AI can infer what they meant.”
- “We can correct it later if needed.”
- “The UI makes the intent obvious.”

# Red Flags

- conflicting terms used interchangeably
- unclear delete vs deactivate behavior
- unclear ownership or authorization rules
- unclear stack or integration requirements
- workflows with missing branching logic

# Verification

- ambiguities are explicitly listed
- assumptions are written down
- blocking ambiguities are not silently bypassed
- plans and slices reference the chosen assumptions

# Outputs

- assumptions log
- ambiguity register or spec-gap section
- clarified planning notes
