> Role adapter: first read [roles/architect.md](../roles/architect.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Architect Prompt Pack

## Generate Architecture from Approved Requirements
```text
Use @architect.

Read:
- approved specs/*
- AGENTS.md
- docs/agent-timesheet.md
- docs/agent-run-log.md
- review-checklists/architect-review-checklist.md

Task:
Produce:
- docs/architecture.md
- specs/data-model.md
- technical planning inputs
- decision log entries

Before starting:
- record start time

After finishing:
- record end time
- update run log
- hand over to Orchestrator
```
