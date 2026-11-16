> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Release Readiness: <Release>

## Included scope
## Environments impacted
## Migrations
## Configuration / secrets
## Deployment order
## Rollback plan
## Smoke test checklist
## Monitoring and logs to watch
## Known risks
## Sign-off

## Exact release and promotion identity
Follow the [branch policy](../governance/branch-environment-policy.md). Record frozen source SHA, tested merge SHA, immutable artifact digest/provenance, staging acceptance, configuration delta, required check names/results, independent approvals, target environment and separate merge/deployment authorization. Promote the same tested artifact. Factory kit versioning is separate from any application deployment. Hotfixes require exact production tag/SHA and a tracked, separately approved reconciliation PR. Unknown deployment mapping blocks changes.
