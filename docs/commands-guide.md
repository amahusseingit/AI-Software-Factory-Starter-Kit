> REFERENCE/TEMPLATE ONLY. Existing sample rows are not executed work, approvals or gate evidence. Instantiate an approved task record with actual results before use. Canonical control: governance/protocol.md.

# Commands Guide

Before using a command, read `ORCHESTRATOR.md` to choose the correct lifecycle entry point.

## START-PROJECT
Initiates the governed workflow for a new project.

## SPEC
Normalizes and evaluates the project spec.

## PLAN
Creates slices, traceability, test strategy, and evidence expectations.

## BUILD
Implements in verified vertical slices.

## TEST
Applies test strategy and validation evidence.

`TEST` executes the `VERIFY` lifecycle phase. It does not create a separate
lifecycle phase.

## VERIFY
The lifecycle gate that requires test outputs, evidence, updated traceability,
and an explicit pass/fail disposition. Execute it through `commands/TEST.md`.

## REVIEW
Runs structured scorecards and readiness checks.

## SHIP
Prepares release-readiness and deployment packaging.

## RESCUE-PROJECT
Recovers incomplete or inconsistent generated systems.
