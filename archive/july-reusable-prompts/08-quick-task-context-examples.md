# Quick Task Context Examples

Use these examples to replace the **Task Context** section in the reusable prompts.

## Product Owner Examples

### Create Stories for Next Slice

```text
Create or refine the Product Owner stories for the next Problems SLA Dashboard slice based on the latest shared-log handoff. Ensure each story has acceptance criteria, data-quality rules, and test expectations.
```

### Update Acceptance Criteria After QA Feedback

```text
Review the QA feedback in the shared log and update only the affected acceptance criteria for the relevant Problems SLA stories. Do not change implementation or architecture.
```

## Architect Examples

### Architecture for Next Slice

```text
Prepare the architecture plan for the next Problems SLA Dashboard slice. Use the latest PO stories and shared-log handoff to identify the exact scope.
```

### Architecture Adjustment After QA Finding

```text
Review the QA finding and Developer remediation notes. Determine whether the architecture design needs clarification or correction. Prepare an architecture adjustment plan only.
```

## Developer Examples

### Implement Next Slice

```text
Implement the next approved Problems SLA Dashboard slice. Use the shared log to identify the exact story IDs, approved architecture handoff, and scope exclusions.
```

### Implement One Story Only

```text
Implement story PSLA-XXX only. Do not start any other story. Use the shared log to confirm dependencies and handoff instructions.
```

## Developer Remediation Examples

### Fix QA Findings

```text
Remediate QA-001, QA-002, and QA-003 only. Do not start the next slice. Use the QA report and shared-log handoff to identify the failed acceptance criteria and expected behavior.
```

### Fix Build Failure

```text
Remediate the build/test failure reported by QA for the latest slice. Do not change business logic unless required to fix the reported issue.
```

## QA Examples

### Validate Latest Developer Handoff

```text
Validate the latest Developer handoff for the Problems SLA Dashboard. Use the shared log to identify the story IDs, changed files, and acceptance criteria under test.
```

### Validate One Story Only

```text
Validate story PSLA-XXX only. Do not test other stories except for directly impacted regression checks.
```

## QA Regression Examples

### Regression After Remediation

```text
Run QA regression for remediated findings QA-001, QA-002, and QA-003 only. Validate the fixes, impacted acceptance criteria, and focused regression scope. Do not test the next slice.
```

## Slice Closure Examples

### Close Slice After QA

```text
Prepare a closure summary for the latest Problems SLA Dashboard slice after QA completion. Determine whether the slice is ready to baseline and whether the next slice may start.
```

### Close Remediation Cycle

```text
Prepare a closure summary for the remediation cycle of QA-001, QA-002, and QA-003. Determine whether Slice 1 is now ready to baseline.
```
