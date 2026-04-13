# Command: PLAN

Use this command to translate the authoritative spec into verifiable implementation slices, test strategy, and traceability artifacts.

## Objective

Produce a build plan that is behaviorally explicit, traceable, and review-ready.

## Activate these skills
- `skills/planning-and-task-breakdown/SKILL.md`
- `skills/traceability-governance/SKILL.md`
- `skills/test-strategy-selection/SKILL.md`
- `skills/spec-driven-delivery/SKILL.md`

## Required outputs
- `plans/<project>-slice-plan.md`
- `plans/<project>-traceability-matrix.md`
- `plans/<project>-business-rule-verification-matrix.md` when applicable
- `plans/<project>-test-strategy.md`
- `plans/<project>-requirement-to-test-map.md`

## Planning rules
- task names must describe working behavior, not vague areas
- high-risk business rules require dedicated rows and dedicated tests
- test strategy must be chosen before large-scale implementation
- parity requirements must be explicit for in-scope web/mobile features


## V7.5 planning additions
- Select relevant NFR packs when applicable.
- Identify required ADR decisions.
- Add deployment and runtime planning needs when the project is expected to ship.


## AppSec and PT Planning Additions


Plan security testing as part of delivery, not after it.

Minimum planning additions:
- identify whether the system requires AppSec testing
- identify whether the release requires PT
- select applicable controls such as SAST, SCA, secrets scanning, DAST/API DAST
- define severity-based release blockers
- define remediation and retest expectations
- create AppSec/PT artifacts using the relevant templates

Relevant skills and packs:
- `skills/appsec-testing-and-remediation/`
- `skills/penetration-testing-readiness/`
- `packs/appsec-testing-pack.md`
- `packs/penetration-testing-pack.md`



## V7.7 Additions

Before finalizing the plan:
- run assumption-and-ambiguity control
- create or update an assumptions log when needed
- attach a verification method to every major slice
- avoid vague slice names and speculative future-proofing
- apply simplicity-and-change-discipline checks to planned scope
