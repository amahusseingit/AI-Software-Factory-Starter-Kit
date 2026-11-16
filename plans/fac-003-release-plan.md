# FAC-003: Factory release-readiness packet

User-authorized outcome: prepare the release-readiness assessment and create
the develop-to-main pull request, but do not merge it yet. This current chat
request authorizes this bounded preparation and PR publication; it does not
authorize merge, deployment, tagging or closure. No invented approval ID or
human identity is asserted.

Role: release-readiness assessor (implementing Codex agent). Sources: current
Factory governance, shipping-readiness skill, release-owner role, assessment
and scorecard templates, FAC-002 review evidence, actual local commands and
GitHub workflow results. This role assembles evidence; it supplies no
independent signoff for its own packet or implementation.

## Frozen identities and file scope

- Source: develop at 1b4a84d128423d7cc8861e08b3ceb15fb231c525.
- Source tree: 2f0938f41418ce4b3ec360af3320ba1982e5733e.
- Observed target: main at 4df16e0b73b2410daaab3960a0b5a9e846f9971b.
- Evidence task branch: task/fac-003-release-readiness, based on the source.
- Files: this plan, releases/release-readiness.md,
  reviews/release-readiness-scorecard.md, evidence/fac-003-release-checks.txt
  and one append-only handoff entry in docs/agent-run-log.md.
- Keep these new documents on the evidence branch. The release PR must use
  head develop and base main, retaining the exact tested source tree.

## Execution and proof

1. Confirm clean checkout, branch identities and absence of an existing release PR.
2. Inspect release delta, workflow triggers, provenance and prior review limitations.
3. Rerun canonical validation and the complete acceptance runner on the source.
4. Verify six actual GitHub jobs on that source; record an immutable source
   archive digest and outline promotion, smoke checks and rollback.
5. Write and validate the packet, commit/push only its task branch and link the
   packet by immutable commit in the develop-to-main PR.
6. Confirm PR refs and source identity; stop without merging either branch.

No application, infrastructure, secrets, global settings, repository protections
or runtime environments are changed. Every later source/target change requires
fresh affected checks and approval. A final merge decision belongs to the user.

## Authorized final-review iteration

The current user additionally requested final release/security review, rollback
applicability confirmation and ready-for-review status for PR #12, explicitly
prohibiting merge. The earlier permission to use an independent reviewer is
retained. Carver reassesses the exact source/target/integration revision as a
separate actor; the implementing parent verifies actual CI and rehearses source
rollback only in a disposable clone. No new application profile is activated.

Additional evidence outputs: evidence/fac-003-final-release-checks.json and the
independent final review record under reviews/. Update this packet/scorecard and
append a new log entry, commit/push only the evidence branch, link its immutable
commit from PR #12 and mark the unchanged release PR ready if checks permit.
No GitHub approval is submitted using the author's identity, and no source
branch, main/develop ref, tag or runtime environment is modified.
