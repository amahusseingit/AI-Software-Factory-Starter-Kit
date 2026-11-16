# Task branches and release promotion

This is the generic branching contract under the [canonical protocol](protocol.md). It applies to **every coding, configuration and documentation task**, including remediation and hotfixes. It does not select a project profile or configure remote protections, environments, credentials, triggers or deployments. Settings require separate approval and verification; see [enforcement checklist](branch-enforcement-checklist.md).

## 1. Identity and approved base

- Create one new branch per bounded task: `task/<task-id>-<short-slug>`, for example `task/fac-42-define-branching-rules` or `task/app-107-fix-export`. Use a unique, registered lowercase task ID such as `fac-42` (letters/digits, hyphen, numeric ID), and a lowercase hyphen-separated slug. Do not reuse a branch or task ID for unrelated work. Retrying the same approved task may continue its branch; a new scope requires a new task and plan.
- Before changing files, verify the canonical remote, approved base ref and full commit SHA in a genuine checkout. Fetch the target and inspect deployment triggers first. The approved plan binds the input base; output revisions need fresh downstream evidence. Never manufacture ancestry from copied files.
- Record repository, task ID, plan/approval reference, branch, base ref/SHA, output head SHA, intended PR target and observed target SHA using the [branch record](../templates/branch-record-template.md). Explicitly identify bootstrap exceptions; do not silently fall back to main when develop is absent.
- Normal tasks branch from approved `develop` and PR back to `develop`. No direct writes to `main` or `develop`, even for small fixes or documentation. No force pushes (including force-with-lease), shared-branch rebases or rewritten published history. Update task branches by reviewed merge commits. Never rewrite release tags.
- A fresh repository may bootstrap from a specifically approved `main` SHA before `develop` exists. The exception must name the task, exact base and target, and expiry at that task's completion. It does not adopt a topology or authorize creating/publishing develop, merging, or deployment. A legacy task name must be recorded as an explicit one-task migration exception rather than accepted as the future naming convention.

## 2. Integration and review

The proposed adopted topology is `task/<id>-<slug>` → reviewed PR → `develop` → pinned release review → `main`. Adoption is a separate repository-specific decision. `develop` is an integration branch; `main` is approved release history, not proof of what is deployed.

Every PR identifies its task, approved base, changed scope, intended target and exact head. Require current developer checks, independent QA/review, named human decision owner, resolved review conversations and explicit authorization to merge that candidate into that target. The author cannot provide independent signoff. Each role still needs its approved plan. A green check, PR approval, task closure or draft PR does not itself authorize merge, publication or deployment.

Required checks are an explicit per-repository list of **exact reported names and trusted producers**, validated on a real PR before settings make them required. Never invent application job names. For the Factory, propose `factory-docs`, `factory-gate-tests`, and `factory-branch-contract`; these are proposed CI names only, not installed checks. Application projects select their own build, tests, security and release checks through approved profiles.

All required results must be PASS/success on the current candidate and its tested integration result. Missing, skipped, cancelled, neutral, pending, stale, unknown or failing results block. Require an up-to-date tested target or a verified merge queue result; checking only an old task head is insufficient. The offline [branch validator](../tools/validate_branch_record.py) checks a declared record only; it cannot authenticate approval, discover omitted checks or prove a GitHub merge result.

## 3. Release candidate and staging

- Freeze the release scope and pin the exact develop candidate SHA. The release PR uses that candidate toward main. A moving develop branch must not silently add later work: stop and reapprove a new candidate, or use a separately approved immutable `release/<release-id>-<slug>` snapshot from that SHA. A release snapshot is not a second development branch; fixes use new task branches and requalification.
- Staging is an **environment**, not a mandatory branch. Record real deployment triggers, artifact identity, configuration and isolation before proposing any mapping. Do not add a staging branch or infer main-to-production automatic deployment.
- Build once, record artifact digest and provenance, validate the same artifact in staging, and promote that digest after explicit release and deployment approval. Runtime configuration is injected separately and its delta reviewed. A rebuild produces a new artifact and requires requalification. If merge/conflict resolution changes candidate content, repeat affected checks, QA and approvals; do not transfer a PASS by branch name.
- Release evidence binds source SHA, tested merge SHA, artifact digest, environment, exact required checks, independent QA, security disposition, approved configuration delta, rollback/backup/migration evidence where applicable, release approver and explicit action. Capture the deployed digest/SHA afterward; tagging or merging does not prove deployment.
- Factory releases version the generic kit. They never deploy a consuming application's code or change its data, credentials, hosting, release branch or project profile. A consuming application's integration/deployment mapping is approved and verified separately.

## 4. Hotfix and reconciliation

Start `task/<id>-hotfix-<slug>` from the **verified exact production tag and its resolved commit** (for Factory, the released kit tag). Compare with the observed deployed/released artifact provenance; never assume main HEAD equals production. Record any unavailable tag/provenance as BLOCKED, not a guessed baseline.

Review the hotfix PR into main with scoped developer tests, independent QA/review and separate release/deployment approval. Validate the intended main merge result: unrelated commits must not hitchhike into production. If main has diverged beyond production, stop for an approved isolated release strategy rather than merging blindly. Reconcile the exact released fix into develop using a **new** `task/<id>-reconcile-<slug>` branch from approved develop and a reviewed PR, with original hotfix/release references and impacted regression checks. Reconciliation is a separate approved task; never backmerge directly into develop or claim hotfix completion while reconciliation is unresolved.

## 5. Freshness, conflicts and lifecycle

Any new commit, changed base/target, resolved conflict, material scope/requirement/plan change, artifact rebuild or configuration change invalidates affected evidence and approvals. Stop and replan where required by the protocol; rerun checks on the new exact result and obtain current independent approval. GitHub stale-review dismissal is a technical aid, not the entire evidence rule.

Keep the branch until merge or explicit abandonment, evidence/PR links are retained, and any hotfix reconciliation is accounted for. Delete only under an explicitly approved recoverable branch-retention policy or specific deletion authorization. Never delete protected release history or immutable tags as routine cleanup. Abandoned work is recorded, not silently reused. If tooling or remote permissions are unavailable, deliver a provenance-pinned patch and state which checks/actions were not performed.

## 6. Environment isolation

Development, staging and production must have separately scoped runtime identities, credentials, databases, storage, external service/test accounts and deployment permissions. Development/PR jobs have no production secrets or write access. Use synthetic or explicitly approved sanitized fixtures. Never reset/reseed operational data. Record actual mapping using the [environment matrix](../templates/environment-matrix-template.md); unknown mapping blocks deployment changes. No infrastructure purchase, credential creation or expanded persistent access is authorized by these rules.
