---
name: nfr-selection-and-hardening
description: Use when a project needs non-functional requirements identified, clarified, attached to the plan, and converted into acceptance, evidence, and review gates.
triggers:
  - performance
  - scalability
  - availability
  - security
  - auditability
  - accessibility
  - localization
  - observability
  - disaster recovery
---

# Overview

This skill prevents a project from being treated as complete based only on functional delivery. It selects the relevant non-functional requirement packs, tailors them to the project, and forces them into planning, testing, review, and release readiness.

# When to Use

Use this skill when the spec or stakeholders imply any quality attribute beyond basic functionality, including performance expectations, uptime, resilience, compliance, accessibility, localization, supportability, or operational visibility.

# Inputs Required

- Authoritative project spec under `specs/`
- Intended deployment model and user scale
- Integration and data sensitivity context
- Any known compliance, availability, or support constraints

# Process

1. Review the spec for explicit and implied quality attributes.
2. Select the relevant NFR packs under `packs/`.
3. Turn generic NFR statements into measurable project-specific requirements.
4. Add the selected NFRs to planning, test strategy, traceability, and review scorecards.
5. Ensure release readiness cannot pass while required NFR evidence is missing.

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| We can add performance later | Scale-related defects are expensive to retrofit |
| Security is handled by framework defaults | Defaults are not a substitute for project-specific controls |
| Accessibility is optional | Accessibility may be required and should be considered intentionally |

# Red Flags

- Functional spec with no NFR section
- No measurable targets for performance or availability
- No logging, monitoring, or audit requirements for operational systems
- Review passes without NFR evidence

# Verification

- Relevant NFR packs selected and tailored
- Measurable criteria added to acceptance or release readiness
- Test strategy includes NFR verification where applicable
- Review scorecards reference the chosen NFRs

# Outputs

- NFR selection note
- Project-specific NFR criteria
- Updated plans, tests, and release readiness artifacts
