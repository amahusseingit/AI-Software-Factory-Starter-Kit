---
name: penetration-testing-readiness
description: Use when planning, preparing, executing, or following up penetration testing for a system or release.
triggers:
  - penetration testing
  - pentest
  - pt testing
  - offensive security
  - release security validation
---

# Overview

This skill adds structured penetration testing readiness into the lifecycle. It ensures the system is prepared for PT, scope is clear, evidence is collected, and findings are handled in a governed way.

# When to Use

Use this skill when:
- a release requires external or internal penetration testing
- the system is internet-facing or high-risk
- major auth, integration, payment, upload, or admin capabilities are introduced
- compliance or client governance requires PT before go-live
- review or ship phases need independent offensive testing evidence

# Inputs Required

- deployment topology
- URLs/endpoints and exposed surfaces
- test accounts and roles
- environment scope
- release candidate build/version
- known constraints and exclusions
- logging/monitoring contacts for test window

# Process

1. Define PT scope:
   - in-scope apps/APIs/mobile backends
   - roles/accounts to test
   - environments allowed
   - exclusions and safety rules
2. Establish readiness:
   - stable release candidate
   - test environment availability
   - representative data/setup
   - logging/monitoring enabled
   - emergency contact and rollback plan
3. Define PT focus areas:
   - auth/authz
   - session management
   - injection
   - broken access control
   - business logic abuse
   - sensitive data exposure
   - file handling
   - mobile/API abuse paths
4. Capture findings:
   - title
   - severity
   - asset/surface
   - reproduction summary
   - impact
   - remediation owner
5. Enforce post-PT workflow:
   - triage
   - fix
   - retest
   - closure evidence
   - release decision update

# Rationalizations to Reject

| Excuse | Why invalid |
|---|---|
| PT is only needed after production | PT is most useful before release when fixes are still safe |
| We already ran scanners | PT covers chained exploitation and business logic paths scanners miss |
| A quick smoke test is enough | PT requires defined scope, evidence, and remediation tracking |

# Red Flags

- no PT scope
- release candidate unstable or changing during PT
- no test accounts/roles
- no retest step after fixing findings
- Critical/High PT issues unresolved at release review

# Verification

- PT scope and environment are defined
- PT readiness checklist is complete
- findings are recorded and triaged
- retest/closure evidence exists
- release security decision reflects PT status

# Outputs

- PT readiness checklist
- PT scope document
- PT findings log
- PT retest evidence
- release PT status
