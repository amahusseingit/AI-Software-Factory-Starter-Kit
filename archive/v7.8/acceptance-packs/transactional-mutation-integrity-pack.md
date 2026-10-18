# Transactional Mutation Integrity Acceptance Pack

Use this pack for any system where record mutations affect aggregate values, derived values, counters, balances, totals, inventory, or downstream workflow state.

## Create Record
- valid creation updates all defined aggregates or derived values correctly
- duplicate submission protection is applied where required
- audit fields are populated

## Edit Record
- editing reverses or recalculates prior impacts correctly
- derived data remains internally consistent
- downstream state is updated or blocked according to the spec

## Delete or Reverse Record
- delete, void, cancel, or reverse behavior follows the project spec
- prior impacts are reversed or compensated correctly
- data integrity is preserved

## Verification
- at least one positive mutation case is proven end to end
- at least one negative or invalid case is proven
- automated tests cover aggregate consistency after create, edit, and delete/reverse operations
