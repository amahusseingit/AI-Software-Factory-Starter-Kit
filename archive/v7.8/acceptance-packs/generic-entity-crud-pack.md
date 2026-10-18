# Generic Entity CRUD Acceptance Pack

Use this pack for any primary entity that supports create, read, update, and delete or deactivate behavior.

## Create Entity
- required fields are validated
- invalid payload is rejected with clear feedback
- valid save persists to the system of record
- success feedback is shown
- list or details view refreshes after save
- authorization and ownership rules are enforced

## Read / List Entity
- list loads from the real API or backend service
- loading, empty, error, and success states are handled
- paging, sorting, and filtering behave as defined by the spec

## Edit Entity
- edit form loads existing data correctly
- changes are validated before save
- save persists changes to the system of record
- concurrent or stale data behavior is handled as defined by the spec
- UI refreshes after mutation

## Delete / Deactivate Entity
- destructive action requires confirmation when appropriate
- delete or deactivate follows the business rule defined in the project spec
- dependent data rules are respected
- UI refreshes after mutation
- audit trail behavior is applied when required
