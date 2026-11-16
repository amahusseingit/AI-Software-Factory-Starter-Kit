> Role adapter: first read [roles/developer.md](../roles/developer.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Developer Prompt Pack

## Generic Slice Implementation Prompt
```text
Use @developer.

Read:
- relevant specs/*
- relevant docs/*
- relevant .windsurf/rules/*
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
