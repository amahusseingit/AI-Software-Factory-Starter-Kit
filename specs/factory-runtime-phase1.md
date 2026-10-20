# Factory .NET Phase 1 specification

Revision: 1. Status: candidate requirements for human G1 approval; not an approved build specification.

## Authority and source

This explicitly selected .NET profile extends the generic Factory without changing its governance. The source is the authenticated user's platform request, approval of the Phase 1 readiness plan (FACT-004A), and the source-only prototype archive with SHA256 `844feacdc5110ad2a6508357bf7181f5115029205f42bb0ffbbf24e8a9099e71`. The archive is a design input, not working-application evidence. Input repository revision: `7ed5858e44bafbabf083022397ef97a4bb827dd2` on develop. See the [candidate ADR](../adrs/factory-runtime-phase1.md) and [traceability](../plans/fact-004b-traceability.md).

## Actor, value and scope

An individual developer submits synthetic C# source to a loopback-only ASP.NET Core API and receives possible hardcoded-rule findings. Optional AI explains and critiques findings; it does not approve changes. This establishes a tested runtime seam for future agents without granting coding or repository permissions.

Phase 1 includes .NET 10/C#, Roslyn syntax analysis, Microsoft.Extensions.AI, two Microsoft Agent Framework advisory agents, API validation, controlled provider configuration and automated tests. No Angular, persistence, durable workflows, project loading, repository ingestion, shell/code execution, code mutation, GitHub tools, production data, release or deployment is included. Enterprise identity, shared hosting, tenancy, immutable persistent auditing and provider data-processing approval are future prerequisites, not certified controls.

## Stories and requirements

| Story | Requirement | Expected behavior |
| --- | --- | --- |
| P1-S1 | P1-R1 | Analyze exactly one supplied C# text without reading paths, loading projects, compiling or executing it. |
| P1-S1 | P1-R2 | Use C# 14 regular syntax and configurable exact identifier terms. Empty term configuration returns no heuristic matches. The example explicitly selects synthetic terms; no domain is silently selected. |
| P1-S1 | P1-R3 | Report only equality/inequality against string or numeric literals for configured identifier/member tokens. Ignore null/boolean literals, comments and configured-value comparisons. Unsupported constructs are outside this heuristic's coverage, never certified clean. |
| P1-S1 | P1-R4 | Preserve original text spans; return one-based line/column, span offset/length, deterministic finding ID, source SHA256 and analyzer version. Hash the original UTF-8 source bytes without newline normalization. Syntax errors prevent advisory calls and return diagnostics. |
| P1-S2 | P1-R5 | AI is disabled by default. Both server enablement and per-request consent are necessary at the service boundary, including direct invocation. Server enablement never authorizes proprietary-source disclosure. |
| P1-S2 | P1-R6 | An injected IChatClient supports actual Agent Framework analyst then critic execution. The critic receives deterministic findings plus the analyst report; source is not sent to the critic unless explicitly part of the approved payload contract. No tools are registered. |
| P1-S2 | P1-R7 | Treat model text as untrusted advisory content; validate nonempty bounded responses, propagate cancellation, stop on failure and retain completed deterministic findings. |
| P1-S3 | P1-R8 | Enforce loopback hosting, request/body/output/time/concurrency limits, explicit HTTPS provider allowlisting and secret-safe logs. No arbitrary HTTP/local-provider exception in Phase 1. |
| P1-S3 | P1-R9 | Responses never grant approval. Decision is BLOCKED whenever an analysis response is produced; HTTP error responses also confer no lifecycle authority. |
| P1-S4 | P1-R10 | Build and test with pinned SDK/dependencies, default offline fake-provider tests, raw evidence and independent downstream QA/security/review. |

## API behavior and validation

`GET /health` returns process liveness only. It neither contacts the provider nor claims readiness, passing tests or enterprise health. `POST /api/factory/analyze` accepts JSON `fileName`, `sourceCode`, `consentToSendCode` (default false). FileName is a display label only: nonempty, maximum 260 characters, no control characters; never resolve it against disk. Source is nonempty/nonwhitespace, at most 20,000 UTF-16 characters. Request body is at most 65,536 bytes before deserialization. Limit all endpoint bodies and retain a finite server header/read timeout. Accept application/json only.

Successful parsing returns `runId`, `decision`, `agentStatus`, `sourceDigest`, `analyzerVersion`, `findings`, `diagnostics`, `agentReview`, `notice`. Each finding has `id`, `ruleId`, display file label, line, column, span offset/length, category, original evidence and recommendation. Use `reviewPriority: NEEDS_POLICY_REVIEW`, not security severity `REVIEW`. Security severity is assigned only in a separate security assessment using canonical vocabulary. Rename `IndependentCritique` to `AdvisoryCritique`.

For well-formed requests, no consent yields `NOT_RUN`; consent with AI disabled yields `DISABLED`; both enabled yield either `ADVISORY_ONLY`, `FAILED` or `TIMED_OUT`. Completed analysis responses always contain `decision: BLOCKED`. Provider failures/timeouts return an analysis response with retained scanner findings, a sanitized error code and no unsupported completed-agent claim. Client cancellation aborts work; no completed response or fabricated status is promised after disconnection. Do not reuse these agent execution statuses as Factory gate-check states.

Invalid JSON/fields return 400 Problem Details; parse-invalid C# returns 422 with sanitized syntax diagnostics; excessive body returns 413; unsupported media type returns 415; exhausted concurrency returns 429. Unexpected server errors return generic 500 Problem Details with correlation ID. Missing enabled-provider configuration is a startup failure. No automatic retries or idempotency guarantee: repeat requests create new run IDs and, if explicitly enabled/consented, new bounded AI calls.

## Candidate security and resource contract

Bind explicitly to `127.0.0.1`/`::1`; reject wildcard, hostname, Unix-socket, proxy/forwarded-host and nonloopback server address configuration. Do not trust forwarded headers. Require loopback peer/Host and reject browser Origin requests; no CORS enabling. TestServer is an isolated test substitution, never a deployed exception. Loopback reduces exposure but is not authentication against local processes. Only synthetic inputs are permitted in Phase 1 verification.

Approved provider configuration contains one explicit HTTPS origin/path, model and endpoint-bound credential. No implicit public fallback, URI userinfo/query/fragment, request-controlled URL, redirects or automatic placeholder credentials. Exact normalized endpoint must match its configured allowlist. Secrets come from environment/configuration secret injection and are never returned. Real provider endpoint and organizational egress approval remain unconfigured until separately authorized; fake-provider tests do not use the network.

One total AI deadline: 30 seconds. Maximum two agent calls, sequential, each with output-token limit 2,048; validate each returned text at at most 8,000 UTF-16 characters. Disable transport retries; cancellation applies to both calls and Roslyn traversal. Maximum four in-flight analysis requests with no queue; release permits on all error/cancellation paths. Bound exception/diagnostic output and never log source, model payloads, generated reports or credentials. Metadata-only diagnostics may include run ID, phase, duration, rule count and sanitized error code; they are not tamper-evident audit evidence.

## Acceptance criteria

| AC | Given / when / then | Planned proof |
| --- | --- | --- |
| AC-01 | Given a clean checkout and selected SDK, when locked restore and Release build run, then there are no unresolved warnings or dependency conflicts. | SDK inventory, lockfiles, raw restore/build results. |
| AC-02 | Given valid source, when scanned repeatedly, then findings/spans/digest are repeatable and source evidence is unchanged. | Deterministic scanner tests. |
| AC-03 | Given operand orders, operators, literal types, exclusions, multiline and malformed source, when scanned, then documented behavior and diagnostics hold. | Scanner boundary/negative tests. |
| AC-04 | Given disabled AI or denied consent, when endpoint or service is invoked, then provider call count is zero. | API/service spy tests. |
| AC-05 | Given enabled fake IChatClient and consent, when reviewed, then actual MAF agents execute analyst before critic, share grounded evidence and register no tools. | MAF contract tests without real provider. |
| AC-06 | Given empty/oversized outputs, first/second-agent failure, timeout or cancellation, then incomplete work is explicit and resources are released. | Failure and cancellation tests with controlled clocks/transports. |
| AC-07 | Given adversarial source/model text, then every analysis response remains BLOCKED and no tools, writes or approvals are available. | Invariant/prompt-data tests and source review. |
| AC-08 | Given invalid endpoints, insecure credentials, unsafe hosting and sensitive payloads, then startup/request policy rejects them and logs contain no payload/secrets. | Options, host, mock-HTTP and log-capture tests. |
| AC-09 | Given malformed/boundary requests and concurrent callers, then documented 400/413/415/422/429 behavior and isolation hold. | WebApplicationFactory and loopback-host integration tests using synthetic fixtures. |
| AC-10 | Given the exact candidate/integration result, then all approved checks have current evidence and independent roles remain separately identified. | CI evidence, AC mapping, independent role handoffs. |

All application tests are currently NOT_RUN. No current G1/G2/G3/G4 PASS is asserted. Candidate limits, API changes and dependency corrections require the human's output-specific approval before implementation planning is accepted.
