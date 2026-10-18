# Rescue Gap Taxonomy

Use this taxonomy to classify defects in partially generated systems.

## A. UI shell gaps
- visible action with no handler
- dialog opens but does not save
- list exists but create/edit/delete do not work
- loading, empty, error, or success states missing
- state does not refresh after mutation

## B. API and integration gaps
- missing endpoint
- endpoint exists but contract mismatches UI needs
- integration call path incomplete
- orchestration or retry path missing
- failure path not surfaced to users

## C. Persistence gaps
- fake local state instead of system-of-record persistence
- wrong database provider
- migrations missing
- mutation side effects not persisted correctly

## D. Validation gaps
- required fields not enforced
- edit flow does not prefill correctly
- destructive actions lack confirmation
- role or ownership validation missing

## E. Testing gaps
- tests missing entirely
- tests only cover list loading or mocks
- no negative tests
- no regression tests for repaired defects

## F. Parity gaps
- web implemented, mobile missing
- mobile implemented, web missing
- validations differ across platforms
- role visibility differs across platforms

## G. Governance gaps
- no traceability row for implemented behavior
- no evidence for claimed completion
- review passed without behavioral proof

## Severity guidance
- Critical: unsafe release, data corruption, security, broken core workflow, severe stack drift
- High: incomplete core feature, broken CRUD mutation, missing parity for in-scope behavior
- Medium: missing non-core state handling, weak evidence, missing negative tests
- Low: wording, cosmetics, minor documentation drift
