# AppSec Testing Guidance

## Objective
Integrate application security testing into planning, implementation, testing, review, and release readiness.

## Typical Control Set
- SAST
- dependency / SCA scanning
- secrets scanning
- DAST or API DAST
- manual review of auth, access control, and sensitive flows
- retesting after remediation

## Release Policy Guidance
- unresolved Critical findings block release
- unresolved High findings block release unless explicitly risk-accepted
- Medium findings require triage and a fix plan
- Low findings should still be tracked

## Evidence Expectations
- what was scanned/tested
- when and against what version
- what findings were found
- how they were triaged
- what was fixed
- what was retested
