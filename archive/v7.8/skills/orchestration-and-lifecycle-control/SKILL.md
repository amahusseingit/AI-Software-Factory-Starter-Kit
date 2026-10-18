---
name: orchestration-and-lifecycle-control
description: Use this skill to determine the correct lifecycle entry point, activate the right commands and skills, coordinate artifact creation, and prevent invalid progression through the starter kit workflow.
triggers:
  - start project
  - choose command
  - lifecycle
  - orchestration
  - which skill
  - existing project
  - rescue
  - review readiness
---

# Overview

This skill is the **AI-facing orchestration workflow** for the starter kit.

Use it whenever the AI needs to:
- determine how to enter the lifecycle
- identify which commands apply
- activate the correct supporting skills
- select packs and templates
- coordinate artifact expectations
- prevent invalid lifecycle jumps

This skill does not replace the other skills.  
It coordinates them.

---

# When to Use

Use this skill when:
- a new project begins
- the AI needs to decide between START-PROJECT, SPEC, RESCUE-PROJECT, REVIEW, or SHIP
- the project already exists and must be assessed
- the spec is weak or incomplete
- the AI needs to determine which packs/templates/skills to activate
- the user asks how to use the starter kit or what to run next

---

# Inputs Required

At minimum, gather:
- project state (new, existing, incomplete, release-stage)
- authoritative spec path if available
- apparent system maturity
- whether code already exists
- whether the main issue is requirements, implementation, testing, security, or release readiness
- applicable risk areas such as security, architecture, integration, or operations

---

# Classification Step

First classify the situation.

## Mode A — New project
The system does not exist yet or is starting from requirements.

**Likely entry point:**
- `commands/START-PROJECT.md`

## Mode B — Weak or incomplete spec
Requirements exist but are not ready for execution.

**Likely entry point:**
- `commands/SPEC.md`

## Mode C — Existing project with code
The codebase already exists and needs structured improvement.

**Likely entry point:**
- `commands/RESCUE-PROJECT.md`

## Mode D — Existing incomplete or misleadingly complete system
The system appears partially implemented or behaviorally incomplete.

**Likely entry point:**
- `commands/RESCUE-PROJECT.md`

## Mode E — Mature project entering review/release hardening
The project needs structured validation and release readiness.

**Likely entry point:**
- `commands/REVIEW.md`
- then `commands/SHIP.md`

---

# Process

## Step 1 — Confirm governance
- Read `AGENTS.md`
- Confirm the kit must remain generic
- Confirm project-specific requirements belong under `specs/`

## Step 2 — Confirm the source of truth
- Identify the authoritative project spec
- If none exists, require one or begin with spec normalization
- If ambiguity exists, activate assumption/ambiguity control

## Step 3 — Choose lifecycle entry point
Choose one:
- START-PROJECT
- SPEC
- RESCUE-PROJECT
- REVIEW
- SHIP

Do not choose casually.  
Base it on the project state.

## Step 4 — Activate core skills
Usually consider:
- `skills/spec-driven-delivery/`
- `skills/planning-and-task-breakdown/`
- `skills/incremental-implementation/`
- `skills/test-enforcement/`
- `skills/review-gates/`

## Step 5 — Activate situational skills
Activate only as needed.

### If the spec is weak
- `skills/spec-quality-analysis/`
- `skills/assumption-and-ambiguity-control/`

### If the project already exists
- `skills/project-rescue-and-completion/`
- `skills/surgical-change-control/`

### If traceability matters
- `skills/traceability-governance/`

### If test planning needs structure
- `skills/test-strategy-selection/`

### If security applies
- `skills/appsec-testing-and-remediation/`
- `skills/penetration-testing-readiness/`

### If architecture decisions matter
- `skills/architecture-decisioning/`

### If NFRs matter
- `skills/nfr-selection-and-hardening/`

### If release/ops matters
- `skills/devops-and-deployment-readiness/`

## Step 6 — Activate packs/templates when relevant
Choose from:
- `packs/`
- `adr-packs/`
- `devops-packs/`
- `test-strategy-packs/`
- `templates/`

Instantiate important outputs into:
- `plans/`
- `evidence/`
- `reviews/`
- `adrs/`
- `releases/`

## Step 7 — Define minimum artifacts for the next phase
Before allowing phase progression, identify what must exist.

Examples:

### Before BUILD
- project spec
- slice plan
- traceability foundation
- assumptions log if needed
- test strategy

### Before TEST
- implemented slices
- updated traceability
- business-rule focus
- selected test strategy

### Before REVIEW
- evidence
- test outputs
- stack conformance
- security artifacts when applicable

### Before SHIP
- review outputs
- readiness assessment
- blockers status
- security/PT status when applicable

## Step 8 — Prevent invalid progression
Block:
- weak spec → BUILD
- no planning artifacts → BUILD
- incomplete rescue assessment → rewrite
- no evidence → REVIEW
- no review → SHIP
- unresolved severe security issues → release-ready claim
- visual UI only → feature complete claim

---

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| We can just start coding now | Invalid when lifecycle entry and artifacts are not established |
| The spec is good enough even though it has gaps | Gaps must be logged and assessed, not ignored |
| The project exists so we do not need rescue | Existing incomplete systems often require rescue-first handling |
| We can review later | Review is a gate, not an afterthought |
| Security can happen after release prep | AppSec/PT must be integrated when relevant |
| The UI looks finished | Visual appearance is not behavioral completion |

---

# Red Flags

- no clear spec path
- multiple conflicting requirement sources
- project goes from spec directly to large code generation
- no traceability artifacts
- no test strategy
- existing project being modified without rescue assessment
- AppSec/PT ignored in a security-sensitive system
- release-readiness claimed without review evidence
- broad rewrites without surgical change control

---

# Verification

Confirm all of the following:
- lifecycle entry point is explicitly chosen
- relevant commands are identified
- relevant skills are activated
- relevant packs/templates are selected
- minimum artifacts for the next phase are defined
- invalid jumps are blocked
- assumptions and ambiguity are handled explicitly
- security and release concerns are included when applicable

---

# Outputs

Typical outputs from this skill include:
- lifecycle entry decision
- active command list
- active skills list
- active packs/templates list
- artifact expectations for the next phase
- progression blockers
- escalation to rescue/review/security/release flows when needed
