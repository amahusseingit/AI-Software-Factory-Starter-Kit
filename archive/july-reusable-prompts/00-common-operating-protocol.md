# Common Operating Protocol
# AI Software Factory — Emaratech KPI Dashboard

Use this protocol for every role and every implementation slice.

## 1. Mandatory Read Order

Before doing any work, read:

1. `AGENTS.md`
2. The relevant requirement document, for example `problems_sla_dashboard_srs.md`
3. `ai_software_factory_kit_problems_sla/factory/shared-log.md`
4. `ai_software_factory_kit_problems_sla/factory/workflow-protocol.md`
5. The active role `skill.md`
6. Any previous role handoff files referenced in the shared log

## 2. Shared Log Rule

The shared log is the coordination source of truth.

Path:

```text
ai_software_factory_kit_problems_sla/factory/shared-log.md
```

Rules:

- Read it before starting.
- Identify the latest relevant log entries.
- Follow the latest handoff instructions.
- Append new entries.
- Do not overwrite previous entries.
- Mention the log entries read.
- Mention the next expected role.

## 3. Plan-Then-Stop Rule

Every role must first prepare a plan and stop.

Do not execute until the user explicitly approves.

Required closing sentence:

```text
Plan prepared. Waiting for approval before execution.
```

## 4. Execution Rule

After approval:

- Execute only the approved task context.
- Do not expand scope.
- Do not start the next slice.
- Do not perform another role's responsibility.
- Do not introduce unrelated refactoring.
- Update the shared log with evidence and handoff notes.

## 5. Blocking Conditions

Stop and ask for clarification if:

- The shared log does not contain the expected previous handoff.
- The requirement source is missing.
- The story acceptance criteria are missing.
- The architecture handoff is missing for development work.
- The developer handoff is missing for QA work.
- The requested task conflicts with the SRS, PO story, or architecture design.
- Build/test commands cannot be identified.
- The repo structure does not match assumptions.

## 6. Standard Output Sections

Every role plan should include:

1. Role and task scope.
2. Inputs read.
3. Latest shared-log entries reviewed.
4. Understanding of current state.
5. Proposed plan.
6. Files to inspect.
7. Files expected to change, if applicable.
8. Tests or validation expected, if applicable.
9. Risks and assumptions.
10. Stop gate.

## 7. Standard Shared Log Entry

Append this structure:

```markdown
---

## LOG-XXX — <Short Title>

**Date/Time:** <YYYY-MM-DD HH:mm>  
**Role:** <Role>  
**Task Context:** <Short context>  
**Status:** <Plan Prepared | Completed | Blocked | Failed>  
**Previous Logs Read:** <LOG IDs>  
**Next Role:** <Expected next role>  

### 1. Inputs Read

- <File/log>

### 2. Work Completed

- <Summary>

### 3. Decisions Made

- <Decision>

### 4. Assumptions

- <Assumption>

### 5. Files Inspected

- `<path>`

### 6. Files Changed

- `<path>`

### 7. Commands Executed

```bash
<command>
```

### 8. Test / Validation Evidence

- <Evidence>

### 9. Risks / Open Issues

- <Risk>

### 10. Handoff Notes

- <Notes for next role>
```
