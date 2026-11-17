using Factory.Api.Agents;
using Factory.Api.Contracts;
namespace Factory.Api.Analysis;

public interface IAnalysisService
{
    Task<AnalysisResponse> AnalyzeAsync(AnalysisRequest request, CancellationToken cancellationToken = default);
}
public sealed class AnalysisService(IRuleScanner scanner, IAgentReviewService agents) : IAnalysisService
{
    public async Task<AnalysisResponse> AnalyzeAsync(AnalysisRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (string.IsNullOrWhiteSpace(request.FileName) || request.FileName.Length > 260 || request.FileName.Any(char.IsControl) || string.IsNullOrWhiteSpace(request.SourceCode) || request.SourceCode.Length > 20000)
            throw new ArgumentException("Invalid analysis fields.", nameof(request));
        var scan = scanner.Scan(request.FileName!, request.SourceCode!, cancellationToken);
        var review = scan.Diagnostics.Count == 0 ? await agents.ReviewAsync(request, scan, cancellationToken) : new ReviewResult("NOT_RUN");
        return new(Guid.NewGuid().ToString("N"), review.Status, scan.SourceDigest, scan.AnalyzerVersion, scan.Findings, scan.Diagnostics, review.Review, review.ErrorCode);
    }
}
