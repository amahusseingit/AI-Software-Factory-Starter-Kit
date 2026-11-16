---
name: observability-and-audit
description: Use when operational visibility, audit, or integration tracing matters.
triggers:
  - logging
  - audit
  - observability
  - traceability
---

# Overview

This skill adds operational visibility and audit discipline, especially for enterprise workflows and integration-heavy modules.

# When to Use

Use when transactions, trip creation, ESB calls, security events, or user progress tracking must be observable.

# Inputs Required

- workflow steps
- audit requirements
- integration boundaries
- support needs

# Process

1. Identify the events worth logging or auditing
2. Define correlation IDs or request IDs where needed
3. Define what data is safe to log
4. Record user progress checkpoints for operational flows
5. Add evidence that critical steps are traceable

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Standard logs are enough | Operational support often needs business-context events |
| We can add audit later | Missing audit data is hard to reconstruct after incidents |

# Red Flags

- no step-level logs in operational flow
- no correlation across systems
- sensitive data logged carelessly

# Verification

- traceable events are defined
- audit-sensitive events are captured safely
- evidence exists for critical flow tracing

# Outputs

- logging / audit notes
- evidence file
