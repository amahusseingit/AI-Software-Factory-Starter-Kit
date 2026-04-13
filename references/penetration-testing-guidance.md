# Penetration Testing Guidance

## Objective
Use penetration testing as an independent offensive validation step for systems or releases where the risk profile justifies it.

## When PT Is Strongly Recommended
- public internet exposure
- sensitive data handling
- privileged administration
- partner/client-facing integrations
- major auth/session or access-control changes
- compliance or contract requirement

## Minimum PT Lifecycle
1. define scope
2. confirm readiness
3. execute PT
4. triage findings
5. remediate
6. retest
7. update release decision

## Release Guidance
- unresolved Critical/High PT findings should block release unless formally accepted by governance
- PT evidence should be referenced in release readiness artifacts
