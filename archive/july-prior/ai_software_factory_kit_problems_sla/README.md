# AI Software Factory Kit
# Problems SLA Dashboard

**Purpose:** Use this kit to run an AI-assisted software factory for the **Problems SLA Dashboard** requirements.  
**Source requirement:** `problems_sla_dashboard_srs.md`  
**Target system:** Emaratech KPI Dashboard  
**Expected architecture:** Follow the existing KPI Dashboard core repository architecture.

---

## 1. Factory Roles

This kit defines four working roles:

1. **Product Owner**
   - Reads the SRS.
   - Breaks the requirements into detailed epics and user stories.
   - Defines acceptance criteria, business rules, validations, and test expectations.
   - Writes all outputs to the shared log before handing over to the Architect.

2. **Solution Architect**
   - Reads the Product Owner output and the shared log.
   - Designs the implementation using the existing repository architecture.
   - Produces backend, frontend, data model, API, calculation, security, and migration guidance.
   - Writes the architecture plan to the shared log before handing over to Developer.

3. **Developer**
   - Reads the SRS, Product Owner stories, Architect output, and shared log.
   - Prepares an implementation plan and waits for review.
   - After approval, implements according to the story and architecture.
   - Writes changed files, design choices, assumptions, commands, and known risks to the shared log.

4. **QA / Static Analysis Engineer**
   - Reads the SRS, PO stories, Architect output, Developer log, and shared log.
   - Prepares a QA plan and waits for review.
   - Performs code review, static analysis, unit/integration/frontend test execution, and acceptance criteria validation.
   - Writes findings, evidence, failed tests, passed tests, and release recommendation to the shared log.

---

## 2. Mandatory Execution Rule

No role is allowed to start execution immediately.

Each role must:

1. Read the SRS.
2. Read the shared log.
3. Confirm that the previous role has completed its section.
4. Prepare a plan.
5. Stop and wait for user approval.
6. Start work only after approval.
7. Append a structured log entry after completing the work.

---

## 3. Shared Log Contract

All roles must use:

```text
factory/shared-log.md
```

The shared log is the single source of coordination between agents.

Each role must append, not overwrite.

---

## 4. Recommended Folder Structure

```text
ai_software_factory_kit_problems_sla/
│
├── README.md
├── factory/
│   ├── shared-log.md
│   ├── workflow-protocol.md
│   ├── story-template.md
│   ├── plan-template.md
│   ├── handoff-checklist.md
│   └── acceptance-traceability-matrix.md
│
└── skills/
    ├── product-owner/
    │   └── skill.md
    ├── solution-architect/
    │   └── skill.md
    ├── developer/
    │   └── skill.md
    └── qa-static-analysis/
        └── skill.md
```

---

## 5. Existing KPI Dashboard Technical Baseline

The implementation must follow the existing KPI Dashboard architecture and conventions.

Known baseline:

- Backend: .NET Core Web API.
- Frontend: Angular SPA.
- Database: SQL Server for production-like deployment.
- Backend layering:
  - API controllers.
  - Application services/interfaces.
  - Infrastructure services.
  - Entity Framework Core migrations.
  - Tests project.
- Frontend layering:
  - Feature components.
  - Core services.
  - UI tests/specs.
- Existing dashboard style:
  - Emaratech visual language.
  - Dark teal/turquoise accents.
  - White cards.
  - Rounded KPI cards.
  - Executive tables.
  - Signal pills.
- Existing AppSec SLA module should be used as a reference pattern, but Problems SLA must not hard-code AppSec-specific statuses or rules.

---

## 6. Core Delivery Principles

1. Validate scope before calculation.
2. Use Jira changelog transitions for SLA timing.
3. Use `Resolved` as the primary engineering completion milestone unless changed by the Product Owner.
4. Separate engineering delay from waiting/vendor/verification/parked delay.
5. Never silently exclude unmatched contributors or unconfigured projects.
6. Preserve calculation auditability.
7. Store calculation version and settings version.
8. Do not force conclusions if Jira/KPI scope is not comparable.
9. Every story must have acceptance criteria.
10. QA must validate against the PO acceptance criteria and report evidence.

---

## 7. Mandatory First Prompt

Use this prompt when starting the workflow:

```text
You are working inside the AI Software Factory for the Emaratech KPI Dashboard Problems SLA module.

First, read:
1. problems_sla_dashboard_srs.md
2. ai_software_factory_kit_problems_sla/factory/shared-log.md
3. Your role skill.md

Do not start implementation immediately.

Prepare your role-specific plan, list assumptions, list files you expect to inspect or modify, and stop for my review.
```
