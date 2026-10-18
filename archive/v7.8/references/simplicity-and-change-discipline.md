# Simplicity and Change Discipline

## Purpose

Keep implementations simple, proportional, and directly traceable to the requirement.

## Core Rules

- prefer the minimum solution that satisfies the spec
- do not add speculative flexibility
- do not introduce abstractions for one-time use
- do not add configuration without a real need
- do not widen the change set without justification
- every significant change should trace to a requirement, defect, or explicit improvement goal

## Complexity Control Questions

Before implementation or review, ask:
- Is this abstraction justified now?
- Is this configuration required by the spec?
- Is this design larger than needed?
- Did the change set expand beyond what the request requires?
- Can every changed area be explained in one sentence?

## Review Signals

Good signals:
- small, explainable diffs
- direct requirement-to-change traceability
- no speculative extension points
- focused tests covering the actual requested behavior

Bad signals:
- new generic frameworks inside a simple feature
- broad refactors hidden inside a targeted fix
- optionality or plug-in structures without current need
- unrelated cleanup bundled into rescue work
