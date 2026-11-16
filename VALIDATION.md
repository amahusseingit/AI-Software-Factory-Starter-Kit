# Documentation validation and limits

Run from the repository root with Python 3.10 or later:

```sh
python3 tools/validate_factory.py
python3 -m unittest discover -s tools -p 'test_factory*.py' -v
git diff --cached --check -- . ":(exclude)archive/**"
```

The first command checks the canonical contract, selected authority pointers, local Markdown links and archived source SHA256 values. The second runs synthetic positive/negative records for the offline reference gate evaluator. Negative cases include missing/stale approval, scope change, QA failure, missing evidence, Critical/High security blockers, unknown/not-run/scope-mismatch states, self-signoff, missing closure approval, invalid planning append and exception/traceability defects. Test names and assertions in tools/test_factory_gates.py are the exact coverage inventory.

Use `python3 tools/validate_factory.py --record path/to/record.json` for a proposed record; it prints PASS/BLOCKED and exits 0/1. Tests construct example records; they are synthetic fixtures, never actual project evidence or approvals. The gate/close record evaluator is a simplified acceptance-stage record checker, not G1–G6 transition enforcement. It requires QA/security/independent review for every gate record and does not implement earlier-phase readiness or validate prior-gate transition history. It does not validate every canonical evidence field (such as repository, environment, tool/command, exit code or raw-output hash); human review must check the complete evidence template. Local-link checks exclude bare-code/prose paths, anchors and external URLs. The contract/evaluator is an offline reference implementation, not GitHub enforcement or an identity/approval authentication system. Operators must independently authenticate approvals, check actual evidence/artifacts and verify that the declared scope, required checks and expected AC set are complete. The tool cannot infer a missing requirement that was omitted from all input declarations. Markdown link validation does not prove external URLs or prose claims.

## Validation scope
This task changes documentation and documentation-validation utilities only. It does not run application builds, application tests, runtime QA, penetration tests or deployment validation. It changes no application formulas/code, secrets, environment setup, protections, repository settings or deployment triggers. No current Problems SLA SRS is supplied by the historical placeholder; the example profile cannot certify that module.

Full staged diff whitespace checking reports historical whitespace in newly archived files. It is intentionally preserved byte-for-byte; active-file whitespace checking excludes archive/**. This is disclosed provenance preservation, not a normalization of source bytes.

## Source verification
Every V7.8 archived file was compared byte-for-byte against genuine upstream git objects at cf3a9281569782ba2962850ba7c1db90a6533158. SOURCE_MANIFEST.json records archived file SHA256 values and original source paths, plus prior/updated July ZIP hashes. Archived instructions are inactive provenance, not current execution authority. This is a new draft version, not recovered V9.

Validation results for the exact final candidate are delivered with the review package and identified by its tree digest/commit. Rerun these commands after changes. A documentation PASS alone grants no role execution, merge, deployment or production-readiness approval.

## Branch record checks

`python3 tools/validate_branch_record.py --record path/to/record.json` checks declared task naming, default task/release/hotfix/reconciliation paths, full SHA syntax, declared current-base/current-head approval bindings, current-target merge-evidence binding and required PASS checks bound to the declared tested merge SHA. `tools/test_factory_branches.py` supplies synthetic positive/negative cases. It does not inspect Git history, prove actual target freshness or ancestry, authenticate approval/independence, discover undeclared checks, enforce uniqueness, verify tag/artifact/deployment state, or install branch protection. Bootstrap/legacy exceptions and release snapshot paths deliberately remain unsupported/BLOCKED by this minimal evaluator and require separately approved manual review. See the [branch record](templates/branch-record-template.md) and [proposed enforcement checklist](governance/branch-enforcement-checklist.md).

The proposed CI names are not installed check contexts. These local tests do not prove live GitHub enforcement, application behavior or deployment readiness.
