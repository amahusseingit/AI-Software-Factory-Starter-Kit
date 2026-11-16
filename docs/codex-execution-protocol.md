# Using the Factory with Codex

Start in a checkout with AGENTS.md and run the local checks from VALIDATION.md.
Select the repository skill `factory` or explicitly ask Codex to read
skills/codex-factory-adapter/SKILL.md. Repository skill discovery uses
`.agents/skills/factory/SKILL.md`, per the
[official skill documentation](https://learn.chatgpt.com/docs/build-skills).
The active session may need a refresh before a newly added skill appears;
explicit file loading remains available.

The adapter routes to maintained roles under roles/. Historical @developer,
@tester and @orchestrator text is an alias, not a tool call or approval.
Every role uses the canonical scope/revision-bound approval and handoff contract.
Use templates/role-plan-template.md and templates/role-handoff-template.md.

## First consuming project

1. Identify the authoritative requirements and approved architecture inputs.
2. Select a project profile explicitly and record clients and integrations in scope.
3. Present a DEFINE/SPEC plan and obtain its approval before producing deliverables.
4. Establish acceptance criteria, traceability, architecture, test strategy and G1/G2.
5. Approve one vertical slice and its actual task branch/base before G3/BUILD.
6. Obtain independent QA, review and security disposition on the resulting revision.
7. Keep release, merge, deployment and closure as separately authorized actions.

Factory documentation tests do not replace application build/security/runtime
evidence. A missing project SRS blocks application implementation, not generic
Factory validation. Scope checks through the canonical protocol; never invent
requirements, approval IDs or an independent reviewer identity.
