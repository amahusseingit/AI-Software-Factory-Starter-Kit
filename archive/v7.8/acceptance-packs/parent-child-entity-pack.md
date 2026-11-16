# Parent Child Entity Acceptance Pack

Use this pack when one entity owns or contains another entity, such as category/subcategory, project/task, order/item, or form/field.

## Parent Entity
- parent CRUD follows the generic entity CRUD pack
- parent state changes enforce child rules correctly

## Child Entity
- child can only be created under a valid parent
- child edit loads existing data correctly
- child delete or deactivate follows the spec-defined business rules
- UI reflects parent-child hierarchy accurately

## Integrity Rules
- orphan child records are prevented unless explicitly allowed
- parent-child authorization rules are enforced
- parent summary views refresh after child mutations
