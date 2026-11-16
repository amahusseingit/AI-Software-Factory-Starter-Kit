# Agent Loop Protocol
# Problems SLA Dashboard AI Software Factory

## Purpose

This protocol defines the repeatable agent loop for all roles.

The loop ensures every AI agent reads prior context before acting, prepares a plan before execution, waits for user approval, executes only approved scope, validates its own work, writes to the shared log, and hands off clearly to the next role.

## Standard Agent Loop

Every role must follow:

```text
Observe → Understand → Plan → Stop Gate → Execute → Self-Check → Log → Handoff → Stop
```

## Loop Steps

### Step 1 — Observe

Read `AGENTS.md`, the requirement document, `factory/shared-log.md`, `factory/workflow-protocol.md`, this file, the active role `skill.md`, and previous handoff files referenced in the shared log.

State which files and log entries were read.

### Step 2 — Understand

Summarize current factory state, latest completed role, current blocker or next action, in-scope story IDs/slice, out-of-scope story IDs/slices, and expected next role.

### Step 3 — Plan

Prepare a role-specific plan including scope, assumptions, files to inspect, files expected to change, validation approach, risks, and stop condition.

### Step 4 — Stop Gate

Stop and wait for user approval.

Required phrase:

```text
Plan prepared. Waiting for approval before execution.
```

No code or file changes are allowed before approval.

### Step 5 — Execute

After approval, execute only the approved scope. Do not start the next slice, perform another role’s responsibility, change unrelated code, silently change business rules, bypass acceptance criteria, or ignore shared-log handoff notes.

### Step 6 — Self-Check

Before handoff, check whether the approved scope was followed, only expected files were updated, existing architecture was preserved, output was validated, assumptions/risks were documented, and next role/slice was not started.

### Step 7 — Log

Append to `factory/shared-log.md` with role, task context, previous logs read, files inspected, files changed, commands executed, evidence, risks, and handoff notes.

### Step 8 — Handoff

Clearly identify the next expected role.

Examples: Product Owner, Solution Architect, Developer, QA / Static Analysis, Developer Remediation, QA Regression, Factory Closure.

### Step 9 — Stop

Stop after handoff. Do not continue into the next role automatically.

## Current Response Mode

For planning prompts, perform only:

```text
Observe → Understand → Plan → Stop Gate
```

For approved execution prompts, continue from:

```text
Execute → Self-Check → Log → Handoff → Stop
```
