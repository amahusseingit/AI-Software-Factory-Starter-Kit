# Problems SLA: historical example profile

NON-AUTHORITATIVE EXAMPLE. This preserves historical domain detail for review and potential future adaptation. It is not the current SRS, an approved configuration, a formula specification, evidence of implementation, or authority to change a project. Do not load it by default or treat its examples as acceptance criteria.

The supplied updated kit contains only `archive/july-updated/problems_sla_dashboard_srs_PLACEHOLDER.md`, which asks for the real `problems_sla_dashboard_srs.md` outside the kit. The current authoritative SRS was not supplied by that placeholder. Implementation based on these rules is blocked until the user supplies/identifies the current SRS, reconciles discrepancies, explicitly selects this profile and approves the resulting requirements and role plans.

## Historical intent and epics

The source described production-problem response/resolution reporting, separating engineering delay from waiting/vendor/verification/parked delay, with Jira changelog timing, scope validation before scores, unmatched-contributor reporting and management team/engineer scorecards.

Historical epic suggestions were configuration; Jira extraction/changelog processing; calculation engine; dashboard UI; scope validation/data quality; security/audit/export/operations; and QA/acceptance traceability. The original sequence was settings/data model, ingestion, calculation, aggregation/APIs, summary UI, scorecards, aging/breach views, reconciliation, export/hardening and final QA. These are candidate decomposition examples only.

## Historical rules requiring current-SRS reconciliation

| Historical topic | Earlier kit statement, not an approved current rule |
|---|---|
| Timing source | Jira changelog transitions, not gadget counts |
| First response | Created/Draft to Analysis |
| Engineering resolution | First Analysis to first Resolved, excluding configured pauses |
| Closure | Resolved to Done; Done was not the primary engineering stop |
| End-to-end | Created/Draft to Resolved or Done, with exact choice needing specification |
| Pauses | Parked, Pending Vendor and Pending Verification were suggested defaults |
| Backlog | Configurable inclusion/exclusion |
| Decommissioned | Suggested exclusion from normal calculations |
| Scope | Configured project and configured active member; Software Engineer owner validation |
| Invalid ownership | Missing/unmatched owners reported; invalid scope must not silently inflate scores |
| Open work | Open-overdue problems affected the historical score |
| Reopening | Reopened problems require explicit treatment; no complete policy supplied here |
| Scoring | Historical candidate: Resolved Within SLA / (Resolved Within SLA + Resolved Breached + Open Overdue) × 100 |
| Weighting/signals | Priority-weighted score and signal bands were requested, but approved weights/boundaries are not established here |
| Time/configuration | Calendar mode, effective-date settings and calculation versions need current definitions |

Do not resolve denominator-zero behavior, time zones, calendars, repeated reopenings, malformed or out-of-order events, weighting, thresholds or default settings by guessing. Obtain authoritative expected results.

## Preserved QA scenario inventory

These 17 original scenarios are test-design prompts, not passed tests. Every selected scenario needs an approved requirement/criterion, explicit input fixture, expected result and current candidate evidence.

| # | Historical scenario | Reconciliation/test-design question |
|---|---|---|
| 1 | Analysis → Development → Testing → Resolved | What timestamps and calendar produce each approved duration? |
| 2 | Analysis → Pending Vendor → Development → Resolved | Is this pause configured, and how is excluded time audited? |
| 3 | Pending Verification pause | What pause intervals and boundaries apply? |
| 4 | Parked pause | Is Parked a pause in this requirement/configuration version? |
| 5 | Backlog included in SLA | Which interval and calendar are included? |
| 6 | Backlog excluded from SLA | How is the excluded interval represented and reconciled? |
| 7 | Decommissioned exclusion | What exclusion reason and audit evidence are required? |
| 8 | Missing Software Engineer | How is invalid ownership surfaced without silent scoring distortion? |
| 9 | Unmatched contributor | What project/member mapping and reconciliation result apply? |
| 10 | Missing priority | Is calculation blocked, flagged or handled by an approved fallback? |
| 11 | Missing changelog | How is unverified timing shown without invented history? |
| 12 | Missing Analysis transition | Which explicit fallback or invalid-data behavior applies? |
| 13 | Direct transition to Resolved | What durations are valid and what remains unknown? |
| 14 | Reopened problem | Which cycles, start/stop events and aggregation rule apply? |
| 15 | Open overdue problem | What as-of time, target and inclusion rules apply? |
| 16 | Priority-weighted score | Which approved weights and denominator rules apply? |
| 17 | Signal band boundaries | Which exact thresholds and inclusive/exclusive boundaries apply? |

The original pause example expected excluded active-resolution time, separately visible paused time and an audit trail when Pending Vendor was configured as a pause. Preserve that as a candidate scenario, not an automatic requirement.

## Historical implementation/design examples

The earlier design named calculation/query/settings/extraction/aggregation services, `ProblemSlaSettings`, `ProblemSlaCalculationResult` and `ProblemSlaAggregationResult`. Suggested endpoints under `/api/problems-sla/` were summary, team-scorecard, engineer-scorecard, issues, workflow-aging, breach-analysis, settings (read/update), extract and recalculate. These names/routes are archival examples only; no current route, permission or data model is established by this document.

Data design called for canonical Jira extraction reuse, primary/business keys, required/nullable fields, indexes, audit/version fields and migration analysis. Quality checks included missing owner/priority/changelog/Analysis/Resolved, unmapped status, unmatched contributor and unconfigured project. Applicable generic design responsibilities are retained in the architect role.

UI suggestions included filters, executive cards, trends, team/engineer scorecards, workflow aging, breach analysis, open-overdue and waiting/paused tables, data-quality findings and issue drill-downs. Historical authorization suggestions distinguished dashboard viewing, detailed records, settings, extraction/recalculation and export; the actual access matrix must be approved for the current project.

## Review before selecting

- Supply and identify authoritative SRS revision and approved technical decisions.
- Reconcile every selected historical rule, especially formulas, default pauses, calendars and reopening.
- Confirm project/member ownership mapping and required authorization.
- Approve source-to-story-to-criterion traceability and expected test results.
- Record selected stack separately, if applicable; this example does not select one.
- Follow canonical security, approval, QA and closure gates; historical verdict or severity labels are not active governance.

## Provenance

Repository-relative archived sources: `archive/july-prior/ai_software_factory_kit_problems_sla/skills/product-owner/skill.md`, `skills/solution-architect/skill.md`, `skills/developer/skill.md`, `skills/qa-static-analysis/skill.md`, and the corresponding four files under `archive/july-updated/ai_software_factory_kit_problems_sla/`. The missing-SRS evidence is `archive/july-updated/problems_sla_dashboard_srs_PLACEHOLDER.md`. Earlier paths for the last three skills use the same complete root as the first. Originals are retained by the source archive/manifest; this profile preserves substance without activating it.
