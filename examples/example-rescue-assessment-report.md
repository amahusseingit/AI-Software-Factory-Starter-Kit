> Unified draft: subordinate guidance only. The root governance/protocol.md and governance/security-policy.md control approvals, lifecycle, decisions and security. Examples/templates are not evidence; select stack/domain content only through approved project scope. Historical source is preserved in archive/v7.8/.

# Example Rescue Assessment Report

## Project
example system

## Current State Summary
- backend exists
- Angular list screens exist for Accounts, Categories, Transactions
- Flutter list screens exist for Accounts, Categories, Transactions
- create/edit/delete behavior is missing on multiple modules

## Major Gaps
- visible Add buttons not wired
- no edit flow on mobile
- delete missing on both platforms for Categories
- balance recalculation tests missing

## Rescue Priorities
1. stack conformance
2. accounts full CRUD
3. categories/subcategories full CRUD
4. transactions full CRUD and balance correctness
5. parity and review closure
