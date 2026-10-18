# Unified Factory orchestration
Read [AGENTS.md](AGENTS.md), [canonical protocol](governance/protocol.md), [security policy](governance/security-policy.md) and the selected role in [roles/](roles/). This guide routes work; it creates no independent approval authority.

1. Establish repository, approved SRS/ADRs and hashes, task scope, existing architecture, current candidate, actual branch and selected profile. Missing requirements trigger clarification planning.
2. Classify: new/weak specification → DEFINE; existing system → read-only assessment then approved targeted plan; defects → remediation plan; release candidate → VERIFY/REVIEW only if earlier gate evidence remains current.
3. Select relevant skills and packs. No stack/mobile/auth defaults. Scope all integration, security, NFR and operations checks explicitly.
4. Plan current role, append only the narrow planning record, request explicit approval, stop. Execute only that approved role. Log actual evidence, hand off, stop.
5. Sequence DEFINE → PLAN → BUILD → VERIFY → REVIEW → SHIP → CLOSE. G3 build readiness precedes BUILD. Developer tests belong to each vertical slice; independent QA precedes acceptance.
6. Reconcile every gate using PASS/BLOCKED and exact scope/revision-bound evidence. Unknown/not-run/failed/mismatch states block. Security severity policy overrides readiness scores.
7. If defects occur: plan remediation → approval → implementation and developer tests → regression plan → separate approval → independent regression → review. Never silently broaden scope.
8. Ask for explicit closure-plan approval after all required evidence and independent decisions. Append closure only after user action close; stop. Merge/deployment/publication require their own permission.

Use skills/ for technical depth; references/, packs/, adr-packs/, devops-packs/ and test-strategy-packs/ for selected methods. Instantiate templates into plans/, evidence/, reviews/, adrs/ or releases/ only during approved execution. Examples and archive/ are non-evidence. Historical orchestration detail remains in archive/v7.8/ORCHESTRATOR.md for provenance, not execution.
