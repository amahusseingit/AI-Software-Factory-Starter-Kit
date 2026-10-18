# Example Project Test Strategy

## Project Context
- Architecture shape: CRUD-heavy web + mobile business app
- Platforms: Backend, Angular, Flutter
- Key risks: partial CRUD, parity drift, mutation side effects, permissions

## Selected Strategy Packs
- CRUD-heavy business app pack
- Role and permission matrix pack
- Mutation integrity pack

## Required Test Types
| Area | Mandatory tests | Notes |
|---|---|---|
| Backend | mutation, permissions, validation | critical rules first |
| Web | create/edit/delete + validation + state transitions | key modules only at minimum |
| Mobile | save/delete/refresh + validation | parity-critical areas |
| Integrations | contract tests where applicable | focus on risk paths |
| Regression | repaired defect flows | required for rescue work |
