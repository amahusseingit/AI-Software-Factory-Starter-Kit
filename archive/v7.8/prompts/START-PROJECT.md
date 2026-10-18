# Start Project Prompt

```text
/start-project-from-brd

Read:
- AGENTS.md
- ORCHESTRATOR.md
- specs/BRD.md
- docs/agent-timesheet.md
- docs/agent-run-log.md
- docs/slice-status-board.md
- docs/planning.md
- governance/approval-gates.md
- governance/signoff-log.md
- governance/raci-matrix.md
- templates/BRD-ANALYSIS-TEMPLATE.md
- templates/TRACEABILITY-TEMPLATE.md

Use:
@orchestrator

Execution sequence:
1. Kickoff and log intake
2. Trigger Analyst to generate requirements, user stories, and traceability base
3. Run G1 requirements approval gate
4. Trigger Architect for architecture and data model
5. Run G2 architecture approval gate
6. Select project mode and task board
7. Plan slices and update board
8. Trigger Developer for first approved slice
9. Trigger Reviewer after each implementation slice
10. Trigger Tester once implemented scope is ready
11. Run defect loop as needed
12. Run G3 / G4 / G5 as applicable
13. Close via completion gate

Mandatory:
- every role updates timesheet and run log
- every slice updates status board
- every review returns GO / GO WITH MINOR FIXES / REVISE
```
