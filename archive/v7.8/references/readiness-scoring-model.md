# Readiness Scoring Model

Use this model to produce consistent go / conditional go / no-go decisions.

## Scoring scale
- 0 = missing
- 1 = weak
- 2 = partial
- 3 = acceptable
- 4 = strong
- 5 = very strong

## Core dimensions
- Spec completeness
- Functional completeness
- UI completeness
- Test adequacy
- Architecture consistency
- Stack conformance
- Evidence completeness
- Release readiness

## Suggested thresholds
- 0-1: blocked
- 2: major warnings
- 3: acceptable with known gaps
- 4-5: strong

## Decision model
- **Go**: no critical blockers and average score >= 4.0
- **Conditional Go**: no unowned blockers and average score >= 3.0
- **No-Go**: any critical blocker or average score < 3.0

## Critical blocker examples
- Authoritative spec missing
- Required workflow missing
- Required stack not enforced
- Visible UI actions not behaviorally implemented
- Automated tests missing for core business behavior
