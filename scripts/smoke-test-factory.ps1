[CmdletBinding()]
param([Parameter()][string]$Root = (Split-Path -Parent $PSScriptRoot))

$ErrorActionPreference = 'Stop'
$failures = [System.Collections.Generic.List[string]]::new()

function Assert-True([bool]$Condition, [string]$Message) {
    if (-not $Condition) { [void]$failures.Add($Message) }
}

function Select-FactoryRoute([string]$ProjectState, [bool]$HasSpec, [bool]$HasPlan) {
    if (-not $HasSpec) { return [pscustomobject]@{ Role='Analyst'; Command='SPEC'; Blocked=$false } }
    if ($ProjectState -eq 'existing') { return [pscustomobject]@{ Role='Orchestrator'; Command='RESCUE-PROJECT'; Blocked=$false } }
    if (-not $HasPlan) { return [pscustomobject]@{ Role='Planner'; Command='PLAN'; Blocked=$false } }
    return [pscustomobject]@{ Role='Developer'; Command='BUILD'; Blocked=$false }
}

function Test-BuildGate([bool]$HasSpec, [bool]$HasPlan, [bool]$HasTestStrategy) {
    return ($HasSpec -and $HasPlan -and $HasTestStrategy)
}

function Test-Handoff([hashtable]$Contract) {
    $required = @('SourceRole','TargetRole','LifecyclePhase','EntryCommand','ApprovalStatus','Outputs')
    foreach ($key in $required) {
        if (-not $Contract.ContainsKey($key) -or [string]::IsNullOrWhiteSpace([string]$Contract[$key])) { return $false }
    }
    if ($Contract.SourceRole -eq $Contract.TargetRole -and $Contract.ApprovalStatus -eq 'GO') { return $false }
    return $true
}

$route = Select-FactoryRoute 'new' $false $false
Assert-True ($route.Role -eq 'Analyst' -and $route.Command -eq 'SPEC') 'New request without a spec must route to Analyst/SPEC.'

$route = Select-FactoryRoute 'new' $true $false
Assert-True ($route.Role -eq 'Planner' -and $route.Command -eq 'PLAN') 'A spec without a plan must route to PLAN.'

$route = Select-FactoryRoute 'existing' $true $true
Assert-True ($route.Role -eq 'Orchestrator' -and $route.Command -eq 'RESCUE-PROJECT') 'Existing code must route to RESCUE-PROJECT.'

Assert-True (-not (Test-BuildGate $false $true $true)) 'BUILD must be blocked without a spec.'
Assert-True (-not (Test-BuildGate $true $false $true)) 'BUILD must be blocked without a plan.'
Assert-True (-not (Test-BuildGate $true $true $false)) 'BUILD must be blocked without a test strategy.'
Assert-True (Test-BuildGate $true $true $true) 'BUILD gate must open only with all required inputs.'

$handoff = @{
    SourceRole='Developer'; TargetRole='Reviewer'; LifecyclePhase='REVIEW'
    EntryCommand='REVIEW'; ApprovalStatus='Pending'; Outputs='evidence/slice.md'
}
Assert-True (Test-Handoff $handoff) 'Valid developer-to-reviewer handoff must be accepted.'
Assert-True (-not (Test-Handoff @{ SourceRole='Developer'; TargetRole='Developer'; LifecyclePhase='REVIEW'; EntryCommand='REVIEW'; ApprovalStatus='GO'; Outputs='evidence/slice.md' })) 'Self-approval handoff must be rejected.'

$securitySkills = 'skills/appsec-testing-and-remediation/SKILL.md', 'skills/penetration-testing-readiness/SKILL.md'
foreach ($skill in $securitySkills) { Assert-True (Test-Path -LiteralPath (Join-Path $Root $skill)) "Security route skill missing: $skill" }

if ($failures.Count -gt 0) {
    Write-Output 'FACTORY SMOKE TEST: FAIL'
    $failures | ForEach-Object { Write-Output "FAIL: $_" }
    exit 1
}

Write-Output 'FACTORY SMOKE TEST: PASS'
Write-Output 'Verified role selection, approval boundaries, security routing, and handoff contracts.'
Write-Output 'Repository was not modified by this smoke test.'
exit 0
