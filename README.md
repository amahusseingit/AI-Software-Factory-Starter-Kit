# AI Software Factory Starter Kit

A generic, governed AI delivery starter kit for building, reviewing, rescuing, and shipping software systems with spec-driven workflows, reusable skills, review gates, traceability, and readiness scoring.

This kit is designed to help teams use AI for software delivery without losing structure, quality, or control. It provides a reusable operating model for taking a system from requirements to implementation, testing, review, rescue, and release readiness.

---

## Why this kit exists

AI can generate code quickly, but speed alone does not guarantee correctness, completeness, or production readiness.

Common failure modes include:
- visually complete screens with missing behavior
- placeholder CRUD actions
- missing validation
- weak test coverage
- stack drift from the requested technology choices
- missing traceability between requirements, implementation, and tests
- incomplete rescue paths for partially generated systems
- weak release readiness discipline

This starter kit exists to solve those problems.

It gives you a structured way to:
- start new systems from a clear spec
- guide AI through a disciplined delivery lifecycle
- enforce review gates and evidence requirements
- rescue incomplete or partially generated systems
- prepare systems for release using generic governance patterns

---

## What this repository is

This repository is a **generic AI software delivery kit**.

It is not:
- a single generated software system
- a framework tied to one business domain
- a code template for one stack implementation
- a domain-specific product pack

It is:
- a reusable operating model for software delivery with AI
- a set of lifecycle commands
- a governed skills library
- a review and evidence model
- a rescue workflow for incomplete projects
- a collection of templates, checklists, and reusable packs

The kit is intentionally generic.  
Each new system should bring its own project-specific requirements through a spec file placed under `specs/`.

---

## Who this is for

This kit is useful for:
- software engineers using AI-assisted development tools
- engineering managers who want more disciplined AI delivery
- architects who want structured implementation and review workflows
- teams building internal systems, business apps, mobile apps, portals, and admin platforms
- teams rescuing incomplete AI-generated software
- teams who want traceability, readiness scoring, and release governance

---

## Core principles

This kit is built around a few core principles:

### 1. Spec first
No serious build should begin without an authoritative project spec.

### 2. Behavior over appearance
A screen is not complete because it looks complete.  
Visible UI must be wired, validated, and connected to real behavior.

### 3. Evidence over assumption
Completion requires evidence, not confidence.

### 4. Skills over giant prompts
Reusable workflows should be encoded as skills, not buried in one oversized prompt.

### 5. Generic core, specific project spec
The starter kit stays generic.  
The system-specific requirements belong in `specs/<your-project>.md`.

### 6. Review is a gate, not a formality
Testing, review, and readiness must actively block incomplete delivery.

### 7. Rescue is part of the lifecycle
AI-generated systems often need repair. Rescue is a first-class workflow, not an afterthought.

---

## Start here

If you are new to this repository, use this sequence:

1. Create or place your project requirements in:
   - `specs/<your-project>.md`

2. Read:
   - `docs/getting-started.md`

3. Start with:
   - `commands/START-PROJECT.md`

4. Continue through the lifecycle:
   - `commands/SPEC.md`
   - `commands/PLAN.md`
   - `commands/BUILD.md`
   - `commands/TEST.md`
   - `commands/REVIEW.md`
   - `commands/SHIP.md`

5. If you already have a partially generated or incomplete system, use:
   - `commands/RESCUE-PROJECT.md`

---

## Lifecycle overview

This kit follows a governed lifecycle:

```text
SPEC → PLAN → BUILD → TEST → REVIEW → SHIP
          ↑
       RESCUE
```

### SPEC
Normalize and assess the project spec, identify gaps, and establish the authoritative source of truth.

### PLAN
Break the system into implementation slices, define acceptance criteria, traceability, and evidence expectations.

### BUILD
Implement behaviorally complete slices, not UI shells or placeholders.

### TEST
Apply the correct test strategy, verify core business behavior, and collect execution evidence.

### REVIEW
Run structured quality gates for functionality, architecture, UI, testing, security, and readiness.

### SHIP
Prepare deployment, release notes, migration readiness, and operational packaging.

### RESCUE
Assess incomplete or broken generated systems, classify gaps, decide salvage vs rebuild, and recover safely.

---

## Choose your path

### I want to start a brand-new system
Use:
- `specs/<your-project>.md`
- `commands/START-PROJECT.md`

### I have requirements, but they are weak or incomplete
Use:
- `commands/SPEC.md`
- `skills/spec-quality-analysis/`
- `templates/project-spec-template.md`

### I have a partially generated system that looks incomplete
Use:
- `commands/RESCUE-PROJECT.md`
- `skills/project-rescue-and-completion/`
- `references/rescue-gap-taxonomy.md`

### I want to improve delivery discipline and governance
Use:
- `skills/review-gates/`
- `templates/traceability-matrix-template.md`
- `templates/readiness-scorecard-template.md`

### I want to prepare a system for release
Use:
- `commands/SHIP.md`
- `skills/devops-and-deployment-readiness/`
- `devops-packs/`

---

## Repository structure

A typical V7.5 layout looks like this:

```text
.
├── AGENTS.md
├── README.md
├── CHANGELOG.md
├── commands/
├── skills/
├── references/
├── templates/
├── packs/
├── adr-packs/
├── devops-packs/
├── test-strategy-packs/
├── docs/
├── specs/
├── plans/
├── evidence/
├── reviews/
├── adrs/
└── releases/
```

### Key folders

#### `commands/`
Copy-paste-ready lifecycle command files for guiding AI through the delivery process.

#### `skills/`
Reusable, governed workflows for common delivery tasks such as:
- spec-driven delivery
- planning and task breakdown
- implementation discipline
- test enforcement
- review gates
- rescue and recovery
- architecture decisioning
- NFR selection
- deployment readiness

#### `references/`
Supporting guidance, checklists, taxonomies, and scoring models.

#### `templates/`
Reusable templates for specs, review scorecards, traceability, rescue plans, UI workflows, readiness reports, and more.

#### `packs/`
Generic reusable packs for non-functional requirements and quality attributes.

#### `adr-packs/`
Reusable architecture decision packs for common system design choices.

#### `devops-packs/`
Reusable operational and deployment guidance.

#### `test-strategy-packs/`
Reusable test strategy packs for different types of systems.

#### `specs/`
The authoritative home for project-specific requirements.

#### `plans/`
Generated project plans, slices, and traceability artifacts.

#### `evidence/`
Functional proof, execution evidence, stack conformance, and implementation validation.

#### `reviews/`
Structured review reports and scorecards.

#### `adrs/`
Architecture decision records.

#### `releases/`
Release readiness artifacts and release packaging documentation.

---

## How to use this kit

## 1. Add your project spec

Create a project-specific spec file such as:

```text
specs/inventory-management-system.md
specs/customer-portal.md
specs/mobile-field-operations-app.md
```

That spec should become the source of truth for the project.

If your requirements start as a Word file, PDF, screenshots, or rough notes, convert them into a clean markdown spec first.

Useful templates:
- `templates/project-spec-template.md`
- `templates/ui-workflow-template.md`
- `templates/screen-inventory-template.md`
- `templates/screenshot-annotation-template.md`

---

## 2. Run the lifecycle

### Start
Use `commands/START-PROJECT.md` to initiate the project and activate the relevant lifecycle skills.

### Refine the spec
Use `commands/SPEC.md` to:
- normalize the spec
- identify missing sections
- assess readiness
- define open items

### Plan
Use `commands/PLAN.md` to:
- break work into verifiable slices
- define acceptance criteria
- attach evidence expectations
- establish traceability

### Build
Use `commands/BUILD.md` to:
- implement one slice at a time
- prevent placeholder UI
- enforce behavioral completeness

### Test
Use `commands/TEST.md` to:
- choose the right test strategy
- validate critical behaviors
- gather proof

### Review
Use `commands/REVIEW.md` to:
- run structured review scorecards
- verify completeness and correctness
- detect release blockers

### Ship
Use `commands/SHIP.md` to:
- package readiness artifacts
- validate deployment considerations
- prepare release documentation

---

## 3. Use rescue mode when needed

If the generated output is incomplete, misleading, or partially functional, do not continue blindly.

Use:
- `commands/RESCUE-PROJECT.md`

This mode helps:
- classify the gap types
- decide salvage vs rebuild
- define a safe recovery plan
- expand test and regression scope
- restore traceability

---

## What makes this kit different

Many AI development kits focus on prompt output.  
This one focuses on **delivery governance**.

Key differentiators:
- lifecycle-driven instead of one-shot-only
- reusable skill-based operating model
- explicit review gates
- readiness scoring
- spec quality analysis
- rescue workflows
- traceability templates
- architecture and deployment support
- generic core with project-specific specs

---

## Skills model

Each skill is structured as a governed workflow, not a loose note.

A typical skill includes:
- overview
- when to use
- required inputs
- process
- rationalizations to reject
- red flags
- verification
- outputs

This makes the kit more consistent and easier to extend.

Examples of skills in this repository:
- spec-driven delivery
- spec quality analysis
- planning and task breakdown
- incremental implementation
- test enforcement
- review gates
- traceability governance
- test strategy selection
- rescue and completion
- NFR selection and hardening
- architecture decisioning
- deployment readiness

---

## Governance model

The root `AGENTS.md` governs how the kit should be used.

It helps enforce rules such as:
- do not build without a source-of-truth spec
- do not accept visible UI without working behavior
- do not skip evidence collection
- do not call work complete without review
- do not allow stack drift unless explicitly approved
- do not mix generic templates with actual project specs

This governance layer is one of the core strengths of the kit.

---

## Evidence and traceability

A core idea in this repository is that output should be explainable and reviewable.

Typical artifacts include:
- project plan
- slice plan
- traceability matrix
- UI action inventory
- stack conformance report
- readiness scorecard
- business rule verification matrix
- rescue assessment
- review scorecards
- release readiness package

These artifacts help teams answer:
- what was required
- what was implemented
- what was tested
- what evidence exists
- whether the release is ready

---

## Readiness scoring

The kit includes generic scoring models to help answer:
- Is the spec good enough to build from?
- Is the implementation complete enough to review?
- Is the system ready to ship?

Readiness scoring can be used for:
- spec readiness
- implementation readiness
- release readiness
- rescue recovery progress

This helps move from subjective judgment to structured decision-making.

---

## Review scorecards

The kit supports structured scorecards for areas such as:
- architecture review
- functional review
- UI review
- testing review
- security review
- release review

This makes review outcomes easier to compare, audit, and improve over time.

---

## Non-functional and architecture support

V7.5 expands beyond functional delivery and includes generic support for:
- performance
- scalability
- availability
- security
- observability
- accessibility
- localization
- auditability
- maintainability
- disaster recovery

It also includes architecture decision support for areas such as:
- architecture style
- authentication strategy
- database boundaries
- caching
- background jobs
- API versioning
- integration orchestration
- offline sync
- tenancy

---

## Common use cases

This kit can be used for many system types, including:
- admin portals
- internal business apps
- workflow systems
- transactional systems
- web and mobile apps
- customer-facing portals
- field operations apps
- integration-heavy systems
- systems rescued from incomplete AI output

The core kit remains generic across all of them.

---

## What this kit does not do

This kit does not replace:
- system-specific requirements
- product thinking
- business analysis
- architecture judgment
- engineering review
- real testing discipline

It improves those processes by giving them stronger structure.

---

## Common mistakes

Avoid these mistakes:

### 1. Putting project-specific requirements into the core kit
The kit should stay generic.  
Use `specs/<your-project>.md` for system-specific content.

### 2. Building before the spec is ready
Weak specs create weak outputs.  
Use spec quality analysis first when needed.

### 3. Treating UI presence as functionality
Buttons, forms, and screens are not enough.  
Behavior must work end to end.

### 4. Skipping traceability
If requirements, tests, and evidence are disconnected, quality drops fast.

### 5. Ignoring rescue mode
If a generated system is incomplete, use rescue mode instead of patching randomly.

### 6. Mixing templates with real outputs
Templates are starting points.  
Generated project artifacts should live in their own proper locations.

---

## Recommended workflow for new users

If you are using this repository for the first time, this is the simplest path:

1. create a project spec under `specs/`
2. read `docs/getting-started.md`
3. run `commands/START-PROJECT.md`
4. run `commands/SPEC.md`
5. run `commands/PLAN.md`
6. implement through `commands/BUILD.md`
7. verify with `commands/TEST.md`
8. evaluate with `commands/REVIEW.md`
9. prepare release using `commands/SHIP.md`

If the system is already partially generated:
1. use `commands/RESCUE-PROJECT.md`
2. classify gaps
3. decide salvage vs rebuild
4. repair with traceability and tests

---

## Documentation

Start with:
- `docs/getting-started.md`
- `docs/choose-your-path.md`  
- `docs/repository-structure.md`
- `docs/commands-guide.md`
- `docs/skills-guide.md`
- `docs/create-your-first-project.md`
- `docs/rescue-existing-project.md`

If `docs/choose-your-path.md` does not exist yet in your current version, it is a recommended addition and can be added as the main navigation page for new users.

---

## Open-source usage philosophy

This repository is designed to be:
- reusable
- extensible
- generic
- governance-friendly
- AI-tool-agnostic at the operating-model level

You can adapt it to your own:
- tech stack
- project type
- delivery team
- governance level
- release process

The most important rule is to keep the **core kit generic** and put project-specific requirements into specs and project artifacts.

---

## Contribution philosophy

Contributions are welcome, especially in these areas:
- improving generic workflows
- strengthening review gates
- enhancing rescue mode
- improving traceability and readiness scoring
- adding generic templates and packs
- improving documentation and onboarding
- expanding generic test strategy support
- improving NFR and DevOps guidance

Please avoid contributions that hard-code one business domain into the core kit.

See:
- `CONTRIBUTING.md`
- `CODE_OF_CONDUCT.md`
- `SECURITY.md`
- `SUPPORT.md`

---

## Versioning

This repository follows an evolving maturity model.

Examples:
- V7.2 focused on a strong generic base
- V7.3 added readiness scoring, spec quality analysis, and review scorecards
- V7.4 strengthened rescue mode, traceability, and test strategy support
- V7.5 added NFR packs, ADR packs, and DevOps/deployment support

Use `CHANGELOG.md` to track version evolution.

---

## License

See `LICENSE`.

Before publishing publicly, make sure your license file is finalized and does not still contain placeholder values.

---

## FAQ

### Is this tied to one stack?
No. The core kit is generic.  
A project spec can define the desired stack.

### Is this only for greenfield projects?
No. It also supports rescue and recovery of incomplete projects.

### Can I use this with web, mobile, or backend-heavy systems?
Yes. The kit is designed to support many system types.

### Can I add domain packs?
Yes, but keep them outside the generic core if possible.

### Can this replace engineering review?
No. It improves the review process, but does not replace judgment.

---

## Suggested GitHub description

A generic, governed AI delivery starter kit for building, reviewing, rescuing, and shipping software systems with spec-driven workflows, reusable skills, review gates, traceability, and readiness scoring.

---

## Suggested GitHub topics

```text
ai
ai-agents
agentic-ai
ai-assisted-development
software-engineering
starter-kit
spec-driven-development
code-review
quality-engineering
traceability
devops
release-readiness
```

---

## Final note

This kit is built for teams that want the speed of AI-assisted software delivery **without giving up discipline**.

Use it to make AI output:
- more structured
- more reviewable
- more complete
- more testable
- more production-ready

If you are just getting started, begin with:
- `docs/getting-started.md`
- `commands/START-PROJECT.md`
- your own project spec under `specs/`
