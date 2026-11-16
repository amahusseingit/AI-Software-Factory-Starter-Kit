> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Example: Integrating AppSec and PT into the Lifecycle

## PLAN
- identify internet-facing APIs
- mark auth, file upload, and admin areas as AppSec focus zones
- select SAST, SCA, secrets scanning, and API DAST
- determine whether release requires PT

## TEST
- run selected AppSec activities
- triage findings
- map security issues into test and remediation work
- record evidence

## REVIEW
- populate AppSec review scorecard
- review open Critical/High findings
- confirm PT status if required

## SHIP
- include AppSec and PT status in release readiness
- block release when policy requires
