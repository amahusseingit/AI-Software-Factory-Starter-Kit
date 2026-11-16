# CRUD-Heavy Business App Test Strategy Pack

Use when the system contains many entities with forms, list views, filters, and mutation behavior.

## Focus
- create, edit, delete/deactivate
- validation
- list refresh after mutation
- permission-sensitive actions
- error handling and state transitions

## Minimum expectations
- backend mutation tests for each critical entity
- web tests for create/edit/delete flows and validations
- mobile tests for form save/delete/refresh flows
- negative tests for invalid inputs and unauthorized access
- regression tests for repaired CRUD defects
