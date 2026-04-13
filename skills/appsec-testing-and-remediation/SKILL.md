---
name: appsec-testing-and-remediation
description: Use when planning, executing, triaging, or reviewing application security testing during software delivery.
triggers:
  - appsec
  - application security
  - sast
  - dast
  - dependency scanning
  - secrets scanning
  - security testing
  - remediation
---

# Overview

This skill makes security testing part of the delivery lifecycle instead of a late-stage add-on. It ensures application security requirements are planned early, tested continuously, triaged consistently, and reviewed before release decisions.

# When to Use

Use this skill when:
- starting a new project that will ship code
- defining test strategy
- selecting CI/CD quality gates
- reviewing release readiness
- handling remediation of vulnerabilities
- working on internet-facing systems, sensitive data, auth flows, file uploads, admin features, or integrations

# Inputs Required

- project spec
- architecture and data flow
- stack and dependencies
- deployment model
- auth/session model
- threat-sensitive areas
- current scanner/tool outputs if available

# Process

1. Identify attack surface:
   - auth and session flows
   - input-heavy endpoints and forms
   - file upload/download
   - admin features
   - integrations and webhooks
   - secrets/config handling
   - client-side storage
2. Select applicable AppSec testing:
   - SAST
   - SCA/dependency scanning
   - secrets scanning
   - DAST for exposed apps/APIs
   - container/image scanning if containers exist
   - IaC scanning if infrastructure-as-code exists
3. Define severity handling:
   - Critical and High must block release unless explicitly accepted by governance
   - Medium requires triage and fix plan
   - Low requires backlog decision
4. Produce remediation workflow:
   - reproduce
   - confirm exploitability/business impact
   - prioritize
   - fix
   - regression test
   - document evidence
5. Feed results into review and release readiness artifacts.

# Rationalizations to Reject

| Excuse | Why invalid |
|---|---|
| We will scan after development finishes | Late-only scanning increases release risk and remediation cost |
| Dependency scan alone is enough | It does not cover code flaws, auth issues, secrets leakage, or runtime behavior |
| Medium issues can always wait | Medium findings on auth, exposure, or sensitive data may still be release-significant |

# Red Flags

- no security test strategy
- auth/session flows unreviewed
- public endpoints with no DAST/API testing
- unresolved Critical/High findings
- secrets in repo or config
- dependency vulnerabilities with no triage
- release decision made without AppSec evidence

# Verification

- security test scope is defined
- AppSec tools or activities are selected
- findings are triaged by severity
- remediation evidence exists
- release blockers are documented
- review scorecards reflect security status

# Outputs

- AppSec test plan
- security findings triage log
- remediation tracker
- security review inputs
- release security status
