# Developer Prompt Pack

## Generic Slice Implementation Prompt
```text
Use @developer.

Read:
- relevant specs/*
- relevant docs/*
- relevant rules/*
- relevant slice-libraries/*
- docs/agent-timesheet.md
- docs/agent-run-log.md
- docs/slice-status-board.md

Task:
Implement the approved slice only.

Before starting:
- record start time
- mark slice In Progress

Constraints:
- implement only this slice
- no unrelated refactoring
- preserve architecture boundaries

After finishing:
- record end time
- mark slice Under Review
- provide validation steps
- hand over to Reviewer
```
