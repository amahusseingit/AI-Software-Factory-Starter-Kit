# Salvage vs Rebuild Guidance

Use this guide after rescue assessment.

## Prefer salvage when
- architecture is mostly correct
- contracts are usable
- persistence model is sound
- gaps are concentrated in handlers, forms, validations, or tests
- parity can be restored with targeted work

## Prefer partial rebuild when
- core module boundaries are wrong
- API contracts fundamentally mismatch the workflows
- state management is tangled and fragile
- CRUD behavior is fake or duplicated across many screens
- stack drift affects a major layer

## Prefer restart from spec/plan when
- there is no reliable authoritative spec
- implementation has no traceability to requirements
- multiple modules are shells with little reusable logic
- review evidence is largely fabricated or unverifiable
- rescue cost exceeds controlled rebuild cost

## Decision factors
- estimated repair effort vs controlled rebuild effort
- number of broken core workflows
- testability of the current codebase
- maintainability after rescue
- team confidence in the recovered structure
