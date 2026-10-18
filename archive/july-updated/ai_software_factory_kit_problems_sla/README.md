# AI Software Factory Kit
# Problems SLA Dashboard

**Target repo structure:**

```text
C:\My Stuff\Code\emaratech-KPIs\
│
├── AGENTS.md
├── problems_sla_dashboard_srs.md
├── ai_software_factory_kit_problems_sla\
│   ├── README.md
│   ├── factory\
│   │   ├── shared-log.md
│   │   ├── workflow-protocol.md
│   │   ├── agent-loop-protocol.md
│   │   ├── handoff-checklist.md
│   │   └── acceptance-traceability-matrix.md
│   ├── skills\
│   │   ├── product-owner\skill.md
│   │   ├── solution-architect\skill.md
│   │   ├── developer\skill.md
│   │   └── qa-static-analysis\skill.md
│   └── prompts\
│       └── ai_factory_reusable_role_prompts.md
```

## Purpose

This kit controls the AI-assisted delivery workflow for the Problems SLA Dashboard module in the Emaratech KPI Dashboard.

It is designed for Codex Desktop or similar AI coding agents.

The kit makes each role work through a controlled loop:

```text
Observe → Understand → Plan → Stop Gate → Execute → Self-Check → Log → Handoff → Stop
```

## Roles

| Role | Main Responsibility |
|---|---|
| Product Owner | Break SRS into detailed stories and acceptance criteria |
| Solution Architect | Design implementation using existing repo architecture |
| Developer | Implement only approved stories/slices |
| QA / Static Analysis | Review code, run static analysis/tests, validate acceptance criteria |
| Factory Coordinator | Prepare closure and go/no-go summaries when needed |

## Mandatory Rule

Every role must read the SRS, shared log, workflow protocol, agent-loop protocol, role skill, and latest handoff files; prepare a plan; stop for approval; execute only after approval; append to the shared log; and stop after handoff.

## Current Recommended Workflow

Use full PO and Architecture first, then development and QA per slice:

```text
PO backlog for full module
↓
Architecture for full module
↓
Developer Slice 1
↓
QA Slice 1
↓
Slice closure
↓
Developer remediation if needed
↓
QA regression if needed
↓
Next slice only after acceptance
```

## Recommended Slices

| Slice | Scope |
|---|---|
| Slice 1 | Backend foundation and calculation core |
| Slice 2 | Scope validation and data quality |
| Slice 3 | API aggregation and scorecards |
| Slice 4 | Angular dashboard UI |
| Slice 5 | Settings UI, export, operational hardening |
| Final QA | Full regression and release recommendation |

## How to Start in Codex Desktop

Paste the reusable Product Owner prompt from:

```text
ai_software_factory_kit_problems_sla/prompts/ai_factory_reusable_role_prompts.md
```

Replace only the Task Context section.

Then follow:

```text
Plan only → user approval → execute → log → handoff → stop
```

## Current Governance Rule

If QA fails a slice due to calculation defect, implementation of the next slice must stop. The next role must be Developer Remediation, then QA Regression. Only after QA regression is Accepted may the next implementation slice start.
