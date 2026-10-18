# Reviewer Prompt Pack

## Generic Slice Review Prompt
```text
Use @reviewer.

Read:
- relevant specs/*
- relevant rules/*
- changed files
- docs/agent-timesheet.md
- docs/agent-run-log.md
- docs/slice-status-board.md
- docs/review-summary.md
- relevant review-checklists/*

Task:
Review the slice.

Output:
- issues by severity
- top 3 risks
- exact recommendations
- final recommendation: GO / GO WITH MINOR FIXES / REVISE

Before starting:
- record start time

After finishing:
- record end time
- update review summary
- update slice status
```
