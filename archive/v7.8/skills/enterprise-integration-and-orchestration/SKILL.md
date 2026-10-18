---
name: enterprise-integration-and-orchestration
description: Use when the system integrates with external APIs, gateways, orchestration layers, ESBs, message brokers, or third-party platforms.
---

# Overview

This skill governs reliable external integration design and delivery for enterprise systems.

# When to Use

Use for:
- third-party APIs
- internal platform integrations
- ESB, API gateway, service mesh, or orchestration layers
- async events, queues, and broker-based workflows
- callback, webhook, and polling integrations

# Process

1. identify integration boundaries and owners
2. define request and response contracts
3. define error mapping and retry rules
4. define idempotency and duplicate prevention where needed
5. define correlation IDs, audit fields, and observability
6. define timeout, fallback, and degradation behavior
7. implement contract tests and failure-path tests

# Rationalizations to Reject

- integration details can be figured out later
- success path is enough for first delivery
- logging can be added later

# Red Flags

- undocumented response mapping
- no timeout or retry policy
- no idempotency for retry-prone operations
- no audit or correlation fields

# Verification

- contracts are documented
- normal and failure flows are tested
- audit and observability behavior is defined
- retry and duplicate handling are proven where applicable
