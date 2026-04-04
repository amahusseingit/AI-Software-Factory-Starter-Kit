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
