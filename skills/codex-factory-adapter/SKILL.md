---
name: codex-factory-adapter
description: Use when Codex must route work through the Factory lifecycle, skills, roles, artifacts, and approval gates.
triggers:
  - Codex Factory
  - role routing
  - handoff
  - Factory readiness
---

# Codex Factory Adapter

This adapter translates a Codex request into the existing Factory operating
model. It does not replace `AGENTS.md`, `ORCHESTRATOR.md`, commands, or
specialist skills.

## Required routing sequence

1. Read `AGENTS.md` and `ORCHESTRATOR.md`.
2. Classify the project and request.
3. Select the lifecycle entry command.
4. Load the mandatory and situational skills for that command.
5. Confirm required inputs and artifacts.
6. State the approval boundary before implementation.
7. Return a handoff contract using `templates/handoff-contract-template.md`.

## Codex execution contract

Every routed task must identify:

- Role
- Lifecycle phase
- Entry command
- Inputs read
- Active skills
- Expected outputs
- Approval gate
- Handoff target
- Blockers and assumptions

## Role invocation

Use the role registry in `agents/role-registry.md`. Do not rely on an
unsupported `@role` command. A role is a governed responsibility and handoff
contract, not permission to bypass approval or review independence.

## Prohibited shortcuts

- implementation without a valid entry command
- BUILD without the required spec and planning artifacts
- REVIEW without verification evidence
- SHIP without review outputs
- self-approval of implementation work
- silent assumptions or untracked domain rules
