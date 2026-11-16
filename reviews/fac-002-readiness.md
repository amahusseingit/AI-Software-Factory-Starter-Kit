# FAC-002 technical readiness

Technical recommendation: **PASS for governed local Factory use**.
This is a technical readiness assessment, not human acceptance, G5 release,
G6 closure, merge authorization or a claim of installed GitHub enforcement.

## Candidate and independent assessment

- Input base: 4df16e0b73b2410daaab3960a0b5a9e846f9971b.
- Branch: task/fac-002-factory-hardening; changes remain uncommitted.
- Requirement mapping: [FAC-002 plan and handoff](../plans/fac-002-hardening.md).
- Implementer: parent Codex agent in the current chat.
- Independent reviewer: Carver, agent 01a1e55f-69b8-7522-acd2-8c21892f0e6e.
- User authorization: "Yes, use an independent review agent", in reply to the
  question about independent review and checks. No invented human identity or
  broader approval is asserted.
- Initial review: [BLOCKED with two P2 findings](fac-002-independent-initial.txt).
- Independent regression: [PASS after remediation](fac-002-independent-regression.txt).
- Core hashes from that report were compared with current files and matched.
  Review binds file content hashes, not a nonexistent output commit.

## Completion audit

| Requirement | Current evidence | Technical outcome |
|---|---|---|
| One lifecycle/approval authority | AGENTS/ORCHESTRATOR point to protocol/security/contract; VERIFY/TEST mapping and CLOSE documented | PASS |
| Canonical roles and handoff | Adapter and legacy aliases route to roles/ and maintained plan/handoff templates | PASS |
| Native Codex discovery | factory skill appeared in host catalog and was loaded by parent and independent reviewer | PASS |
| Commands select existing specialist skills | Validator resolves command skill references; duplicate TEST/REVIEW lists removed | PASS |
| Windows Unicode validation | Explicit UTF-8 reads; real CLI regression with UTF-8 mode disabled; Windows repository validator PASS | PASS |
| Archive provenance and safe staging | Exact Git blob hash plus constrained checkout conversion; tampering rejected; full legacy upgrade/stage/commit regression | PASS |
| Reliable acceptance runner | Missing, empty or unimportable mandatory suites block; wrapper and CI use canonical runner | PASS |
| Developer and independent verification | 73 tests pass in Windows and Ubuntu; independent reviewer reran Windows checks and adversarial reproductions | PASS |
| CI source configuration | YAML parsed; read-only permissions, disabled stored checkout credentials, pinned action commits, four OS/Python combinations | PASS for source configuration only |
| Source preservation | Real archive/ and SOURCE_MANIFEST.json diff is empty | PASS |

## Command evidence

- [Final Windows wrapper/validation/test output](../evidence/fac-002-remediation-windows.txt).
- [Ubuntu result excerpt and transcript reference](../evidence/fac-002-remediation-linux.txt).
- Windows: Python 3.14.3, Git 2.52.0.windows.1, PowerShell 7.6.9.
- Ubuntu WSL: Python 3.14.4, Git 2.53.0.
- Independent checks also covered Windows PowerShell, failing/missing inputs,
  partial suites, binary archive bytes, Unicode paths and child exit propagation.

No remaining technical blockers were confirmed in the bounded independent
review. Existing synthetic approval/security/branch tests remain diagnostic
evidence, never authentication or live enforcement.

## Use and remaining boundaries

Run from the repository root:

```powershell
python -B tools/validate_factory.py
python -B tools/run_factory_tests.py
```

Then invoke the factory skill or explicitly load
skills/codex-factory-adapter/SKILL.md. For a consuming project, first identify
authoritative requirements, approved profile/architecture inputs and the shared
log, then present the DEFINE/SPEC role plan. Application BUILD still requires
its own approved requirements, architecture, slice plan and test strategy.

Before publication or integration, obtain the actual base/target decision:
this local branch starts at the merged main while develop has diverged. No
topology exception or publication permission is assumed. Live GitHub CI and
Python 3.10 execution remain NOT_RUN. Repository protection settings have not
been changed or verified. These are promotion/coverage limits; local execution
on the observed Windows/Ubuntu environments has current technical evidence.

The later independent regression supersedes the plan's earlier pending-review
status and its historical 70-test results for technical assessment only. No
Factory closure entry or application completion record has been manufactured.
