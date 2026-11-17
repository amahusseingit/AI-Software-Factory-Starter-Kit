#!/usr/bin/env bash
# Approved FACT-005 developer checks only; no provider calls, publication or deployment.
set -u
cd /workspace/factory-dotnet10/runtime/dotnet
capture=/workspace/factory-dotnet10/evidence/fact-005/scripts/capture-command.py
sdk=/workspace/.factory-tools/dotnet/dotnet
status=0
python3 "$capture" format-apply -- "$sdk" format Factory.slnx --no-restore || status=1
if python3 "$capture" build -- "$sdk" build Factory.slnx -c Release --no-restore --disable-build-servers; then
  python3 "$capture" tests -- "$sdk" test Factory.slnx -c Release --no-build --logger trx --results-directory artifacts/tests || status=1
else
  status=1
fi
python3 "$capture" format-verify -- "$sdk" format Factory.slnx --verify-no-changes --no-restore || status=1
python3 "$capture" dependency-audit -- "$sdk" list Factory.slnx package --vulnerable --include-transitive --format json || status=1
python3 "$capture" dependency-deprecation -- "$sdk" list Factory.slnx package --deprecated --include-transitive --format json || status=1
exit "$status"
