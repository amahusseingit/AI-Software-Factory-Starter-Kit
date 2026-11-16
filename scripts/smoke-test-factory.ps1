[CmdletBinding()]
param(
    [Parameter()][string]$Root = (Split-Path -Parent $PSScriptRoot),
    [Parameter()][string]$Python = 'python'
)

$ErrorActionPreference = 'Stop'
try {
    $factoryRoot = (Resolve-Path -LiteralPath $Root).Path
    & $Python -B (Join-Path $factoryRoot 'tools/run_factory_tests.py') --root $factoryRoot
    exit $LASTEXITCODE
} catch {
    Write-Error "Factory synthetic tests could not run: $_"
    exit 1
}
