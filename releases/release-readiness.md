# Release readiness: Factory hardening baseline

Prepared 16 November 2026 for the explicitly requested develop-to-main PR.
Assessment artifact owner: Codex release-readiness assessor in this chat.
Process authority: [canonical protocol](../governance/protocol.md) and
[security policy](../governance/security-policy.md).

**Final technical release/security review: PASS. Ready-for-review transition
authorized. Final merge remains BLOCKED pending explicit human merge approval
and confirmation of accountable release/support owners.**
The user's instruction explicitly prohibits merge at this stage.

## Exact candidate and evidence packet

| Identity | Observed value |
|---|---|
| Repository | amahusseingit/AI-Software-Factory-Starter-Kit |
| Release head | develop: 1b4a84d128423d7cc8861e08b3ceb15fb231c525 |
| Reviewed source tree | 2f0938f41418ce4b3ec360af3320ba1982e5733e |
| PR #12 tested integration | 1769a9fbe82dffca4e6a74c4200174d5b14a84b7; same tree as source |
| Target at preparation | main: 4df16e0b73b2410daaab3960a0b5a9e846f9971b |
| Included delta | Five commits, 28 changed files relative to main |
| Existing VERSION | unified-1.0.0-draft.1; unchanged; no new tag or version claim |
| Assessment branch | task/fac-003-release-readiness |
| User scope | Prepare assessment and create PR; do not merge |

The packet is intentionally stored outside the frozen release source and linked
from the PR by its own immutable commit. It is not a second development branch
or an extra release commit. Merging this evidence branch into develop would
change the candidate and require new qualification.

## Included scope

- Codex repository skill discovery and canonical role/handoff pointers.
- Explicit lifecycle command mapping and verification/closure documentation.
- Windows UTF-8 and Git line-ending/provenance compatibility.
- Fail-closed acceptance runner requiring gate, branch and portability suites.
- Factory CI and cross-platform validation workflows using pinned actions,
  read-only token permissions and no persisted checkout credentials.
- Historical local/independent review evidence with its original revision limits.

No APERTURE implementation, database, migrations, application dependencies,
credentials, hosting or repository protections are changed. The Factory remains
generic. A consuming project still needs approved requirements before BUILD.

## Verification and traceability

| Check | Evidence | Result |
|---|---|---|
| Canonical validator | [Actual local output](../evidence/fac-003-release-checks.txt), Python 3.14.3, Windows | PASS, exit 0 |
| Complete acceptance suite | Same output, all 73 tests through tools/run_factory_tests.py | PASS, exit 0 |
| Source archives and manifest | git diff main..develop -- archive SOURCE_MANIFEST.json | PASS, unchanged |
| PR #11 integration | Candidate 40f35f2df21bd58560d3aaa6222335be1414b6fc merged to source 1b4a84d | Observed merged |
| Source CI matrix | [Run 43920607340](https://github.com/amahusseingit/AI-Software-Factory-Starter-Kit/actions/runs/43920607340), source 1b4a84d | Four jobs PASS |
| Source Factory CI | [Run 43920607587](https://github.com/amahusseingit/AI-Software-Factory-Starter-Kit/actions/runs/43920607587), source 1b4a84d | Two jobs PASS |
| Prior independent review | [FAC-002 regression](../reviews/fac-002-independent-regression.txt) | Historical PASS bound to its documented hashes |
| Fresh independent release/security review | [Carver final report](../reviews/fac-003-final-security-release-review.txt), exact source/base/integration identities above | PASS; no confirmed severity findings in scope |
| PR #12 integration CI | [Matrix 43922672484](https://github.com/amahusseingit/AI-Software-Factory-Starter-Kit/actions/runs/43922672484), [Factory CI 43922672489](https://github.com/amahusseingit/AI-Software-Factory-Starter-Kit/actions/runs/43922672489) | All six jobs PASS |
| Integration checkout and local tests | [Final integration/rollback evidence](../evidence/fac-003-final-release-checks.json); CI log confirms checkout 1769a9f | Validator PASS; 73 tests PASS |

Exact successful GitHub job names observed on source 1b4a84d:

- factory-docs (Ubuntu 24.04, Python 3.12)
- factory-gate-tests (Ubuntu 24.04, Python 3.12)
- factory-validation (windows-latest, Python 3.10)
- factory-validation (windows-latest, Python 3.14)
- factory-validation (ubuntu-latest, Python 3.10)
- factory-validation (ubuntu-latest, Python 3.14)

Each release PR check must succeed on its actual tested integration revision.
Source successes do not authorize an untested conflict resolution or a moving
target. GitHub has now created the integration commit above. Its parents are
the exact target and source; its tree equals the reviewed source tree.
The factory-gate-tests job log confirms checkout of that integration revision
and execution of all 73 tests. New decisions bind to those exact identities.

## Source artifact, environments and configuration

A local source TAR was generated directly from the frozen Git commit:

- Command: git archive --format=tar --output=<path> 1b4a84d128423d7cc8861e08b3ceb15fb231c525
- Artifact: factory-1b4a84d.tar, 1,587,200 bytes.
- SHA-256: 5fc2c9d1b6924f2b842c7f23977f47849803b6e26dbc75f9a07c0a4b4b934505
- Local path: C:/Temp/factory-release-54d472219cc343eab37d1e9a15e3e7dc/factory-1b4a84d.tar

This digest identifies a generated source package, not a published/signed
release or separately tested runtime binary. The tests executed the matching
source tree. If a source package is later published, reproduce and compare the
digest; a changed source, tag, package or build requires requalification.

Affected environments are the Factory checkout and GitHub-hosted CI only.
Python 3.10+ and Git are the validation prerequisites; PowerShell wrappers are
optional. No package installation, database migration, configuration secret,
production connection or application environment is required by these workflows.
No application profile is selected. There is no staged/production runtime
deployment in this requested source-promotion scope.

## Proposed promotion and smoke checks

1. Open the release PR from develop to main and state both observed full SHAs.
2. Prevent unreviewed additions: immediately before approval/merge, confirm
   develop remains 1b4a84d and inspect any target movement.
3. Require current integration checks, review conversations resolved, independent
   release review/security disposition and explicit user approval to merge.
4. Only after separate approval, merge the reviewed candidate using the agreed
   GitHub method. Do not infer deployment, version tagging or closure.
5. After an authorized merge, verify main's tree against the reviewed source
   tree, observe main CI and rerun validator/acceptance tests in a clean checkout.
6. Smoke-check that the factory skill is discoverable and role routing still
   requires approved requirements/plans. Missing APERTURE requirements must
   continue to block application BUILD.

Inspect both workflow logs if checks fail; record actual exit codes and exact
commit/tree. A failed, missing, cancelled or stale required check blocks merge.
No changes to branch-protection settings or automatic merging are requested.

## Rollback and operational ownership

The previous main SHA above is the source rollback reference. No database or
application data needs rollback. If a later authorized release merge is faulty,
prepare a new reviewed task/hotfix from the verified released baseline and
propose a Git revert of the specific release merge (mainline parent 1 when
applicable), then rerun checks and obtain separate authorization. Never reset
or force-push main. A source package can be replaced by the previously approved
package only through its own publication decision.

Source rollback applies and was rehearsed in a disposable local clone: checkout
the exact PR integration commit, then run git revert --no-commit -m 1 against
that commit. The resulting index and worktree restored the previous main tree
cee0d0ce81cdfb2919d3b6ce0e4b458da75e1667 exactly. The validator and 73 tests
also passed in that clone before rollback. See the final evidence JSON above.
No real branch moved, no rollback commit was created and no GitHub merge ran.
This rehearsal covers merge-commit promotion. A squash/rebase strategy would
require the corresponding source rollback procedure to be checked separately.
Restoring the old main also restores its historical Windows-validation and
tooling limitations. The rehearsal proves exact source reversal, not that the
older baseline passes the new 73-test runner. Evaluate that tradeoff before any
real rollback; the successful local suite ran before the isolated revert.

Application/runtime, database, infrastructure and credential rollback have no
target in this approved Factory-source-only promotion. This applicability
assessment waives no known vulnerability or required source check. A real
future rollback must identify the actual released merge/tag/artifact and receive
its own authorization. The repository owner must confirm the human merge and
support/rollback owners before merge approval; no signatures are manufactured.

## Security, findings and remaining gates

Security applicability is Factory tooling/provenance and GitHub Actions supply
chain. Controls observed: pinned official action commits, contents: read, no
configured secrets, persisted Git credentials, privileged pull_request_target
execution or deployment steps. Synthetic tests cover denied/expired approvals,
self-signoff, missing/stale evidence and security-severity blockers. These are
contract checks, not authentication, application scanning or penetration tests.

The two known FAC-002 P2 findings were fixed and independently retested on the
historical reviewed patch. That earlier report is not substituted for the fresh
final review. Carver, agent 01a1e55f-69b8-7522-acd2-8c21892f0e6e, independently
inspected the complete 28-file Git-object delta, file hashes, all 314 archived
source hashes and actual PR CI logs, and verified the disposable rollback result.
The final bounded release/security recommendation is PASS, with no confirmed
CRITICAL, HIGH, MEDIUM or LOW findings in that scope. The source hash-manifest
digest in the report is a6f8cfe3a6a802e6a3a812a5d31d1a40252fd2bdce6d33adee3679724a296dca.

This is a current manual source/CI/provenance security assessment. No scanner,
penetration-test, application-security or branch-protection attestation is
claimed. PT/application tests have no application target in this Factory-only
source promotion. The explicit source security disposition is PASS; no security
exception or risk waiver was requested or granted.

| Remaining item | State | Required owner/action |
|---|---|---|
| Fresh release PR integration checks | PASS | Six current PR #12 jobs on the recorded integration result |
| Independent final release review and security disposition | PASS | Carver's fresh exact-candidate review; scoped manual assessment |
| Human merge authorization | NOT_RUN | User must explicitly authorize exact candidate and target |
| Source rollback rehearsal | PASS | Isolated revert restores previous main tree exactly |
| G6 closure, tag, published release, deployment | Outside current requested execution | Separate authorization if requested later |

Prepare/create-PR and ready-for-review authorization are not merge permission.
Current outcome: packet technically PASS and ready for human review; final
merge remains blocked by the user's explicit do-not-merge instruction until a
separate current authorization is received. Named accountable human release
and support ownership must be confirmed at that decision, not fabricated here.

## Current review authorization

The user subsequently requested: complete the final release and security review,
confirm rollback applicability, and mark PR #12 ready for review, but do not
merge it yet. This authorizes the bounded review/status update and supporting
evidence publication, not merge, deployment or a GitHub self-approval. The
frozen source and target must remain unchanged through the final status check.
