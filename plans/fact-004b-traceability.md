# Phase 1 planned traceability

Revision: 1. Source: [SRS candidate revision 1](../specs/factory-runtime-phase1.md). Architecture: [ADR candidate revision 1](../adrs/factory-runtime-phase1.md). Application candidate: absent. Source input base: `7ed5858e44bafbabf083022397ef97a4bb827dd2`. This is planning, not test evidence. Scope/plan hashes for readiness artifacts appear in the evidence manifest; approved implementation hashes remain unset. Independent reviewer is unassigned for every row. Missing execution evidence blocks all application acceptance.

| Requirement / story | AC | Planned implementation | Planned executable test or assessment | Actual check state | Raw application evidence | Reviewer / remaining action |
| --- | --- | --- | --- | --- | --- | --- |
| R10 / S4 | AC-01 | SDK/central pins, projects, lockfiles | Locked restore, Release build, test discovery | NOT_RUN | None | Unassigned; execute approved BUILD. |
| R1,R4 / S1 | AC-02 | Roslyn scanner and contracts | Repeatability, digest/span/original-text tests | NOT_RUN | None | Unassigned; implement then test. |
| R2,R3,R4 / S1 | AC-03 | Rule options, scanner diagnostics | Both operand orders/operators/types/exclusions and malformed source | NOT_RUN | None | Unassigned; confirm heuristic boundaries. |
| R5 / S2 | AC-04 | Service policy plus API | Disabled/consent matrix and direct-service spy tests | NOT_RUN | None | Unassigned; prove zero provider calls. |
| R6 / S2 | AC-05 | MAF agents, injected IChatClient | Actual MAF/fake-provider sequence and payload tests | NOT_RUN | None | Unassigned; verify no tools/session leakage. |
| R7,R8 / S2,S3 | AC-06 | Deadline, output limits, error retention | First/second failure, output/cancellation/resource tests | NOT_RUN | None | Unassigned; independently verify failure behavior. |
| R9 / S3 | AC-07 | Response factory and no-tool architecture | Adversarial input/output, decision invariant and source review | NOT_RUN | None | Unassigned; verify no approval capability. |
| R8 / S3 | AC-08 | Provider/host options and log policy | Endpoint/redirect/key-leak/host/log sentinel tests | NOT_RUN | None | Unassigned; independent security assessment. |
| R1,R8 / S1,S3 | AC-09 | API validation and concurrency bound | HTTP validation/boundary and caller-isolation tests | NOT_RUN | None | Unassigned; include real loopback hosting. |
| R10 / S4 | AC-10 | CI, evidence, append-only handoff | Current PR integration checks and independent review | NOT_RUN | None | Unassigned; human selects independent roles. |

R/S abbreviations refer to the P1-R/P1-S identifiers in the SRS. Required applicability: every AC is mandatory for Phase 1 application acceptance. No row is waived by its absence from this readiness-only task. G4 and later gates remain BLOCKED.
