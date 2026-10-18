> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Evidence record
TEMPLATE ONLY, NOT EVIDENCE. All fields must be populated from actual observation.
- evidence_id / task_id / run_id / actor / independent reviewer
- repository / task branch / base SHA / candidate_revision / scope_hash / plan_hash
- SRS revision and requirement / story / AC IDs
- approval source ID and approved role/action
- check ID / required applicability / check state
- method or exact command / tool and version / environment identity
- UTC start/end / actual exit code (commands only)
- raw output immutable link and SHA256 / artifact paths and hashes
- expected and observed result / defects / limitations / retest reference
- previous entry hash / supersedes entry ID when correcting

Check states and decision rules are in [gate-contract.json](../governance/gate-contract.json). Unavailable tools are NOT_RUN; no invented results. Documentation checks cannot satisfy application test requirements.
