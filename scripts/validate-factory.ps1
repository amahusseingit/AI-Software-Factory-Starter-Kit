[CmdletBinding()]
param(
    [Parameter()][string]$Root = (Split-Path -Parent $PSScriptRoot),
    [Parameter()][switch]$Strict
)

$ErrorActionPreference = 'Stop'
$errors = [System.Collections.Generic.List[string]]::new()
$warnings = [System.Collections.Generic.List[string]]::new()

function Add-Error([string]$Message) { [void]$errors.Add($Message) }
function Add-Warning([string]$Message) { [void]$warnings.Add($Message) }
function Require-Path([string]$RelativePath) {
    if (-not (Test-Path -LiteralPath (Join-Path $Root $RelativePath))) {
        Add-Error "Missing required path: $RelativePath"
    }
}

$required = @(
    'AGENTS.md', 'ORCHESTRATOR.md', 'commands/START-PROJECT.md',
    'commands/SPEC.md', 'commands/PLAN.md', 'commands/BUILD.md',
    'commands/VERIFY.md', 'commands/TEST.md', 'commands/REVIEW.md',
    'commands/SHIP.md', 'skills/orchestration-and-lifecycle-control/SKILL.md',
    'skills/codex-factory-adapter/SKILL.md', 'agents/role-registry.md',
    'templates/handoff-contract-template.md'
)
$required | ForEach-Object { Require-Path $_ }

$agents = Get-Content -Raw (Join-Path $Root 'AGENTS.md')
$orchestrator = Get-Content -Raw (Join-Path $Root 'ORCHESTRATOR.md')
$commandsGuide = Get-Content -Raw (Join-Path $Root 'docs/commands-guide.md')

if ($agents -notmatch '1\. DEFINE[\s\S]*4\. VERIFY[\s\S]*6\. SHIP') {
    Add-Error 'AGENTS.md does not declare the canonical VERIFY lifecycle.'
}
if ($orchestrator -notmatch 'VERIFY\(TEST\)') {
    Add-Error 'ORCHESTRATOR.md does not map VERIFY to TEST.'
}
if ($commandsGuide -notmatch 'TEST[\s\S]*VERIFY') {
    Add-Error 'docs/commands-guide.md does not explain the TEST/VERIFY mapping.'
}

$allMarkdown = Get-ChildItem -LiteralPath $Root -Recurse -File -Filter '*.md'
foreach ($file in $allMarkdown) {
    $content = Get-Content -Raw $file.FullName
    foreach ($match in [regex]::Matches($content, '\[[^\]]+\]\(([^)#]+)(?:#[^)]+)?\)')) {
        $target = $match.Groups[1].Value
        if ($target -and $target -notmatch '^(https?|mailto):') {
            $resolved = Join-Path $file.DirectoryName $target
            if (-not (Test-Path -LiteralPath $resolved)) {
                Add-Error "Broken Markdown link: $($file.FullName) -> $target"
            }
        }
    }
}

$staleReferences = @('docs/architecture.md', 'docs/traceability-matrix.md')
foreach ($stale in $staleReferences) {
    $hits = $allMarkdown | Select-String -Pattern ([regex]::Escape($stale))
    if ($hits) { Add-Error "Stale non-canonical artifact reference: $stale" }
}

$roleRegistry = Get-Content -Raw (Join-Path $Root 'agents/role-registry.md')
foreach ($role in @('Orchestrator','Analyst','Architect','Developer','Tester','Reviewer')) {
    if ($roleRegistry -notmatch [regex]::Escape("| $role |")) {
        Add-Error "Role registry is missing required role: $role"
    }
}

if ($Strict -and $warnings.Count -gt 0) {
    foreach ($warning in $warnings) { Add-Error "Strict warning: $warning" }
}

if ($errors.Count -gt 0) {
    Write-Output 'FACTORY VALIDATION: FAIL'
    $errors | ForEach-Object { Write-Output "ERROR: $_" }
    exit 1
}

Write-Output 'FACTORY VALIDATION: PASS'
Write-Output "Checked Markdown files: $($allMarkdown.Count)"
Write-Output 'Repository was not modified by this validation.'
exit 0
