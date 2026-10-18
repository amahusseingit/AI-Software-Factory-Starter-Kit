---
name: sqlserver-data-delivery
description: Use when modeling or implementing persistence on Microsoft SQL Server.
triggers:
  - sql server
  - ef core
  - migration
  - schema
---

# Overview

This skill enforces SQL Server as the system of record and drives safe schema and migration decisions.

# When to Use

Use whenever entities, migrations, indexes, constraints, amounts, audit columns, or transaction semantics are involved.

# Inputs Required

- data model
- business rules
- audit needs
- performance concerns

# Process

1. Confirm SQL Server is the intended database
2. Define entities, keys, and relationships
3. Define constraints and indexes
4. Define audit and status columns
5. Define migration sequence
6. Validate amount/date precision and transaction behavior

# Rationalizations to Reject

| Excuse | Why it is invalid |
|---|---|
| Another provider is easier for scaffolding | Stack drift creates hidden rework |
| We can normalize the schema later | Early schema shortcuts often leak into code and tests |

# Red Flags

- non-SQL Server provider introduced
- missing FK/constraint definitions
- missing audit fields where required
- money fields with unsafe precision

# Verification

- SQL Server provider confirmed
- schema and migrations are explicit
- data rules align with business behavior

# Outputs

- data model notes
- migrations
- SQL Server checklist alignment
