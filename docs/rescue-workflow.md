# Rescue Workflow

Use rescue mode when a project already exists but is incomplete, inconsistent, or partially generated.

## Typical triggers
- list screens exist but create/edit/delete are missing
- actions are visible but not wired
- Angular is ahead of Flutter or vice versa
- tests are shallow or missing
- SQL Server was required but another database was configured
- workflows exist in the spec but not in the code

## Rescue sequence
1. Confirm the authoritative spec and required stack
2. Inventory implemented modules and gaps
3. Build a UI action inventory
4. Build a stack conformance report
5. Build a parity report across API, Angular, and Flutter
6. Re-slice only the missing or broken work
7. Implement and test module by module
8. Re-run review gates before closure

## Mandatory rescue artifacts
- rescue assessment report
- stack conformance report
- UI action inventory
- traceability gap report
- parity report
- regression test plan
- review report
