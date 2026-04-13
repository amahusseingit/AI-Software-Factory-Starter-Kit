# Application Security Testing Pack

## Purpose
Provide a generic reusable baseline for integrating AppSec testing into the software delivery lifecycle.

## Activate When
- system handles authentication or sensitive data
- system is internet-facing or partner-facing
- APIs are exposed externally or to untrusted clients
- file uploads, admin features, payments, or integrations exist
- release governance requires security evidence

## Minimum Activities
- SAST
- SCA / dependency vulnerability scanning
- secrets scanning
- DAST or API DAST for exposed services
- manual security review of auth/session and access control
- remediation triage and retest

## Typical Severity Policy
- Critical: release blocker
- High: release blocker unless formally accepted
- Medium: triage required, fix plan required
- Low: backlog or hardening queue

## Mandatory Deliverables
- AppSec scope
- scanner/tool outputs or equivalent evidence
- findings triage log
- remediation plan
- retest evidence
- AppSec review scorecard

## Typical Focus Areas
- broken authentication
- broken access control
- insecure direct object reference
- injection
- insecure deserialization
- SSRF if integrations exist
- XSS/CSRF as applicable
- sensitive data exposure
- dependency vulnerabilities
- hard-coded secrets
- weak cryptography usage
