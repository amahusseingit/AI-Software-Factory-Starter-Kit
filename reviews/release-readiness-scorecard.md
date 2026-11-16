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
| Test evidence | 5 | PASS | Fresh local run and six source CI jobs; release PR integration still needed |
| Configuration readiness | 5 | PASS | Both workflows inspected, pinned actions, read-only permissions, no secrets or runtime config delta |
| Rollback readiness | 3 | NOT_RUN | Previous source SHA and safe revert plan documented; no rehearsal performed |
| Observability | 4 | PASS | GitHub per-job logs/results and actual local command output |
| Known issues handling | 3 | UNKNOWN | Initial two P2 defects remediated; fresh release review/security disposition pending |

## Decision

**BLOCKED for final release/merge. Ready to open the review PR.**

Blocking progression items:

1. Verify current release PR integration check results and tested revision.
2. Obtain independent release review and explicit security disposition.
3. Record named decision/support owners and explicit user authorization for
   the exact merge candidate and target. The current instruction prohibits merge.
4. Resolve/document whether rollback rehearsal is applicable to this source-only
   promotion; no unexecuted rehearsal is claimed as evidence.

The source candidate's technical checks PASS. This scorecard grants no merge,
tag, package publication, deployment or G6 closure approval.
