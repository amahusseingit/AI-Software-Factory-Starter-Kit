[CmdletBinding()]
param(
    [Parameter()][string]$Root = (Split-Path -Parent $PSScriptRoot),
    # Compatibility switch: the canonical validator always fails closed.
    [Parameter()][switch]$Strict,
    [Parameter()][string]$Python = 'python'
)

$ErrorActionPreference = 'Stop'
try {
    $factoryRoot = (Resolve-Path -LiteralPath $Root).Path
    & $Python -B (Join-Path $factoryRoot 'tools/validate_factory.py') --root $factoryRoot
    exit $LASTEXITCODE
} catch {
    Write-Error "Factory validation could not run: $_"
    exit 1
}
