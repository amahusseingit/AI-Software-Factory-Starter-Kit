# FACT-005 developer handoff (in progress)

Task: fact-005. Input develop SHA: `7ed5858e44bafbabf083022397ef97a4bb827dd2`. Branch: `task/fact-005-integrate-dotnet-runtime`. User execution and draft-PR authority are recorded in [execution plan](fact-005-execution.md) and evidence/fact-005/authorization.json. Approved readiness source `685cf8784fff62b862a13552f02c7773d3115dae` was carried unchanged by genuine cherry-pick. No main/develop write, merge, deployment, closure or independent signoff is authorized.

## Implemented scope

The optional runtime under runtime/dotnet adds single-file C#14 Roslyn analysis with original spans/digest/config provenance, actual MAF analyst and critic over injected IChatClient, default-disabled AI, service consent, bounded advisory outputs/deadline, explicit endpoint-bound HTTPS provider policy, no tools, loopback HTTP API, request limits/concurrency and immutable BLOCKED decisions. Production sources and developer tests were delegated to separate implementation/test-author agents; both remain developer work, not independent QA.

Synthetic tests cover scanner boundaries/provenance, service consent and failures, MAF fake-provider sequencing/cancellation/deadlines, API validation/concurrency/isolation, loopback startup/request policy, outbound mock transport and secret-safe errors/logs. Test cases in source are not passing evidence until executed.

The added workflow proposes dotnet-build, dotnet-tests, dotnet-format and dotnet-security. Jobs use pinned actions/SDK/scanner digests, contents:read, no privileged trigger, no real model credentials and no deployment. Security checks include NuGet transitive audit, redacted gitleaks and C# CodeQL security-extended. SARIF and TRX are retained; missing findings disposition/test results block success.

## Actual evidence and current limitations

Evidence is under evidence/fact-005. Restore-01/02/03 failed during sandbox mutex initialization before package resolution. Restore-04 succeeded after supported command-level escalation. The exact approved package graph restored and produced lockfiles. Resolved inventory contains 63 packages; parsed NuGet audit reported zero vulnerable packages. License metadata includes MIT/Apache-2.0/BSD-3-Clause, plus xunit.abstractions 2.0.3's legacy license URL that needs provenance review; no legal/security approval is invented. The disclosed Roslyn prerelease analyzer remains in the approved graph.

The first direct Release build failed with one ambiguous BadHttpRequestException reference (raw build-direct-01.txt). The qualified type correction built successfully with zero warnings/errors (build-01). That result binds its recorded source digest; subsequent trailing-slash regression/source changes are not covered by it. Format-apply-01 succeeded; a later restricted-sandbox formatter failed connecting its build-host pipe (format-apply-02). Subsequent elevated verification attempts were cancelled at the platform permission request before launch; they are not application passes or test failures.

Gitleaks staged scan found no leaks in the scanned staged diff (gitleaks-staged-01). Full hosted candidate/integration validation is pending publication. Local application tests and CodeQL remain NOT_RUN, not independent acceptance. The authorized draft PR/CI path will establish hosted results separately; the local permission limitation is not represented as resolved.

## Current stop boundary

This is an in-progress developer report, not completion or acceptance. Coordinator is authorized to publish the task branch and draft PR, observe actual checks, repair in-scope developer defects and update this evidence. No successor independent QA/security/reviewer role has executed. Overall acceptance progression remains BLOCKED pending current application/CI evidence and separately approved independent roles.
