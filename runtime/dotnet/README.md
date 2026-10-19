# Factory .NET Phase 1

Local, source-only advisory analysis. The approved specification and ADR under the repository root define this runtime. It does not execute or compile submitted code, load projects, modify repositories, grant approval, or provide independent QA/security review. Enterprise identity, shared hosting and persistent auditing remain future work.

## Build and run

Install SDK **10.0.402**, then run from this directory so `global.json` applies:

```sh
dotnet restore Factory.slnx --locked-mode
dotnet build Factory.slnx -c Release --no-restore
dotnet test Factory.slnx -c Release --no-build
dotnet run --project src/Factory.Api --no-launch-profile
```

Default binding is `http://127.0.0.1:5080`. Explicit IP loopback URLs are supported; hostnames, wildcard/public addresses, forwarded headers, browser Origin requests, alternative Kestrel endpoints and port-only configuration are rejected. This is local-process trust, not enterprise authentication. `GET /health` reports liveness only.

`POST /api/factory/analyze` accepts `application/json` with `fileName` (display only, 1–260 characters), `sourceCode` (1–20,000 UTF-16 characters) and optional `consentToSendCode` (false by default). Body limit is 65,536 bytes; four analysis requests run at once without queueing. Invalid requests return 400/413/415, syntax errors 422, and capacity exhaustion 429. Unexpected failures return generic Problem Details.

## Deterministic analysis

Configure exact, case-insensitive identifier/member-name terms through `Analysis:IdentifierTerms`; the default empty list produces no heuristic matches. For the synthetic example only, set `Analysis__IdentifierTerms__0=tier`. Syntax-only C#14 detects equality/inequality against string/numeric literals. It excludes null, booleans, comments, configured-value comparisons and unsupported expressions. Findings are tentative; absence of matches is not proof of business-rule correctness.

Evidence preserves original source spans. Digests hash original UTF-8 source without newline normalization; findings identify the digest, rule and span. Analyzer provenance includes the normalized term-configuration digest. Syntax diagnostic messages are reduced to bounded compiler codes/locations to avoid echoing input.

## Optional advisory agents

AI is disabled by default, with no configured destination or implicit provider fallback. Every analysis response has `decision: BLOCKED`. Agent states (`NOT_RUN`, `DISABLED`, `ADVISORY_ONLY`, `FAILED`, `TIMED_OUT`) describe execution only and never substitute for Factory gates.

Enabling AI requires separately approved organizational egress/data scope, an explicit HTTPS endpoint in `AI:AllowedEndpoints`, `AI:Model`, and endpoint-bound `AI:ApiKey` injected through secret configuration. Never commit credentials or submit proprietary source in Phase 1. Consent is enforced inside the review service as well as the API contract. HTTP/local providers, redirects, transport retries and fallback credentials are unsupported. Endpoint configuration denotes an OpenAI-compatible base path (for example an approved `/v1/`); outbound requests are confined to its `/chat/completions` resource.

Microsoft.Extensions.AI `IChatClient` is injected into actual Microsoft Agent Framework analyst and critic agents, called sequentially with no tools or shared sessions. Analyst input includes source/findings; critic input includes findings, digest and analyst report without full source. Responses are untrusted text, limited to 8,000 UTF-16 characters each and requested at 2,048 output tokens. A total 30-second AI deadline applies across both calls. Failure retains deterministic findings without claiming completed review; caller cancellation aborts work. No automatic retry/idempotency guarantee is provided.

Application logging excludes payloads, source, model reports and credentials; metadata logs are not a tamper-evident audit. Test fixtures use synthetic content and fake providers only. Developer results and independent review status are recorded outside this folder by the coordinator.
