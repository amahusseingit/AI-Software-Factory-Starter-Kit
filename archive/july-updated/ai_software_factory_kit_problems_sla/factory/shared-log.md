# Shared Factory Log
# Problems SLA Dashboard

**Instruction:** Append only. Do not overwrite previous entries.

---

## Mandatory Agent Loop Enforcement

Every role must follow:

```text
Observe → Understand → Plan → Stop Gate → Execute → Self-Check → Log → Handoff → Stop
```

Before execution, each role must append a `Plan Prepared` log entry.

After execution, each role must append a `Completed`, `Blocked`, or `Failed` log entry.

A role may not proceed if the expected previous handoff is missing.

Required evidence before moving forward:

| Phase | Required Log Status |
|---|---|
| Planning | Plan Prepared |
| Execution | Completed / Blocked / Failed |
| QA | QA Plan Prepared, then QA Completed / Failed |
| Closure | Closure decision appended |

If QA fails a slice, the next role must be Developer Remediation, not the next implementation slice.

---

## Log Index

| Entry ID | Date/Time | Role | Task Context | Status | Next Role |
|---|---|---|---|---|---|
| LOG-000 | TBD | Factory | Initial log created | Open | Product Owner |

---

## LOG-000 — Initial Factory Setup

**Role:** Factory  
**Status:** Open  
**Summary:** Shared log initialized for Problems SLA Dashboard implementation.

### Source Requirement

- `problems_sla_dashboard_srs.md`

### Required Workflow

1. Product Owner prepares stories and acceptance criteria.
2. Solution Architect prepares technical design and implementation approach.
3. Developer implements approved slice/story only.
4. QA / Static Analysis Engineer reviews, tests, and reports release recommendation.
5. Factory Coordinator prepares closure summary when required.
6. If QA fails, Developer Remediation and QA Regression must happen before the next slice.

### Mandatory Gate

Every role must prepare a plan and wait for user approval before execution.

---

## Append New Entries Below

Use this template for each new entry:

```markdown
---

## LOG-XXX — <Short Title>

**Date/Time:** <YYYY-MM-DD HH:mm>  
**Role:** <Product Owner | Solution Architect | Developer | QA / Static Analysis | Factory Coordinator>  
**Task Context:** <Short context>  
**Status:** <Plan Prepared | Approved | In Progress | Completed | Blocked | Failed>  
**Previous Logs Read:** <LOG IDs read>  
**Next Role:** <Role expected to continue>  

### 1. Inputs Read

- <File or log entry>

### 2. Current Factory State

- <State>

### 3. Work Completed

- <Summary>

### 4. Decisions Made

- <Decision>

### 5. Assumptions

- <Assumption>

### 6. Files Inspected

- `<path>`

### 7. Files Changed

- `<path>`

### 8. Commands Executed

```bash
<command>
```

### 9. Test / Validation Evidence

- <Evidence>

### 10. Risks / Open Issues

- <Risk>

### 11. Handoff Notes

- <What the next role must read or validate>
```
