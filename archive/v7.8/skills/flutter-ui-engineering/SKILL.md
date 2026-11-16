---
name: flutter-ui-engineering
description: Use when building or modifying Flutter UI for production features.
triggers:
  - flutter
  - mobile ui
  - screen
  - fab
  - form
---

# Overview

This skill enforces production-quality Flutter feature delivery with complete behavior and clear state handling.

# When to Use

Use whenever Flutter screens, forms, FABs, navigation flows, or session-dependent behavior are in scope.

# Inputs Required

- screen specs
- API contracts
- validations
- role visibility
- device considerations

# Process

1. Build screen and navigation structure
2. Wire data loading to real services
3. Implement create/edit/delete or equivalent complete behaviors
4. Implement validation and feedback
5. Implement loading / empty / error / success states
6. Add tests
7. Produce evidence

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| The FAB can stay as TODO for now | A visible dead FAB is a defect |
| Mobile can lag behind web | In-scope parity must be explicit |

# Red Flags

- TODO on FAB handler
- no edit/delete path
- no success or error feedback
- no refresh after mutation

# Verification

- in-scope actions work
- forms validate
- service integration is real
- tests and evidence exist

# Outputs

- Flutter implementation
- Flutter tests
- evidence file
