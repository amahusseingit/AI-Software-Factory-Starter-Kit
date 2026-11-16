# Optional .NET / SQL Server / Angular / Flutter profile

OPTIONAL, NOT A DEFAULT. Apply only to explicitly selected components supported by the inspected repository and approved architecture. Selection must identify requirement/design revisions and applicability under [canonical governance](../governance/protocol.md). Selecting this profile does not approve migrations, package installs, commands, settings, deployments or business rules. Existing project conventions prevail; mismatches require clarification.

## Candidate component mappings

| Selected component | Inspect before adopting | Design and validation considerations |
|---|---|---|
| .NET API | Solution/project files, SDK, controllers/endpoints, dependency injection, tests | Existing API/Application/Infrastructure boundaries, request/response contracts, auth, errors and compatibility |
| SQL Server / EF Core if present | Existing canonical entities, DbContext, migrations and connection strategy | Keys/indexes/nullability, version/audit fields, migration/backfill/rollback and representative integration tests |
| Angular web if present | Package scripts, feature/core structure, routing, components/services, tests | Feature boundaries, API contract, states, filters, accessibility and component/service coverage |
| Flutter mobile if present | SDK constraints, pubspec, navigation/state patterns, client and tests | Platform navigation, state, API parity, accessibility, widget/integration tests and device assumptions |

No project is required to contain all four components. Do not introduce Flutter, EF Core, SQL Server or a layered architecture just because this profile mentions it. Reuse the actual canonical data model and approved technical decisions.

## Command discovery, not automatic execution

Inspect manifests and CI to identify supported commands and tool versions. Candidate commands in historical guidance included `dotnet build`, `dotnet test`, `dotnet format --verify-no-changes`, `npm run lint`, `npm test` and `npm run build`; Flutter projects may expose `flutter analyze` and `flutter test`. These are examples, not validated commands for the selected repository. Include exact commands, environment, effects and output locations in the role plan; wait for approval. Report unsupported tools as unexecuted under the canonical evidence contract. Never infer a passing build from the presence of a script.

## Architecture and delivery checks

- Confirm API/application/infrastructure and feature/core boundaries rather than imposing them.
- Keep domain calculations and configuration requirements in approved project specifications.
- Preserve contract compatibility and approved web/mobile parity; do not assume identical UI layouts.
- Treat migrations and database access as separately scoped effects. A local migration file is not evidence of safe deployment.
- Test service/domain logic, API/auth, persistence/migration and selected UI platforms with actual evidence.
- Preserve security policy, independent review and per-role approval; this profile cannot weaken them.

## Provenance

.NET/SQL Server/Angular details are adapted from `archive/july-prior/ai_software_factory_kit_problems_sla/skills/solution-architect/skill.md`, `skills/developer/skill.md` and `skills/qa-static-analysis/skill.md`, and their updated-kit counterparts under `archive/july-updated/ai_software_factory_kit_problems_sla/`. The latter two abbreviated skill paths use the same root as the architect path. Flutter is an explicitly optional unification extension, not a claim that the July Problems SLA kit included mobile implementation requirements. No technology/version default or business formula is introduced.
