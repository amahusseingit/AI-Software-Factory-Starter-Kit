# Dependency and prototype assessment

Task: FACT-004A / fact-004. Actor: Codex readiness executor; independent review NOT_RUN. This is static source and published metadata assessment. No .NET restore, compilation, tests, assemblies or prototype code were executed.

## Observed sources

All 13 ZIP text files were read. Archive and per-file hashes are in [prototype inventory](prototype-inventory.json). Source inputs at the pinned develop revision are in [input manifest](input-manifest.json). NuGet index/nuspec fetch URLs, UTC observations, HTTP results and hashes are in [dependency manifest](dependency-manifest.json). Raw nuspecs and index snapshots are retained under raw/. Package XML documentation and official SDK release JSON are retained losslessly as gzip, with both compressed and original hashes.

The SDK metadata selects .NET SDK 10.0.402/shared runtime 10.0.13; the official Linux x64 download URL/hash is recorded, but no SDK installation was performed. Metadata availability is not download integrity verification or build proof.

## Concrete package findings

All eight prototype direct versions exist in observed NuGet indexes. Microsoft.Extensions.AI.OpenAI 10.11.0 declares OpenAI minimum 2.14.0 for net10.0, conflicting with the prototype's direct 2.13.0 reference. Expected outcome under normal SDK downgrade handling: NU1605; actual restore result NOT_RUN. Candidate correction: OpenAI 2.14.0. Do not claim an observed build failure or suppress the dependency warning.

Microsoft.Agents.AI 1.25.0 declares minimum MEAI 10.10.0 / abstractions 10.10.1, so the selected 10.11.0 versions satisfy those declared minimums. That is not a complete dependency-graph or binary compatibility result. OpenAI 2.14.0 declares System.ClientModel >= 1.15.0. Roslyn CSharp 5.9.0 requires Common exactly 5.9.0 and declares a prerelease analyzer dependency 5.9.0-1.26328.17. Its build/analyzer asset exclusion is preserved in raw metadata; do not infer that a stable top-level version means every resolved package is stable.

Direct candidate licenses observed: MIT for Microsoft/OpenAI packages, Apache-2.0 for xunit and its runner. Full resolved/transitive license, deprecation and vulnerability checks remain NOT_RUN. Microsoft.AspNetCore.Mvc.Testing 10.0.13 is a new candidate dependency for API testing; its declared TestHost/Hosting graph is captured, not executed. Retain existing test SDK/xunit initially and verify actual test discovery/execution under .NET 10 before acceptance.

## Version-specific API evidence

[API member excerpts](api-members.json) retain five exact member definitions from the selected published package documentation: OpenAIClient credential/options constructor, ChatClient.AsIChatClient, IChatClient.AsAIAgent, AIAgent.RunAsync(string,...,CancellationToken), and AgentResponse.Text. This directly supports the adapter/agent pattern beyond the earlier moving-main source inspection. Optional/named-argument source compatibility, analyzer diagnostics and runtime behavior still require compilation. No definite additional C# compiler error is asserted by inspection.

## Per-file disposition

| Archive file | Assessment | Disposition for proposed BUILD |
| --- | --- | --- |
| AGENTS.md | Local source-only/advisory boundaries; host governance remains authoritative. | Adapt under runtime/dotnet, never replace root authority. |
| README.md | Truthfully marks unbuilt source; prerequisites omit reproducible SDK/graph and test evidence. | Update exact pins, loopback/default offline usage and limitations. |
| .gitignore | Runtime artifact exclusions are appropriate. | Keep scoped under runtime/dotnet. |
| docs/INTEGRATION-PLAN.md | Proposal only; original task ID/base not a grant of authority. | Superseded by approved bounded host-repository plan; preserve provenance, not duplicate authority. |
| examples/analyze-request.json | Synthetic example, no outbound consent. | Retain synthetic data and explicitly configure detector terms. |
| tests/Factory.Tests/RoslynRuleScannerTests.cs | Three scanner examples; no API/service/MAF/security/failure coverage. | Preserve meaningful intent and add mapped negative/boundary/integration tests. |
| tests/Factory.Tests/Factory.Tests.csproj | net10.0 test target; discovery and runner compatibility not executed. | Centralize pins, private test assets, add MVC.Testing and lockfile. |
| src/Factory.Api/Program.cs | Basic validation and immutable BLOCKED output; consent only here, failures lose normal analysis response. | Thin endpoint with service enforcement, body limits, controlled status/error retention and loopback policy. |
| src/Factory.Api/appsettings.json | AI disabled by default; wildcard hosts and unconstrained endpoint/model. | Explicit typed validated options, no endpoint/secret fallback, source-free logs. |
| src/Factory.Api/Factory.Api.csproj | Known OpenAI downgrade; warnings not treated as errors; no lockfiles/SDK pin. | Correct pin, warnings-as-errors and deterministic restore. |
| src/Factory.Api/Contracts/AnalysisModels.cs | Misleading IndependentCritique and noncanonical REVIEW severity; limited source provenance. | AdvisoryCritique/reviewPriority and source span/digest/version contracts. |
| src/Factory.Api/Analysis/RoslynRuleScanner.cs | Substring domain heuristic, null/bool matches, ignores diagnostics, reverses literal-first evidence and order-based IDs. | Exact configured identifier rules, explicit language version, original spans, stable provenance and parse handling. |
| src/Factory.Api/Agents/FactoryAgentService.cs | Actual MAF API pattern; inline client/secrets, no service consent, limits, endpoint allowlist or grounded critic context. | Injectable IChatClient, host lifetime, per-request sessions, policy/timeout/output bounds; no tools. |

## Security and readiness disposition

Candidate threat boundaries are in the ADR. Outbound code/key disclosure, public exposure, prompt data, resource exhaustion, source/secret logging and package supply chain require implementation tests and independent security disposition. Findings have not been assigned an invented independent severity. Security readiness is BLOCKED while assessment remains incomplete; no risk acceptance is implied.

Readiness artifacts support human decisions, not application acceptance. G1/G2 output acceptance, G3 developer execution and G4 independent QA/review/security remain pending. Scope is local advisory analysis only; enterprise operation is not authorized.
