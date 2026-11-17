# FACT-005 developer acceptance traceability

Requirement source: approved specs/factory-runtime-phase1.md at readiness commit `685cf8784fff62b862a13552f02c7773d3115dae`. Architecture/plan hashes and human approval sources: evidence/fact-005/authorization.json. Developer evidence snapshot: remote candidate `5a47a944efd8b8404cad45f2d305673172237784`, source tree `b6d1656817e5b76e0d7bc64b1631940b9f9f3dea`, tested merge `1d6f7fc29e36d872f7990e3b06241615e617fca1`, develop target `7ed5858e44bafbabf083022397ef97a4bb827dd2`.

Raw output, job times/URLs, archive/artifact hashes and actual results: [hosted-validation.json](../evidence/fact-005/hosted-validation.json). Test project is runtime/dotnet/tests/Factory.Tests; implementation is runtime/dotnet/src/Factory.Api plus scoped configuration. All cases synthetic; actual MAF agents use fake IChatClient, provider transport uses mock handlers, hosting checks execute the trusted API assembly only. No submitted source is executed.

| AC | Implementation | Actual executable proof | Developer state | Independent reviewer / acceptance |
| --- | --- | --- | --- | --- |
| AC-01 | SDK/central pins/projects/lockfiles | Hosted locked restore, Release build, zero warnings/errors, actual 104-test discovery | PASS | Unassigned; NOT_RUN |
| AC-02 | RoslynRuleScanner, contracts | ScannerTests.OriginalUnicodeCrLfOffsetsDigestAndIdsAreRepeatable; MultilineEvidenceIncludesOriginalTriviaAndUsesStartCoordinates; LineDirectivesCannotForgeOriginalSourceCoordinates | PASS | Unassigned; NOT_RUN |
| AC-03 | Scanner/configuration/diagnostics | ScannerTests operand-order, exact-token, exclusion, no-default-domain, invalid-syntax, cancellation and config-provenance cases | PASS | Unassigned; NOT_RUN |
| AC-04 | FactoryAgentService consent; API/service boundaries | AgentTests.DirectServiceRequiresEnablementAndConsent; ApiTests.EnabledApiStillRequiresConsentAndValidSyntaxAndRetainsFindingsOnProviderFailure | PASS | Unassigned; NOT_RUN |
| AC-05 | Actual MAF agents/injected IChatClient | AgentTests.ActualMafAgentsRunSequentiallyWithGroundingAndNoTools; AnalysisServiceTests.ConcurrentRunsUseSeparateGroundedMessagesAndNeverGrantApproval | PASS | Unassigned; NOT_RUN |
| AC-06 | Deadline/output/cancellation and findings retention | AgentTests invalid/oversized/exact output, first/second-agent failure/cancellation/deadline cases; AnalysisServiceTests.CompletedDeterministicFindingsSurviveEitherAgentFailure | PASS | Unassigned; NOT_RUN |
| AC-07 | Readonly BLOCKED decision and no tools | ApiTests.HealthIsLivenessAndAnalysisCannotApprove; MAF no-tools/untrusted-output/session tests; developer source inspection | PASS | Unassigned; NOT_RUN |
| AC-08 | ProviderRegistration, LocalHostPolicy, sanitized error/log policy | ProviderTests endpoint/allowlist/key/redirect/retry/cancellation/disposal; LocalHostPolicyTests; real HostingTests; ApiTests.UnexpectedFailuresAreGenericAndLogsNeverContainSensitivePayloads | PASS | Security reviewer unassigned; NOT_RUN |
| AC-09 | API validation/body/concurrency middleware | ApiTests media/JSON/body/field/syntax/unknown-length boundaries, caller isolation and four-active/fifth-rejected including trailing slash; real HostingTests | PASS | Unassigned; NOT_RUN |
| AC-10 | Workflow and evidence/approval records | Six successful hosted jobs on exact task head and PR integration result; raw/hash/revision records retained | BLOCKED | Independent QA/security/reviewer not named or executed; no human acceptance |

Developer runtime suite: 104 passed, zero failed/skipped. Existing Factory evaluator tests are separate synthetic governance checks; they do not prove application behavior or enforce live branch settings. Automated security findings: zero reported NuGet/gitleaks/CodeQL findings, not full security certification. No G4 acceptance, G5 release or G6 closure decision is granted.

An evidence-only handoff commit must receive fresh hosted checks on its exact head/merge; those final immutable links are recorded in the final conversation/PR without a circular self-referential commit claim. A stale earlier result alone does not qualify the later candidate.
