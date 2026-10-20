# Phase 1 developer execution proposal

Revision: 1. Status: NOT APPROVED; no developer execution delegated. Display successor: FACT-004B. Reserve a fresh canonical numeric task ID, proposed `fact-005`, after uniqueness verification. Proposed branch: `task/fact-005-integrate-dotnet-runtime`. This normalizes the earlier alphanumeric display ID; it is not a created branch.

## Readiness and approval prerequisites

Human approval must bind the exact [SRS](../specs/factory-runtime-phase1.md), [ADR](../adrs/factory-runtime-phase1.md), [dependency candidate](../evidence/fact-004a/dependency-manifest.json), traceability and this plan. No G1/G2/G3 PASS is asserted. An authenticated approval source, actor and bounded expiry must be recorded without manufacturing IDs/timestamps. Independently review security applicability and name the downstream QA/reviewer/human decision owner before acceptance. No developer self-signoff.

Input base remains proposed develop `7ed5858e44bafbabf083022397ef97a4bb827dd2` until readiness documents are integrated through separately authorized review/merge. If develop changes, present and obtain approval for its exact new full SHA; do not silently merge readiness or start from an unapproved branch. If readiness is not integrated, explicitly approve carrying these content-hashed documents into the implementation task branch. The current readiness commit is an artifact revision, not automatically an approved develop baseline.

## Environment and effects

Use Codex Cloud, preferably named factory-dotnet10. Current environment name is not established. Require Linux x64, genuine Git clone, .NET SDK 10.0.402/shared runtime 10.0.13, Python 3.12, Git, trusted CA/proxy configuration, access to GitHub/NuGet/Microsoft SDK distribution. Verify SDK archive digest against recorded official metadata if installation is required. SDK/tool installation is task-local, not a persistent environment/settings change. No real provider secrets, paid calls, source disclosure or production identities/data.

## File allowlist

Add only runtime/dotnet/{AGENTS.md,README.md,.gitignore,global.json,NuGet.Config,Directory.Build.props,Directory.Packages.props,Factory.slnx}; runtime/dotnet/src/Factory.Api/**; runtime/dotnet/tests/Factory.Tests/**; runtime/dotnet/examples/**; .github/workflows/dotnet-ci.yml; plans/fact-005-*; evidence/fact-005/**; append-only docs/agent-run-log.md. Content-hashed readiness documents may be carried only under the explicit input-base decision above. Do not modify root governance, archives, root defaults, existing Factory CI or repository settings.

Expected production files within the API project: Program.cs, Factory.Api.csproj, appsettings.json, Contracts/AnalysisModels.cs, Analysis/IRuleScanner.cs, Analysis/RoslynRuleScanner.cs, Analysis/AnalysisService.cs, Agents/IAgentReviewService.cs, Agents/FactoryAgentService.cs, Configuration/AnalysisOptions.cs, Configuration/AIOptions.cs, Configuration/ProviderRegistration.cs, Security/LocalHostPolicy.cs and reviewed packages.lock.json. Small internal helper files within these folders are allowed only for the same bounded behavior; new infrastructure or agent capabilities require reapproval.

Expected tests: scanner fixtures, analysis-service consent/status tests, real-MAF/fake-IChatClient contract tests, API functional tests, options/endpoint policy tests, real loopback startup/hosting tests, cancellation/resource-limit tests, mock-transport secret/redirect/retry tests and log-capture tests. Use synthetic source only. No public-target security probing.

## Implementation order

1. Verify baseline/remote and uniqueness, create the approved task branch, record approvals and hashes. Copy only inspected prototype files under runtime/dotnet; root authority files remain intact.
2. Establish solution, typed options, central exact pins, NuGet.org-only source configuration, SDK pin with no roll-forward, nullable and warnings-as-errors, reviewed lockfiles. Correct OpenAI pin to 2.14.0, add MVC.Testing 10.0.13; mark runner/test-only packages PrivateAssets=all. Do not suppress NU1605 or prerelease/analyzer findings.
3. Implement source-only deterministic scanner/provenance and parse diagnostics; add AC-02/03 tests before integrating advisory behavior.
4. Inject service/provider seams; build actual MAF analyst/critic over fake IChatClient. Enforce service consent, immutable decision, grounding, output validation and cancellation. Add AC-04/05/06/07 tests.
5. Implement API/host/endpoint/log/resource contracts and failure retention; add AC-08/09 tests. Reuse host-owned clients; do not share mutable sessions.
6. Add read-only .NET CI, preserve Factory checks, capture evidence and traceability. Run all approved developer checks on the exact final revision and tested integration result.
7. Prepare draft PR into the approved develop target if publication is explicitly included in execution approval. Report PR URL/head, base/target and real check results. Handoff to separately approved independent QA/security/review and stop. No merge, deploy, close or automatic next slice.

## Planned commands (NOT RUN by FACT-004A)

Run from repository root. Initial lock generation is an approved BUILD step; inspect assets/lockfiles and audit the complete graph before accepting reproducibility.

```sh
dotnet --info
dotnet restore runtime/dotnet/Factory.slnx --use-lock-file
dotnet restore runtime/dotnet/Factory.slnx --locked-mode
dotnet build runtime/dotnet/Factory.slnx -c Release --no-restore
dotnet test runtime/dotnet/Factory.slnx -c Release --no-build --logger trx
dotnet format runtime/dotnet/Factory.slnx --verify-no-changes --no-restore
dotnet list runtime/dotnet/Factory.slnx package --vulnerable --include-transitive --format json
python3 tools/validate_factory.py
python3 -m unittest discover -s tools -p 'test_factory*.py' -v
git diff --check
```

Inspect zero-test discovery, skipped mandatory cases and audit warnings as blockers even when a CLI exits zero. Never equate zero exit from vulnerability listing with absence of vulnerabilities; parse and review its output. Full resolved license/deprecation inventory also requires review.

## CI and security checks

Proposed contexts: dotnet-build, dotnet-tests, dotnet-format, dotnet-security; exact real names/producers must be recorded on a real PR before any required-check configuration. Official actions pinned to verified full commit SHAs, contents:read only, persist-credentials:false, bounded job timeouts, no privileged pull_request_target, secrets or deployment jobs. Run PR merge-result checkout and record event/task/target/tested merge SHAs. Skipped/stale/pending/neutral/failed required jobs block.

Candidate security tools are gitleaks 8.30.1 and standalone CodeQL CLI 2.27.2 (bundle codeql-bundle-v2.27.2), using the bundle's C# security-extended suite. Run both against the approved checkout in CI; use a clean Release build traced by CodeQL and save SARIF. Configure no Code Scanning upload, database upload or security-events write. Parse SARIF explicitly: CLI exit zero alone is not a clean security result. Resolve findings under canonical severity policy; absent output or extraction/analysis failure blocks. Gitleaks scans the task/base diff/history with redacted reports, not secrets printed to logs; default findings fail until reviewed. The public repository is eligible for CodeQL's public-repository use; do not assume the same terms for private consumers.

Observed download digests: gitleaks_8.30.1_linux_x64.tar.gz SHA256 `551f6fc83ea457d62a0d98237cbad105af8d557003051f41f3e7ca7b3f2470eb`; codeql-bundle-linux64.tar.gz SHA256 `f002864be6dd8d5d7bdb123aaf7291ec8e291012bd9f70b6d2362f730db52aeb`. Verify archives before executing; availability/digests are metadata observations, not scanner run evidence. Full release/ref responses are retained in evidence/fact-004a/raw/tooling-metadata.json. Candidate official action pins: checkout `d23441a48e516b6c34aea4fa41551a30e30af803` (existing approved CI), setup-dotnet `26b0ec14cb23fa6904739307f278c14f94c95bf1`, upload-artifact `b7c566a772e6b6bfb58ed0dc250532a479d7789f`; retain Python setup's existing pin for Factory checks. The BUILD task must verify tool execution and .NET 10 extraction on the exact candidate. A changed tool version/digest or unavailable required scanner triggers reapproval, not silent substitution. Upload only sanitized results to the repository's CI artifacts; no external scanning service or provider receives source. Do not substitute compiler warnings for security scanning. No new workflow is created during readiness; secret/static scan NOT_RUN is not a waiver.

## Failure and evidence contract

Any package/API mismatch, SDK/test-host failure, unresolved vulnerability, unsafe hosting, missing mandatory scanner, scope expansion or changed input revision stops the affected work for remediation planning/reapproval. Preserve raw failures and avoid broad upgrades to force a green build. Each AC maps to implementation, tests, raw output/hash, exact candidate, environment, UTC and independent reviewer. Developer checks are not independent QA. Output changes invalidate downstream approvals and affected evidence.

Plan prepared. Waiting for approval before execution.
