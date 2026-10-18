> Role adapter: first read [roles/product-owner.md](../roles/product-owner.md). The following detailed prompts are task-planning aids, not permission to execute. Present the selected role plan and stop for explicit user approval.

> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Analyst Prompt Pack

## Generate Structured Requirements from BRD
```text
Use @analyst.

Read:
- specs/BRD.md
- AGENTS.md
- templates/BRD-ANALYSIS-TEMPLATE.md
- templates/USER-STORY-TEMPLATE.md
- templates/TRACEABILITY-TEMPLATE.md
- docs/agent-timesheet.md
- docs/agent-run-log.md

Task:
Generate:
- specs/functional-requirements.md
- specs/non-functional-requirements.md
- specs/acceptance-criteria.md
- specs/api-spec.md
- specs/ui-web-spec.md
- specs/ui-mobile-spec.md
- specs/user-stories.md
- docs/traceability-matrix.md

Before starting:
- record start time

After finishing:
- record end time
- update run log
- hand over to Orchestrator
```
