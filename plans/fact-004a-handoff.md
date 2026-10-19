# FACT-004A readiness handoff

Role: coordinator/readiness preparation. Actor: Codex. Run: fact-004a-readiness-20261019. Input: develop `7ed5858e44bafbabf083022397ef97a4bb827dd2`. Actual local branch: `task/fact-004-a-dotnet-runtime-readiness`. Output artifact hashes: [output manifest](../evidence/fact-004a/output-manifest.json); output Git commit is supplied in the final conversation to avoid a self-referential commit claim. No remote branch or PR is published by this handoff.

## Delivered for review

- [Candidate Phase 1 specification](../specs/factory-runtime-phase1.md): requirements/stories, explicit API/resource/egress boundaries and AC-01 through AC-10.
- [Candidate ADR](../adrs/factory-runtime-phase1.md): minimal project structure, injected provider boundary, actual MAF agents, host sequencing, syntax-only Roslyn, failure and security boundaries.
- [Observed dependency manifest](../evidence/fact-004a/dependency-manifest.json) and [assessment](../evidence/fact-004a/dependency-assessment.md): exact versions, declared constraints, version-specific XML API evidence, licenses and SDK metadata; no compatibility certification.
- [Developer proposal](fact-004b-developer-plan.md) and [planned traceability](fact-004b-traceability.md): bounded allowlist, evidence/check strategy and independent-role stop points. Successor task/branch not created.

## Actual findings and evidence

OpenAI 2.13.0 conflicts with the selected adapter's declared minimum 2.14.0. Candidate correction is 2.14.0; expected restore downgrade diagnostic is an inference, not an executed failure. Roslyn 5.9.0 declares a prerelease analyzer dependency; its acceptance is a human decision. Public package XML confirms five relevant adapter/agent members, but no compiler or runtime validation occurred. SDK candidate: 10.0.402, shared runtime 10.0.13. New candidate API test package: MVC.Testing 10.0.13. Secret/static analysis tools and immutable download/action metadata are specified in the developer proposal; none were executed.

Actual documentation self-check: Factory validator PASS; 61 synthetic Factory evaluator tests PASS; final staged whitespace check PASS. Initial staged whitespace FAILED because raw NuGet responses used CRLF; that result and original output are retained in evidence/fact-004a/check-results-initial-staged.json and compressed raw logs. All downloaded metadata is now stored losslessly compressed, with original/compressed hashes retained. Exact final commands, UTC times, environment, exit codes and raw hashes are in [check results](../evidence/fact-004a/check-results.json). These are documentation/evaluator checks only. Application restore/build/tests, transitive vulnerability audit, independent QA, independent review and independent security are NOT_RUN. They do not inherit any result from FACT-003.

The original approval is the latest user `Approved` following the FACT-004A-only request. Its stable message ID and original issued timestamp are not exposed; evidence records this rather than manufacturing identifiers, identity claims or timestamps. Authorization is bounded to this readiness scope and completion. Newly produced documents are candidates, not human-approved G1/G2 deliverables. Separate roles have not executed.

## Remaining decisions and blockers

| Decision or missing evidence | Owner | Disposition |
| --- | --- | --- |
| Accept exact candidate SRS/ADR, API changes/resource limits, OpenAI correction and Roslyn analyzer prerelease | Requesting human | PENDING; output-specific approval required. |
| Choose readiness-document integration path and exact developer input base | Requesting human | PENDING; no merge inferred. Developer proposal permits explicit content-hashed carry-forward only if authorized. |
| Approve developer role execution and draft-PR publication scope | Requesting human | PENDING; FACT-004B has not started or been delegated. |
| Real .NET restore/build/test and complete dependency/security checks | Future approved developer | NOT_RUN; SDK is not installed in readiness environment. |
| Name independent QA/security/reviewer and approve their plans | Requesting human / coordinator | PENDING; developer self-check cannot satisfy G4. |
| Verify live PR checks/integration SHA and detailed branch protections | Future approved task roles | NOT_RUN; no repository settings changes authorized. |

No security finding severity, owner acceptance, approved exception or passed gate is invented. Candidate threat assessment is not independent security evidence. Overall progression decision: BLOCKED. SHIP is outside this documentation-only scope; CLOSE, merge and deployment are not authorized.

## Stop point

Review this exact content/commit, then approve the candidate requirements/architecture or request changes. A successor's exact base, role plan and execution approval must be established before any runtime change. Current task produces only readiness artifacts and append-only truthful records. No successor role, implementation, release or closure has started.
