---
name: spec-quality-analysis
description: Use when evaluating whether a project specification is complete and reliable enough for planning or implementation.
triggers:
  - analyze spec
  - spec quality
  - are requirements enough
  - requirements gap analysis
  - review project spec
---

# Overview

This skill evaluates whether the project specification is strong enough to drive accurate planning and implementation. It is used before BUILD work begins and whenever the source requirements are incomplete, visual, fragmented, or potentially ambiguous.

# When to Use

Use this skill when:
- a new project spec is introduced
- the project starts from Word, PDF, screenshots, Figma exports, or rough notes
- requirements feel high-level, inconsistent, or underspecified
- there is uncertainty about workflows, roles, validations, or integrations
- a weak or incomplete build needs root-cause analysis back to the spec quality

# Inputs Required

- Authoritative project spec path under `specs/`
- Any supporting visual or reference artifacts
- Known stack and architectural constraints
- Any existing acceptance criteria or business rules

# Process

1. Confirm the authoritative spec path.
2. Evaluate the spec against the checklist in `references/spec-quality-checklist.md`.
3. Score each major area using `templates/spec-readiness-scorecard-template.md`.
4. Record missing sections, ambiguities, assumptions, and risk areas using `templates/spec-gap-report-template.md`.
5. Recommend one of the following:
   - proceed
   - proceed with warnings
   - block until improved
6. If the spec includes screenshots or UI assets, instantiate the relevant UI templates before planning.

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| We can fill workflow details later | Weak workflow definitions create weak implementations and hidden rework |
| The spec is good enough because it names the screens | Screen names without actions, validations, and transitions are not implementation-ready |
| We can build first and clarify later | This creates avoidable rescue work and incomplete behavior |

# Red Flags

- Missing actors or roles
- Missing end-to-end workflows
- Missing business rules
- Missing validation rules
- Missing data ownership or authorization rules
- Missing integration definitions
- Missing acceptance criteria
- Contradictions between text and visual artifacts
- Open questions not explicitly captured

# Verification

A spec is review-ready only when:
- the scorecard is completed
- all critical gaps are listed
- blocking issues are identified
- the proceed / block recommendation is explicit

# Outputs

- `reviews/spec-gap-report.md`
- `reviews/spec-readiness-scorecard.md`
- optional instantiated UI workflow templates
