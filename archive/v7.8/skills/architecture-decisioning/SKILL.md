---
name: architecture-decisioning
description: Use when the project needs explicit architectural decisions captured, compared, and justified through ADRs before or during implementation.
triggers:
  - architecture decision
  - monolith or microservices
  - caching
  - auth strategy
  - background jobs
  - tenancy
  - offline sync
---

# Overview

This skill converts major design choices into explicit Architecture Decision Records using reusable decision packs and decision templates.

# When to Use

Use this skill when architecture choices affect implementation structure, operational behavior, integration boundaries, data ownership, scalability, or security posture.

# Inputs Required

- Project spec
- Constraints and assumptions
- Current architecture baseline if the project is an enhancement or rescue effort

# Process

1. Identify the decisions that materially affect the build.
2. Select the relevant ADR packs under `adr-packs/`.
3. Compare options and document tradeoffs.
4. Record chosen options using the ADR template.
5. Propagate the decisions into plans, implementation guidance, and review gates.

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| We can decide this while coding | Hidden architectural drift creates inconsistency |
| The default framework pattern is good enough | Defaults may not fit scale, security, or maintainability needs |

# Red Flags

- Different modules implying different architecture models without explicit approval
- Auth, caching, or background-job behavior implemented without ADRs
- Rescue efforts changing architecture implicitly

# Verification

- Relevant ADRs created
- Key decisions have alternatives and rationale recorded
- Plans and review artifacts reference the chosen architecture

# Outputs

- ADR files under `adrs/`
- Decision summary for the project
- Updated implementation and review guidance
