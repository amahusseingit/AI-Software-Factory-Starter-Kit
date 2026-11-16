# Integration-Heavy System Test Strategy Pack

Use when multiple external services, gateways, or orchestration steps are central to the system.

## Focus
- contract alignment
- serialization and mapping
- timeout, retry, and failure handling
- idempotency where relevant
- user-visible error handling and logging

## Minimum expectations
- contract tests
- adapter/service tests
- failure-path tests
- orchestration tests
- review evidence for correlation IDs and logs when relevant
