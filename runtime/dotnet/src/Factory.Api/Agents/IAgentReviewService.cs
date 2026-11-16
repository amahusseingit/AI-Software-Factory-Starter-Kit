using Factory.Api.Contracts;
namespace Factory.Api.Agents;

public interface IAgentReviewService
{
    Task<ReviewResult> ReviewAsync(AnalysisRequest request, ScanResult scan, CancellationToken cancellationToken = default);
}
