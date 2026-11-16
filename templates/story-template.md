# Detailed user story

A story is a requirement artifact, not execution approval. Use [canonical governance](../governance/protocol.md); the PO first needs approval of its role plan before writing/updating final backlog files.

## Identity
- Story ID and title:
- Epic:
- Version and owner:
- Slice and priority rationale:

## User story
As a <role>, I want <capability>, so that <business value>.

## Business context
Explain the need, user journey and intended outcome without inventing stakeholder decisions.

## Requirement source
| Source document and revision | Section/requirement ID | Supporting requirement | Open ambiguity |
|---|---|---|---|
| | | | |

## Scope
- In scope:
- Out of scope:
- Preconditions and dependencies:

## Business rules
| Rule ID | Rule | Authoritative source | Boundary/exception behavior |
|---|---|---|---|
| | | | |

## Functional requirements
| Requirement ID | Behavior | Source | Related criterion |
|---|---|---|---|
| | | | |

## Data requirements
| Data field | Source | Required/nullable | Validation, units and quality rules | Sensitivity/access |
|---|---|---|---|---|
| | | | | |

## UI requirements
Describe navigation, components, filters, states, accessibility and applicable web/mobile parity. Mark non-applicable areas with rationale rather than inventing a UI.

## API requirements
Describe operations, parameters, request/response fields, authorization, validation and errors. Separate requirement-level expectations from the architect's eventual design.

## Non-functional and operational requirements
Reference approved performance, reliability, audit, privacy/security and supportability requirements, with measurable thresholds only where supplied. Include configuration/versioning and migration constraints where relevant.

## Acceptance criteria
Give each criterion a stable ID and source.

Scenario: <name>
Given <specific preconditions>
When <action>
Then <observable expected result>
And <boundary/error/audit behavior where relevant>

## Test expectations
| Test type | Expected positive/negative/boundary coverage | Criterion IDs | Evidence needed |
|---|---|---|---|
| Unit | | | |
| Integration/API | | | |
| UI/platform | | | |
| Static analysis | | | |
| Security/authorization | | | |
| Regression | | | |

## Data-quality and scope handling
Specify missing/invalid fields, unmatched identifiers, incomplete source history, duplicates, out-of-scope records and reconciliation behavior where applicable. Preserve unresolved decisions as questions; never silently exclude data or import a profile's sample rule.

## Dependencies and sequencing
- Predecessor story/design/decision:
- Downstream impact:

## Risks and PO notes
- Assumptions requiring confirmation:
- Risks, owners and unresolved questions:
- Architect/QA handoff notes:

## Traceability and change history
| Story/criterion version | Requirement | Planned test | Change reason | Approval/evidence reference |
|---|---|---|---|---|
| | | | | |

## Provenance
Preserves the detailed structure of `archive/july-prior/ai_software_factory_kit_problems_sla/factory/story-template.md`; the updated PO role and reusable prompts supply scoped loop/handoff requirements. See [source mapping](../roles/README.md#source-mapping). Domain sample identifiers and fields are intentionally replaced with placeholders.

## Completion checklists
Use the maintained [Definition of Ready and Definition of Done](../governance/readiness-and-done.md); these checklists do not replace role-plan approval or authorize progression.
