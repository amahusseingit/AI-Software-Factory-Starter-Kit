# How V7 Works

V7 is a governed delivery system, not only a prompt library.

## Core model

The kit assumes every serious software task should move through a structured lifecycle:

- DEFINE
- PLAN
- BUILD
- VERIFY
- REVIEW
- SHIP

## What makes V7 different

### 1. Skills instead of generic prompting
Each skill is a workflow with:
- when to use
- required inputs
- process
- rationalizations to reject
- red flags
- verification
- expected outputs

### 2. Evidence instead of optimism
V7 does not allow "looks complete" as a completion signal.
A feature must produce evidence.

### 3. Parity instead of drift
If Angular and Flutter are both in scope, they are reviewed as first-class peers.

### 4. Real source of truth
Only files under `specs/` are authoritative by default.
Files under `templates/` are scaffolds only.

## V7.1 hardening additions
- operational command prompts
- rescue workflow for incomplete systems
- acceptance packs and stronger evidence templates
