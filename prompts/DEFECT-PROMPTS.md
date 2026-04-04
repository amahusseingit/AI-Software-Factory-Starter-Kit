# Defect Prompt Pack

## Create Defect Resolution Flow
```text
Use @orchestrator.

Task:
Create a defect-fix slice for a logged defect from docs/defect-log.md.

Update:
- docs/slice-status-board.md
- docs/agent-timesheet.md
- docs/agent-run-log.md
```

## Apply Minimal Fix
```text
Use @developer.

Task:
Apply the smallest safe fix for the approved defect slice.

Constraints:
- no unrelated refactoring
- preserve architecture
- provide validation steps
```
