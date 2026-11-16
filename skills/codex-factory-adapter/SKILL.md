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

1. Read `AGENTS.md`, `ORCHESTRATOR.md`, `governance/protocol.md`,
   `governance/security-policy.md` and `governance/gate-contract.json`.
2. Classify the project and request.
3. Select the lifecycle entry command.
4. Load the mandatory and situational skills for that command.
5. Confirm required inputs and artifacts.
6. State the approval boundary before implementation.
7. Use `templates/role-plan-template.md` for the current role and
   `templates/role-handoff-template.md` after approved execution. Stop at handoff.

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
- Task/AC IDs, scope and plan hashes, input/output revisions, approval source,
  named executor and independently identified QA/reviewer

## Role invocation

Use the maintained playbooks in `roles/README.md`; `agents/role-registry.md`
only maps older role aliases. Do not rely on an
unsupported `@role` command. A role is a governed responsibility and handoff
contract, not permission to bypass approval or review independence.

## Prohibited shortcuts

- implementation without a valid entry command
- BUILD without the required spec and planning artifacts
- REVIEW without verification evidence
- SHIP without review outputs
- self-approval of implementation work
- silent assumptions or untracked domain rules

## Authority and evidence

Use only PASS/BLOCKED progression decisions and canonical mandatory check states.
Require a separately approved scope/revision-bound plan for every role, including
QA, remediation, regression, security review and closure. A new role label is
not an independent actor. No automatic successor execution or closure.
CRITICAL findings cannot be accepted; HIGH exceptions follow the security policy.
Document validators prove documentation and synthetic record behavior only.

## Discovery

The repository discovery shim is `.agents/skills/factory/SKILL.md`.
Load this adapter and specialist workflows by explicit file paths after routing.
No global skill installation or user configuration is needed.
