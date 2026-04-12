# Traceability Automation Guidance

V7.4 strengthens traceability through a small set of standard artifacts.

## Core artifacts
- `plans/<project>-traceability-matrix.md`
- `plans/<project>-business-rule-verification-matrix.md`
- `evidence/ui-action-inventory.md`
- `evidence/stack-conformance.md`
- `evidence/cross-platform-parity-report.md`

## Minimum row model
Each traceability row should capture:
- requirement ID
- acceptance criterion ID
- business rule ID if applicable
- implementation area
- tests
- evidence
- review result
- status

## Automation approach
- instantiate templates early
- update rows during plan and build, not at the end
- reuse IDs consistently across docs
- link review scorecards to impacted IDs

## High-risk rows
High-risk rows must have:
- explicit tests
- explicit evidence
- explicit review disposition

Examples of high-risk rows:
- authentication and session rules
- money or balance mutation rules
- permissions and ownership enforcement
- integration orchestration steps
- destructive actions and reversals
