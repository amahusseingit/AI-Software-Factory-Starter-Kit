# FACT-004A readiness execution record and plan

Revision: 1. Display task FACT-004A; canonical task ID `fact-004`; role: coordinator/readiness preparation. Actor: Codex in the current user session. Date: 2026-10-19 UTC. Scope approval: the latest user message `Approved`, directly following the assistant's FACT-004A-only decision request. The original conversation is the approval source; no stable message ID or exact approval-issued timestamp is exposed by the interface. Do not invent either or infer the user's GitHub/legal identity. The subsequent evidence manifest records observation time, hashes and this limitation; it does not authenticate approval independently.

## Scope and branch binding

Prepare candidate requirements, architecture/contract notes, dependency manifest, traceability and developer handoff for the already assessed single-file advisory slice. No runtime code/configuration, CI changes, provider calls, .NET restore/build/test, independent QA/security signoff, merge, release, deployment or closure is authorized. Readiness approval authorizes preparing proposals, not acceptance of their newly produced output.

Repository: https://github.com/amahusseingit/AI-Software-Factory-Starter-Kit. Verified upstream base and target: develop at `7ed5858e44bafbabf083022397ef97a4bb827dd2`. Genuine Git clone, remote and workflow triggers inspected before file changes. Only existing Factory documentation/evaluator CI runs on task pushes; no deployment trigger was present in the pinned tree.

Actual task branch: `task/fact-004-a-dotnet-runtime-readiness`. This is a local naming normalization of the proposed `task/fact-004a-dotnet-runtime-readiness`: canonical validator requires numeric task IDs (`fact-004`) and a separate lowercase slug (`a-dotnet-runtime-readiness`). Same scope/base; no legacy exception, synthetic ancestry or remote history rewrite. Local/remote branch listings and active pinned tree had no competing FACT-004 records when inspected. Remote registration remains pending publication; absence in inspected sources does not prove uniqueness in external trackers.

## Execution sequence

1. Verify approved upstream commit, branch uniqueness, governance, role boundaries and deployment triggers.
2. Inspect source ZIP without executing it; capture archive/file digests and published NuGet metadata, package XML API docs and Microsoft SDK release metadata.
3. Write candidate SRS/ADR, exact dependency candidate and proposed developer plan with AC mappings and security boundaries. Keep gates and application checks NOT_RUN/BLOCKED.
4. Run existing documentation validator and synthetic Factory evaluator tests as readiness self-checks; record real commands, timestamps, exit codes and raw-output hashes. These are not application tests or independent review.
5. Append execution/handoff record to the shared log, capture output tree/commit and stop. No new role or runtime implementation starts automatically.

## Allowed outputs

`specs/factory-runtime-phase1.md`; `adrs/factory-runtime-phase1.md`; `plans/fact-004a-*`; `plans/fact-004b-*`; `evidence/fact-004a/**`; append-only `docs/agent-run-log.md`. The wider runtime/CI paths previously listed are reserved for separately approved implementation and are not modified by FACT-004A.

## Inputs and selected guidance

Actually inspected at the pinned base: AGENTS.md, ORCHESTRATOR.md, governance/protocol.md, governance/security-policy.md, governance/branch-environment-policy.md, governance/gate-contract.json, governance/readiness-and-done.md, roles/coordinator.md, roles/product-owner.md, roles/architect.md, templates/role-plan-template.md, templates/role-handoff-template.md, templates/evidence-template.md, templates/traceability-matrix-template.md, templates/branch-record-template.md, VALIDATION.md, .github/workflows/factory-ci.yml and docs/agent-run-log.md (prior actual entry `fact-003-developer-20261018`). File digests are captured in evidence.

Selected skills: orchestration-and-lifecycle-control, using-starter-kit, spec-driven-delivery, planning-and-task-breakdown, traceability-governance, test-strategy-selection, source-grounding, architecture-decisioning and api-contract-design. security-and-hardening informed the applicability notes. dotnet-api-delivery is routed for later BUILD only. No project example profile or domain default is adopted.

## Validation, risks and stop conditions

Documentation-level checks only: `python3 tools/validate_factory.py`, `python3 -m unittest discover -s tools -p 'test_factory*.py' -v`, active diff whitespace and evidence hash/allowlist inspection. No new tests mirroring document text are created. Network metadata lookups do not run assemblies or test services. Temporary scripts package actual observations only; they do not implement the runtime.

Unavailable Git access would block repository mutation; supported per-command network permission enabled a genuine clone after an initial proxy connection failure. NuGet availability now observed, not assumed. OpenAI dependency mismatch and Roslyn transitive prerelease are disclosed candidate decisions; neither is silently accepted. Fresh target/base, materially changed scope, unavailable metadata or unexpected file changes require a stop/replan.

Readiness self-check is not G1/G2/G3 approval. The next action is human review of exact output artifacts. Then present the proposed architect/developer role plan as required; do not infer that this task's approval authorizes a successor. Any future draft PR contains only the authorized scope and requires its publication step to be authorized; no merge/deploy permission is inferred.
