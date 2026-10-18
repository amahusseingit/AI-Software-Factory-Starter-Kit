# AI Software Factory Starter Kit V7.8

A generic, governed AI delivery kit for building, rescuing, reviewing, testing, securing, and shipping software systems from a project-specific spec.

The kit is intentionally **generic**. It is designed to start building **any system** from an authoritative spec placed under `specs/`.

---

## What this kit is

This repository is an operating model for AI-assisted software delivery. It combines:
- lifecycle commands
- reusable delivery skills
- governance rules
- an explicit orchestration layer
- traceability and evidence patterns
- readiness scoring
- rescue workflows
- NFR, architecture, DevOps, AppSec, and PT support

It helps teams move from requirements to implementation with stronger discipline, reviewability, and release readiness.

---

## What this kit is not

This repository is not:
- a generated business application
- a domain-specific product template
- a single-stack framework implementation
- a substitute for product thinking, engineering review, or testing judgment

Project-specific requirements belong in `specs/`, not in the core kit.

---

## Current version summary

### V7.4
Added the next reliability wave on top of V7.3:
- stronger rescue mode
- better traceability automation
- test strategy packs

### V7.5
Extended the generic kit with:
- NFR packs under `packs/`
- architecture decision packs under `adr-packs/`
- DevOps and deployment packs under `devops-packs/`
- supporting skills, templates, examples, and documentation

### V7.6
Integrated **Application Security (AppSec)** and **Penetration Testing (PT)** into the governed lifecycle.

### V7.7
Strengthened implementation discipline with:
- assumption and ambiguity control
- simplicity and complexity control
- surgical change control for rescue and maintenance work
- verification attached to each major step or slice

### V7.8
Consolidates the kit with an explicit orchestration layer:
- upgraded `ORCHESTRATOR.md` as the human-facing operating guide
- added `skills/orchestration-and-lifecycle-control/` as the AI-facing orchestration workflow
- updated governance and docs so orchestration is a first-class part of the operating model

---

## Orchestration layer

The orchestration layer exists to make sure the right parts of the kit are activated in the right order.

### Human-facing orchestration
Use:
- `ORCHESTRATOR.md`

This file helps operators decide:
- whether the project is new, weak-spec, existing, rescue-stage, or release-stage
- which lifecycle entry point to use
- which supporting skills should be activated
- what artifacts should exist before moving forward

### AI-facing orchestration
Use:
- `skills/orchestration-and-lifecycle-control/`

This skill helps the AI:
- classify project state
- choose the right command
- activate the right skills and packs
- define minimum artifact expectations
- block invalid lifecycle jumps

---

## Start here

1. Add your project spec under `specs/`.
2. Read `ORCHESTRATOR.md`.
3. Follow `AGENTS.md`.
4. Start with the correct lifecycle entry:
   - `commands/START-PROJECT.md` for new systems
   - `commands/SPEC.md` for weak specs
   - `commands/RESCUE-PROJECT.md` for existing or incomplete systems
5. Continue through the lifecycle as appropriate:
   - `commands/PLAN.md`
   - `commands/BUILD.md`
   - `commands/TEST.md`
   - `commands/REVIEW.md`
   - `commands/SHIP.md`

---

## Guiding principle

Keep the **starter kit generic**.

Do not hard-code one business domain into the kit itself.  
Each actual system should provide its own requirements through a project-specific spec under `specs/`.

The orchestration layer exists to ensure those requirements are routed through the correct lifecycle and skills, rather than handled as one-shot prompting.
