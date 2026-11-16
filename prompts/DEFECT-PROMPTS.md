> Role adapter: first read [roles/remediation.md](../roles/remediation.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

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
