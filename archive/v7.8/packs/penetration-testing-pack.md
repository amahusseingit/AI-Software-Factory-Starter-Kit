# Penetration Testing Pack

## Purpose
Provide a reusable baseline for planning, executing, and closing penetration testing as part of release readiness.

## Activate When
- system is public or client-facing
- system is high-risk or compliance-sensitive
- major release introduces auth, admin, integration, or payment changes
- governance requires PT prior to go-live

## Minimum PT Readiness
- stable release candidate
- defined in-scope assets
- defined test accounts/roles
- PT-safe environment or approved test window
- logging and monitoring enabled
- rollback/contact process defined

## Mandatory PT Deliverables
- PT scope definition
- PT readiness checklist
- PT findings log
- remediation tracker
- retest/closure evidence
- PT review status in release readiness

## Typical Focus Areas
- authn/authz
- session management
- API abuse
- privilege escalation
- business logic abuse
- input validation and injection
- sensitive data exposure
- mobile/API abuse combinations
