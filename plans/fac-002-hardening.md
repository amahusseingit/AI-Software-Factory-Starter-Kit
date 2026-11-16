# FAC-002: Factory hardening and developer handoff

Actor: implementing Codex agent. This is developer evidence, not independent QA.
User task source: active chat goal, "continue till the factory is well harden
and strong enough to start using it". No synthetic user identity, approval ID,
independent reviewer or closure authorization is asserted.

## Baseline and boundary

- Repository: AI-Software-Factory-Starter-Kit.
- Actual input base: local main, 4df16e0b73b2410daaab3960a0b5a9e846f9971b.
- Working branch: task/fac-002-factory-hardening.
- Candidate: uncommitted working files; use content hashes for review.
- Remote develop diverges from main (observed 3 commits exclusive to main,
  2 exclusive to develop). This branch was created from the user's current
  merged main for local repair. The policy's normal develop topology has not
  been adopted for this candidate. Base/target reconciliation requires a human
  decision before publication/merge; no bootstrap exception is claimed.
- Changes: validator, portability tests, PowerShell wrappers, CI candidate,
  repository skill shim, adapter/role/handoff pointers and lifecycle documentation.
- Excluded: application implementation, production/network testing, installations,
  repository protection settings, publication, merge, deployment and closure.

## Requirement-to-evidence mapping

| ID | Acceptance behavior | Implementation | Evidence |
|---|---|---|---|
| F2-01 | Canonical validator runs on Windows with UTF-8 mode off | tools/validate_factory.py | Unicode CLI portability regression and real repository PASS |
| F2-02 | Git checkout newline conversion is handled without accepting content edits | tools/validate_factory.py; .gitattributes | Real temporary Git repository, CRLF, tamper and hash-negative tests |
| F2-03 | PowerShell callers use the canonical checks and exit codes | scripts/validate-factory.ps1; scripts/smoke-test-factory.ps1 | Both wrappers run successfully in PowerShell 7.6.9 |
| F2-04 | Native Codex entry uses canonical roles, plans and handoff | .agents/skills/factory/SKILL.md; skills/codex-factory-adapter/SKILL.md | Host catalog added factory; implementing and independent reviewer agents loaded the skill |
| F2-05 | Old role aliases cannot define competing gates | agents/role-registry.md; templates/handoff-contract-template.md | Pointers to maintained roles/templates; pending independent content review |
| F2-06 | Lifecycle docs include CLOSE and canonical decisions | docs/lifecycle.md; docs/commands-guide.md; commands/VERIFY.md | Static content review; duplicate skill lists removed from TEST/REVIEW |
| F2-07 | CI configuration checks Windows/Ubuntu without write permissions | .github/workflows/factory-validation.yml | Local candidate only; GitHub run NOT_RUN |
| F2-08 | Current governance failure cases stay blocked | tools/test_factory_gates.py; tools/test_factory_branches.py | Existing 61 tests retained; total suite now 70 PASS |

## Local validation and limitations

Python 3.14.3, Git 2.52.0.windows.1, PowerShell 7.6.9 on Windows.
Raw observed command output: [local checks](../evidence/fac-002-local-checks.txt).
Canonical repository validation, 70 synthetic/CLI/Git regressions and diff
whitespace checks passed. Test fixtures use temporary repositories and synthetic
identities. Archives and SOURCE_MANIFEST.json were not edited.

Security applicability: local governance, provenance and CI configuration.
Checks cover root/path confinement, tamper rejection, fail-closed approval and
security records. No application, dependency security scan, penetration test or
live GitHub protection assessment is claimed.

## Required next actions

1. Independently review the current file hashes/diff and rerun local checks.
2. Validate PowerShell failure propagation and CI syntax on the actual candidate.
3. Observe native skill activation in a fresh Codex session.
4. Resolve actual branch-base/target policy before any publication or merge.
5. Observe the proposed CI matrix when publication is explicitly authorized.

User explicitly authorized the independent reviewer in response to the chat
question about delegation: "Yes, use an independent review agent".
Reviewer Carver (agent 01a1e55f-69b8-7522-acd2-8c21892f0e6e) returned two P2
findings in the [initial independent report](../reviews/fac-002-independent-initial.txt).
No G4 acceptance, G5 release or G6 closure is recorded.
Factory hardening remains active until these remaining acceptance gaps are
resolved. A consuming project's missing SRS is a separate application-entry
dependency, not a failed generic Factory check.

## Remediation iteration

F2-03/F2-08: tools/run_factory_tests.py now requires all three mandatory suites
to exist, import and contain tests. PowerShell and CI use this entry point.
Partial suites and empty modules have regression tests.

F2-02: all 314 source blobs were read from Git and verified to contain no CR
bytes. Archive attributes now use text=auto eol=lf, preserving these LF text
blobs through fresh checkout and staging in older CRLF clones. A temporary
repository regression performs upgrade, stat invalidation, git add -A, commit
and post-commit provenance validation. Binary files retain auto detection.
Archives and manifest in the real repository remain unchanged.

Workflow actions are pinned to verified current tag commits: checkout v4
11d5960a326750d5838078e36cf38b85af677262 and setup-python v5
a26af69be951a213d495a4c3e4e4022e16d87065, obtained using git ls-remote.
The updated local suite has 73 passing tests. Independent regression/re-review
on this iteration remains pending. Earlier 70-test evidence is historical and
does not establish approval for this changed candidate.
