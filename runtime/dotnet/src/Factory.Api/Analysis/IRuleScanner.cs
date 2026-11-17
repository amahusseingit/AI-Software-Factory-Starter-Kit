using Factory.Api.Contracts;
namespace Factory.Api.Analysis;

public interface IRuleScanner
{
    ScanResult Scan(string fileName, string source, CancellationToken cancellationToken = default);
}
