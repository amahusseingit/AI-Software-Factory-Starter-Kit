> Role adapter: first read [roles/independent-reviewer.md](../roles/independent-reviewer.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Reviewer Prompt Pack

## Generic Slice Review Prompt
```text
Use @reviewer.

Read:
- relevant specs/*
- relevant .windsurf/rules/*
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
- final recommendation: PASS / BLOCKED

Before starting:
- record start time

After finishing:
- record end time
- update review summary
- update slice status
```
