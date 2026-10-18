# Workflow Protocol
# Problems SLA Dashboard AI Software Factory

## Objective

This protocol controls the work sequence between Product Owner, Solution Architect, Developer, QA / Static Analysis Engineer, Developer Remediation, QA Regression, and Factory Closure.

## Standard Flow

```text
SRS
  ↓
Product Owner
  ↓
Solution Architect
  ↓
Developer Slice
  ↓
QA Slice
  ↓
Factory Closure
  ↓
Next Slice or Remediation
```

If QA fails:

```text
QA Failure
  ↓
Developer Remediation
  ↓
QA Regression
  ↓
Factory Closure
  ↓
Next Slice only if Accepted
```

## Mandatory Read-Before-Work Rule

Before starting any work, each role must read:

1. `AGENTS.md`
2. `problems_sla_dashboard_srs.md`
3. `factory/shared-log.md`
4. `factory/workflow-protocol.md`
5. `factory/agent-loop-protocol.md`
6. The active role `skill.md`
7. Prior role outputs referenced in the shared log

## Mandatory Plan-Then-Stop Rule

Each role must first produce a plan and stop.

Required phrase:

```text
Plan prepared. Waiting for approval before execution.
```

## Handoff Rules

### PO → Architect

The PO must provide epics, stories, acceptance criteria, business rules, data-quality rules, scope validation rules, test expectations, and SRS traceability.

### Architect → Developer

The Architect must provide backend design, frontend design, data model changes, API contracts, calculation algorithm, migration strategy, authorization expectations, testing impact, and likely files to change.

### Developer → QA

The Developer must provide implementation summary, changed files, commands executed, tests executed, known limitations, assumptions, and deviations.

### QA → Closure or Remediation

QA must provide static analysis findings, code review findings, test results, acceptance criteria validation, defects, and release recommendation.

### Closure → Next Role

Factory closure must decide whether to proceed to next slice, start Developer Remediation, ask PO/Architect for clarification, or stop due to blocker.

## Blocking Conditions

A role must stop if previous role log is missing, SRS is unavailable, acceptance criteria are missing, architecture contradicts repository structure, developer handoff is missing for QA, QA failed but the next slice is requested, calculation behavior is ambiguous, or required tests cannot be executed.
