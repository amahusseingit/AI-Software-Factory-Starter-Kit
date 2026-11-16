# Release readiness scorecard: Factory hardening baseline

- Date: 16 November 2026.
- Candidate: develop 1b4a84d128423d7cc8861e08b3ceb15fb231c525.
- Target observed: main 4df16e0b73b2410daaab3960a0b5a9e846f9971b.
- Assessor: Codex release-readiness assessor; not independent signoff.
- Scope: generic Factory source/tools/CI promotion; no APERTURE deployment.
- Detailed basis: [release-readiness assessment](../releases/release-readiness.md).
- User authority: current chat request to prepare this packet and open the PR;
  explicit instruction not to merge.

Scores are descriptive 0-5 aids, not gate decisions or approval. UNKNOWN and
NOT_RUN items are not converted into PASS by a high average.

| Area | Score (0-5) | Check state | Evidence / remaining limitation |
|---|---:|---|---|
| Functional completeness | 5 | PASS | Reviewed Factory hardening scope; application scope not included |
| Regression risk | 4 | PASS | All 73 tests passed; targeted failure/provenance regressions retained |
| Test evidence | 5 | PASS | Six PR #12 CI jobs PASS; same integration commit passes local validator and 73 tests |
| Configuration readiness | 5 | PASS | Both workflows inspected, pinned actions, read-only permissions, no secrets or runtime config delta |
| Rollback readiness | 5 | PASS | Isolated source revert rehearsed; restores previous main tree exactly; no runtime/database target |
| Observability | 4 | PASS | GitHub per-job logs/results and actual local command output |
| Known issues handling | 5 | PASS | Initial P2 defects remediated; fresh independent 28-file release/security inspection found no confirmed findings |

## Decision

**PASS for technical release/security readiness and marking PR #12 ready for
review. BLOCKED for actual merge until explicitly authorized by the user.**

Blocking progression items:

1. Record named decision/support owners and explicit user authorization for
   the exact merge candidate and target. The current instruction prohibits merge.

Resolved since preparation: current integration CI and local checks are PASS;
source rollback is applicable and successfully rehearsed. Application/runtime
and database rollback have no target in the requested source-only promotion.
Fresh independent review is complete: see
[Carver's final release/security report](fac-003-final-security-release-review.txt).
Its disposition is PASS on source 1b4a84d, target 4df16e0 and integration 1769a9f.
No new source commit or generic human approval is inferred from that report.

The source candidate's technical checks PASS. This scorecard grants no merge,
tag, package publication, deployment or G6 closure approval.
