# AGENTS.md

## Purpose
This repository implements a reusable enterprise-grade AI-driven SDLC operating model.

## Roles
- Orchestrator
- Analyst
- Architect
- Developer
- Reviewer
- Tester
- Approver

## Non-Negotiable Rules
- No implementation without approved requirements
- No architecture without validated requirements
- No dependent slice starts before review gate passes
- Every role must log start and end time
- Every meaningful action must update the run log
- All work must stay traceable to requirements and acceptance criteria
- Tests must include negative cases
- Reviews must end with:
  - GO
  - GO WITH MINOR FIXES
  - REVISE
- Approval gates must be documented before moving between major phases

## Standard Flow
BRD → Analysis → Validation → Architecture → Slice Planning → Build → Review → Test → Defect Loop → Approval Gates → Completion
