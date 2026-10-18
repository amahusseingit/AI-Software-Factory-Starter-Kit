# AI Software Factory Workflow Protocol
# Problems SLA Dashboard

## 1. Objective

This protocol controls the work sequence between the Product Owner, Solution Architect, Developer, and QA / Static Analysis Engineer.

The main goal is to prevent disconnected agent work, missed requirements, undocumented assumptions, and unverified implementation.

---

## 2. Role Sequence

```text
SRS
  ↓
Product Owner
  ↓
Solution Architect
  ↓
Developer
  ↓
QA / Static Analysis Engineer
  ↓
User Review / Release Decision
```

---

## 3. Mandatory Read-Before-Work Rule

Before starting any work, each role must read:

1. `problems_sla_dashboard_srs.md`
2. `factory/shared-log.md`
3. Its own `skills/<role>/skill.md`
4. All prior role outputs recorded in the shared log

The role must explicitly mention which log entries it read.

---

## 4. Mandatory Plan-Then-Stop Rule

Each role must first produce a plan and stop.

The role must not start execution until the user explicitly approves.

Expected phrase:

```text
Plan prepared. Waiting for approval before execution.
```

---

## 5. Handoff Rules

### Product Owner → Architect

The PO must provide:

- Epic list.
- Story list.
- Detailed story descriptions.
- Acceptance criteria.
- Business rules.
- Data-quality rules.
- Dependencies.
- Traceability to SRS sections.

### Architect → Developer

The Architect must provide:

- Backend design.
- Frontend design.
- Data model changes.
- API contracts.
- Calculation algorithm.
- Migration strategy.
- Security/access-control expectations.
- Testing impact.
- Files likely to change.

### Developer → QA

The Developer must provide:

- Implementation summary.
- Changed files.
- Commands executed.
- Tests executed.
- Known limitations.
- Assumptions.
- Any deviations from architecture or PO story.

### QA → User

QA must provide:

- Static analysis findings.
- Code review findings.
- Test results.
- Acceptance criteria validation.
- Regression risk.
- Release recommendation.
- Defects or required fixes.

---

## 6. Blocking Conditions

A role must stop and ask for clarification if:

1. The previous role log is missing.
2. The SRS is unavailable.
3. Scope is ambiguous.
4. Architecture contradicts existing repository structure.
5. Acceptance criteria are missing.
6. Jira workflow assumptions are not validated.
7. Required files or modules are not found.
8. Tests cannot be executed.
9. Any production-impacting migration is unclear.

---

## 7. Definition of Ready

A story is ready for development only when it has:

- Story ID.
- Title.
- Business value.
- Functional requirements.
- Acceptance criteria.
- Data requirements.
- UI/API expectations.
- Scope validation rule.
- Test expectations.
- Dependencies.
- Out-of-scope notes.

---

## 8. Definition of Done

A story is done only when:

- Code is implemented.
- Architecture guidance is followed or deviations are logged.
- Unit tests are added or updated.
- Frontend tests are added or updated where applicable.
- Static analysis is clean or justified.
- Acceptance criteria are validated.
- Data-quality handling is implemented.
- Shared log is updated.
- QA has provided a release recommendation.
