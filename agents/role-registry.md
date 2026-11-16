# Role aliases

[roles/README.md](../roles/README.md) is the maintained role registry.
[Protocol](../governance/protocol.md), [security policy](../governance/security-policy.md)
and [gate contract](../governance/gate-contract.json) control all decisions.
These aliases preserve older prompts; they grant no execution or approval.

| Historical alias | Maintained playbook |
|---|---|
| Orchestrator | [Coordinator](../roles/coordinator.md) |
| Analyst | [Product Owner](../roles/product-owner.md) |
| Architect / Planner | [Architect](../roles/architect.md) |
| Developer | [Developer](../roles/developer.md) |
| Tester | [QA](../roles/qa.md) |
| Reviewer | [Independent reviewer](../roles/independent-reviewer.md) |
| Security Auditor | [Security reviewer](../roles/security-reviewer.md) |
| Release Readiness Reviewer | [Release owner](../roles/release-owner.md) |

Remediation and regression use their dedicated playbooks in roles/.
Use PASS/BLOCKED decisions. Each role requires its own approved plan;
changing a role label does not establish an independent actor.
