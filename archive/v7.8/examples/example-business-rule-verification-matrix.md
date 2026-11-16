# Example Business Rule Verification Matrix

| Rule ID | Rule description | Trigger / context | Expected behavior | Implementation area | Automated tests | Evidence | Review result | Status |
|---|---|---|---|---|---|---|---|---|
| BR-001 | Ownership is enforced | User accesses another user's resource | Access is denied | API authorization layer | ownership negative test | evidence/authorization-proof.md | GO | Complete |
| BR-002 | Delete requires confirmation | User clicks delete in UI | Confirmation is shown before mutation | Web and mobile UI actions | UI delete confirmation tests | evidence/ui-delete-proof.md | GO | Complete |
