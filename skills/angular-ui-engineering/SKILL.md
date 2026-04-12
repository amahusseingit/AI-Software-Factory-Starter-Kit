---
name: angular-ui-engineering
description: Use when building or modifying Angular UI for production features.
triggers:
  - angular
  - web ui
  - crud screen
  - dashboard
  - form
---

# Overview

This skill enforces production-quality Angular feature delivery with real behavior, not only visible scaffolding.

# When to Use

Use whenever Angular routes, pages, forms, tables, dialogs, or auth/session flows are in scope.

# Inputs Required

- screen specs
- API contracts
- validations
- role visibility
- responsive needs

# Process

1. Build route and page structure
2. Wire list/data loading to real services
3. Implement create/edit/delete or equivalent complete behaviors
4. Implement validation and feedback
5. Implement loading / empty / error / success states
6. Add tests
7. Produce evidence

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| We can add edit later | In-scope CRUD requires full behavior |
| The modal opens, so the feature is done | Opening a modal without save logic is incomplete |

# Red Flags

- dead buttons
- unbound form submit
- edit without preloaded data
- no refresh after mutation
- no state handling

# Verification

- in-scope actions work
- forms validate
- API integration is real
- tests and evidence exist

# Outputs

- Angular implementation
- Angular tests
- evidence file
