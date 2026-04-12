---
name: devops-and-deployment-readiness
description: Use when a project needs environment setup, CI/CD, deployment planning, migrations, rollback, configuration, and operational readiness defined.
triggers:
  - deployment
  - ci/cd
  - docker
  - rollout
  - rollback
  - environments
  - secrets
  - monitoring
---

# Overview

This skill closes the gap between a built system and an operational system by selecting and applying the relevant DevOps and deployment packs.

# When to Use

Use this skill before release, when preparing environments, or whenever a project needs repeatable build, deployment, migration, rollback, and runtime management guidance.

# Inputs Required

- Project spec
- Hosting or platform constraints
- Environment model if known
- Release expectations and rollback tolerance

# Process

1. Determine the target runtime and environment model.
2. Select the appropriate DevOps packs under `devops-packs/`.
3. Define environment, configuration, secret, and deployment requirements.
4. Add migration, smoke test, and rollback expectations.
5. Fold the outputs into release readiness.

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Deployment can be figured out later | Operational surprises block releases late |
| One environment is enough for now | Promotion and rollback need explicit handling |

# Red Flags

- No deployment checklist
- No migration or rollback plan
- No secret/config handling guidance
- No smoke-test expectation after deployment

# Verification

- Relevant DevOps packs selected
- Environment matrix exists
- Deployment and rollback guidance exists
- Release readiness includes operational checks

# Outputs

- Environment and deployment notes
- Release checklist updates
- Ops readiness additions to release artifacts
