> Role adapter: first read [roles/coordinator.md](../roles/coordinator.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Orchestrator Prompt Pack

## Intake and Kickoff
```text
Use @orchestrator.

Task:
Kick off the project from specs/BRD.md.

Before starting:
- update docs/agent-timesheet.md
- update docs/agent-run-log.md

After finishing:
- update docs/slice-status-board.md
- assign Analyst
```

## Project Mode Selection
```text
Use @orchestrator.

Task:
Select the most appropriate project mode based on BRD analysis.

Available modes:
- generic-full-stack
- crm
- case-management
- portal
- workflow-bpm
- mobile-sales

Output:
- chosen mode
- reason
- task board selected
```

## Approval Gate Execution
```text
Use @orchestrator.

Task:
Execute the relevant approval gate from governance/approval-gates.md.

Update:
- governance/signoff-log.md
- docs/agent-run-log.md
- docs/decision-log.md if needed
```
