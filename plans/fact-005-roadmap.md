# Factory roadmap after the Phase 1 runtime slice

This is a coordinator status/next-plan proposal within FACT-005, not approval to execute new roles or capabilities. Scope authority remains the canonical protocol and explicit human decisions.

| Milestone | Current state | Required next evidence/decision |
| --- | --- | --- |
| Phase 1 source assessment and .NET design | Human-approved exact readiness specification/ADR | Preserve hashes/source approvals. |
| Phase 1 single-file advisory runtime | Implemented; hosted 104 developer tests/build/format/security automation passed on recorded candidate/integration | Final handoff revision checks; independently approved QA/security/review and human acceptance remain required. |
| Enterprise runtime foundation | NOT_STARTED | Approve requirements for identity/RBAC, audit retention, persistence, tenant/data isolation, hosting, observability and operational limits. |
| Durable agent orchestration | NOT_STARTED | Approve MAF workflow/run-state/checkpoint/retry/idempotency and human-approval contracts before implementation. |
| Requirements and Architecture agents | NOT_STARTED | Approve source-of-truth requirements, outputs, grounding/evaluation and approval boundaries. |
| Development and Testing agents | NOT_STARTED | Approve isolated execution, repository/tool permissions, bounded patches, actual build/test evidence and independent QA separation. |
| Security Review and Code Quality agents | NOT_STARTED | Approve threat model, safe targets, analyzer policy, severity/disposition and independent review responsibilities. |
| Hardcoded Business Rule Detection agent | PARTIAL_PROTOTYPE | Current syntax heuristic and advisory analyst/critic are not semantic policy certification; approve solution-level scope/evaluation before expansion. |
| Microservice Dependency Mapping agent | NOT_STARTED | Approve project/HTTP/message integration extraction, evidence completeness and safe ingestion. |
| Angular management portal | NOT_STARTED | Approve API/identity/workflow contracts, UX and deployment scope after backend foundations. |
| Release/operations | NOT_STARTED | Separate release authorization, immutable artifact/staging/rollback proof and explicit merge/deployment permissions. |

Next recommendation: prepare named independent QA/security/reviewer plans for the exact draft output; stop for human approval of each role. Do not reinterpret developer automation or this roadmap as acceptance, merge authority or permission to begin another slice. Main and develop remain unchanged by FACT-005 publication.
