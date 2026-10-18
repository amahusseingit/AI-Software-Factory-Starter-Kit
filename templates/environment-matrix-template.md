> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Environment Matrix

| Environment | Purpose | URL/Host | Data policy | Deployment trigger | Smoke tests | Notes |
|---|---|---|---|---|---|---|

Record verified branch/event-to-environment mapping, runtime identity/secret scope (never values), database/storage/external-service isolation, artifact digest, deployment approver and observed deployed SHA. Staging need not have a branch. Unknown mappings block deployment changes; development and PR jobs must have no production secrets/data or write access.
