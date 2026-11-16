# Definition of Ready and Definition of Done
These checklists preserve the earlier July workflow's sections 7/8 while applying the stronger [canonical protocol](protocol.md) and [security policy](security-policy.md). They are completeness aids, never approvals or competing gate decisions.

## Definition of Ready
A story is ready for development only when all applicable items have current, approved sources:
- Stable story ID and title.
- Business value and functional requirements.
- Testable acceptance criteria with source revisions.
- Data requirements and data-quality behavior.
- UI/API expectations with explicitly recorded applicability.
- Scope-validation rules, included/excluded records and ownership of ambiguous scope decisions.
- Test expectations, positive/negative/boundary cases and planned evidence.
- Dependencies and sequencing.
- Out-of-scope notes.
- Approved architecture/contracts and traceability foundation.
- New unique task-ID/slug branch with verified approved base/target and no direct main/develop writes, exact scope/plan hashes and candidate input revision.
- G1/G2/G3 evidence and explicit current developer role-plan approval. No mandatory UNKNOWN, NOT_RUN, FAILED or SCOPE_MISMATCH state.

## Definition of Done
A story meets the technical completion checklist only when:
- Approved implementation is complete; documentation-only scope has its approved artifacts complete without pretending application code was changed.
- Architecture guidance is followed; deviations are recorded and explicitly approved, not merely logged.
- Unit tests are added/updated and actually pass where required.
- Frontend tests are added/updated and actually pass for applicable clients.
- Static analysis is clean; any justified exclusion was explicitly scoped/approved and does not waive a mandatory failure or security blocker.
- Every acceptance criterion is validated against the exact output revision with bound evidence.
- Required data-quality handling is implemented and tested.
- Shared log, evidence manifest, traceability and handoff are updated truthfully.
- Independent QA has supplied its evidence-backed recommendation after separately approved QA execution; independent review/security also satisfy G4.
- Remediation and impacted regression are complete with fresh evidence; unresolved nonblocking items have approved dispositions, owners and deadlines.
- Coordinator presents a closure plan and receives explicit user action close for the exact scope/revision before recording G6 closure.

Technical completeness and closure do not imply merge, publication or deployment permission. Release work, when in scope, additionally requires G5 and separate authorized actions. If any required item is missing or stale, the decision is BLOCKED.

## Provenance
Semantically preserves every checklist item from [prior July workflow sections 7/8](../archive/july-prior/ai_software_factory_kit_problems_sla/factory/workflow-protocol.md), strengthened by the current canonical gates. Historical archive wording is not active authority.
