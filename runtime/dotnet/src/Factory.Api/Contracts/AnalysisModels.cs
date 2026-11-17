namespace Factory.Api.Contracts;

public sealed record AnalysisRequest(string? FileName, string? SourceCode, bool ConsentToSendCode = false);
public sealed record Finding(string Id, string RuleId, string FileName, int Line, int Column, int SpanOffset, int SpanLength, string Category, string Evidence, string Recommendation, string ReviewPriority = "NEEDS_POLICY_REVIEW");
public sealed record SyntaxIssue(string Code, int Line, int Column);
public sealed record ScanResult(string SourceDigest, string AnalyzerVersion, IReadOnlyList<Finding> Findings, IReadOnlyList<SyntaxIssue> Diagnostics);
public sealed record AgentReview(string AnalystReport, string AdvisoryCritique);
public sealed record ReviewResult(string Status, AgentReview? Review = null, string? ErrorCode = null);
public sealed record AnalysisResponse(string RunId, string AgentStatus, string SourceDigest, string AnalyzerVersion, IReadOnlyList<Finding> Findings, IReadOnlyList<SyntaxIssue> Diagnostics, AgentReview? AgentReview, string? ErrorCode)
{
    public string Decision => "BLOCKED";
    public string Notice => "Syntax heuristic and untrusted advisory text only; no approval or completeness claim.";
}
