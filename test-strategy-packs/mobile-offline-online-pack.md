> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Mobile Offline / Online Test Strategy Pack

Use when mobile apps must tolerate connectivity loss, queue work, or recover cleanly after reconnect.

## Focus
- offline state handling
- queued mutations and replay
- conflict handling
- local cache boundaries
- reconnect recovery and user messaging

## Minimum expectations
- state management tests
- sync boundary tests
- failure/retry tests
- user messaging verification for offline and reconnect states
