> Role adapter: first read [roles/qa.md](../roles/qa.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Tester Prompt Pack

## Generate / Update Test Plan
```text
Use @tester.

Read:
- relevant specs/*
- docs/planning.md
- docs/integration-test-plan.md
- docs/traceability-matrix.md
- docs/agent-timesheet.md
- docs/agent-run-log.md

Task:
Create or update the integration test plan for the implemented scope.

Before starting:
- record start time

After finishing:
- record end time
- update run log
```

## Generate Tests for Approved Scope
```text
Use @tester.

Read:
- relevant specs/*
- docs/integration-test-plan.md
- docs/traceability-matrix.md
- docs/agent-timesheet.md
- docs/agent-run-log.md
- .windsurf/rules/testing-standards.md

Task:
Generate tests for the approved scope.

Constraints:
- include negative cases
- avoid trivial assertions
- maintain behavior focus

Before starting:
- record start time

After finishing:
- record end time
- update run log
- record defects if found
```
