# Candidate ADR: Factory .NET Phase 1

Revision: 1. Status: proposed for human G2 approval; not accepted architecture. Author: Codex readiness executor. This is not independent security review. Requirement source: [Phase 1 specification](../specs/factory-runtime-phase1.md), candidate revision 1. Source repository base: `7ed5858e44bafbabf083022397ef97a4bb827dd2`.

## Decisions and alternatives

| Decision | Proposed choice and reason | Alternatives and consequences |
| --- | --- | --- |
| ADR-P1-01 | Retain one API project and one test project under runtime/dotnet; separate responsibilities by folders/interfaces. | Six assemblies introduce packaging overhead for this small slice. A single undifferentiated Program.cs is hard to test. Extract projects when later scope justifies them. |
| ADR-P1-02 | Use injected IChatClient and a provider-registration boundary; MAF ChatClientAgent via AsAIAgent implements both agents. | Direct provider construction inside ReviewAsync couples policy, credentials and orchestration and prevents isolated tests. Direct SDK-specific MAF adapters would unnecessarily narrow provider abstraction. |
| ADR-P1-03 | Keep explicit two-agent sequencing in the host. | Durable Workflows/checkpointing require state, retry/idempotency and operational requirements not selected for Phase 1. Do not describe the host sequence as durable orchestration. |
| ADR-P1-04 | Use syntax-only Roslyn ParseText with explicit C# 14 and rule options, never MSBuildWorkspace or assembly loading. | Semantic/solution analysis would expand ingestion and untrusted-build execution risks. Heuristic findings remain tentative and incomplete. |
| ADR-P1-05 | Default offline, loopback-only operation with explicit consent at the service boundary and no tools. | Shared/public hosting needs authenticated identity, authorization, quotas, retention and audit approval first. Request consent alone cannot establish enterprise data authorization. |
| ADR-P1-06 | Pin SDK 10.0.402 and the package candidate below; generate reviewed lockfiles only during approved BUILD. | Floating packages are not reproducible. Matching every dependency's patch number is not proof of compatibility. Restore/build and transitive audit must validate the candidate. |

## Component and execution contract

Program maps endpoints and registers validated typed options. Request validation and host restrictions run before source parsing or provider access. `IAnalysisService` owns one bounded analysis request and its cancellation; `IRuleScanner` returns deterministic findings/diagnostics; `IAgentReviewService` checks enablement and consent itself, then executes two MAF agents over an injected IChatClient. `ProviderRegistration` owns endpoint-bound credentials and reusable client lifetime. Avoid shared mutable agent sessions; each request has independent messages/session/run ID. Dispose host-owned clients at host shutdown and per-request resources when the run ends.

Use original source spans, stable rule IDs and SHA256-derived finding identifiers from source digest + rule ID + span coordinates. Include analyzer/rule-config version in provenance. Match identifier/member tokens exactly with explicitly defined case-insensitive comparison; do not search arbitrary expression text for business substrings. Parse diagnostics are returned without asserting business semantics. `fileName` is never a path capability.

The analyst gets bounded source + deterministic findings. The critic gets findings, source digest and analyst text; neither receives tools, secrets, repository access or approval actions. Treat both outputs as advisory strings and enforce the response contract. No free-form model output enters a gate evaluator.

API, state/error/resource/egress contracts are defined in the specification rather than duplicated here. No persistent state, migrations, generated code or UI is added. Cancellation propagates to parsing/traversal, agent runs and outbound HTTP. SDK transport retries are explicitly disabled; do not add retry middleware. Validate model output limits even if a provider ignores token settings. Full payload logging and HTTP-body telemetry are disabled.

## Dependency candidate and concrete incompatibility

See [observed manifest](../evidence/fact-004a/dependency-manifest.json) and [dependency assessment](../evidence/fact-004a/dependency-assessment.md). Published XML documentation from MAF 1.25.0 and MEAI.OpenAI 10.11.0 contains the adapter and agent APIs used by the prototype. This improves version-specific API evidence but does not prove binary or runtime compatibility.

| Direct dependency | Candidate pin | Rationale |
| --- | --- | --- |
| Microsoft.Extensions.AI | 10.11.0 | Retain prototype version; published metadata observed. |
| Microsoft.Extensions.AI.OpenAI | 10.11.0 | Retain provider adapter; requires OpenAI >= 2.14.0. |
| Microsoft.Agents.AI | 1.25.0 | Retain actual agent runtime; no Workflow package needed. |
| Microsoft.CodeAnalysis.CSharp | 5.9.0 | Retain scanner API; explicitly review its prerelease analyzer dependency. |
| OpenAI | 2.14.0 | Correct prototype's 2.13.0 downgrade against the adapter's declared minimum. |
| Microsoft.NET.Test.Sdk | 17.14.1 | Retain initially; actual .NET 10 discovery/run remains to verify. |
| xunit | 2.9.3 | Retain v2 test source. |
| xunit.runner.visualstudio | 3.1.4 | Retain; PrivateAssets=all in test project. |
| Microsoft.AspNetCore.Mvc.Testing | 10.0.13 | Add functional API tests, matching selected shared runtime patch. |

OpenAI 2.13.0 is a known dependency-constraint mismatch, expected to produce NU1605 under normal restore downgrade handling; this is inferred from nuspec, not an observed restore result. Do not suppress it. Roslyn's stable 5.9.0 package declares Microsoft.CodeAnalysis.Analyzers 5.9.0-1.26328.17; candidate acceptance must explicitly acknowledge this transitive prerelease, or select and re-review a different Roslyn version. Do not blanket-suppress analyzer warnings.

No vulnerability-free or complete transitive compatibility assertion is made. Unknown licensing/security/deprecation of the final resolved graph blocks BUILD acceptance. MIT and Apache-2.0 licenses observed for direct candidates do not establish a complete license audit.

## Threat boundaries and verification

| Boundary / threat | Required Phase 1 mitigation | Verification / remaining gap |
| --- | --- | --- |
| Client to loopback API: resource abuse, browser-origin traffic | Host/peer/Origin restrictions, body/character limits, finite request timeouts, four active requests/no queue | Real loopback startup/request tests plus TestServer contract tests. Local processes remain trusted; no enterprise auth claim. |
| Source to parser: malformed syntax, hostile projects | Parse text only, explicit language version, cancellation, no project/build/assembly loading | Negative fixtures and source review; no dynamic execution tests. |
| Source/model to agent: prompt injection | Untrusted-data framing, no tools/capabilities, immutable BLOCKED decision, bounded outputs | Fake model adversarial-response and invariant tests; prompts alone are not a security boundary. |
| Host to provider: source/credential disclosure, redirects | Explicit HTTPS endpoint allowlist, no redirects/retries/fallback, service consent and endpoint-bound secret | Mock transport tests; real endpoint/data approval and live provider tests remain out of scope. |
| Logs/evidence: sensitive data retention | Metadata-only operational logs; synthetic test fixtures; no model bodies or keys | Sentinel log tests and human diff review. Persistent tamper-evident audit is not implemented. |
| Package/CI supply chain | Pins, lockfiles, official SHA-pinned actions, read-only token, offline provider tests, dependency/static/secret checks | Real restore/audit/check results and independent security review required before acceptance. |

Security applicability remains BLOCKED until independent security review. No network penetration test or production target is authorized. Critical/High dispositions follow the unchanged canonical policy. Medium/Low assessment findings require named owners and deadlines; this candidate threat model assigns no fabricated severity or risk acceptance.

## Compatibility, rollback and approval

There is no deployed consumer contract to migrate. Renamed fields and structured provenance are intentional candidate changes, with the example/README updated together. The prototype's default domain term list is replaced by explicit sample configuration. No database or infrastructure rollback exists; runtime integration is additive and can be reverted by a separately authorized task. Do not alter root governance or historical archives.

Human approval is required for this candidate specification/ADR, dependency correction, disclosed analyzer prerelease and bounded runtime contract. G2/G3 remain BLOCKED until approved output revisions and role execution are recorded. No successor role is authorized by this file.
