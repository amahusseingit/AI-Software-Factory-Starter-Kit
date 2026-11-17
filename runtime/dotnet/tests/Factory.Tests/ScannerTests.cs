using System.Security.Cryptography;
using System.Text;
using Factory.Api.Analysis;
using Factory.Api.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace Factory.Tests;

public sealed class ScannerTests
{
    private static RoslynRuleScanner Scanner(params string[] terms) => new(Options.Create(new AnalysisOptions { IdentifierTerms = terms }));

    [Theory]
    [InlineData("tier == \"gold\"")]
    [InlineData("\"gold\" != tier")]
    [InlineData("item.TIER == 1.5m")]
    [InlineData("42 != item.tier")]
    [InlineData("@tier == \"gold\"")]
    [InlineData("tier == \"\"\"gold\"\"\"")]
    public void MatchesExactConfiguredTokensInBothOperandOrders(string expression)
    {
        var source = $"class C {{ bool M() => {expression}; }}";
        var result = Scanner("tier").Scan("display.cs", source);
        var finding = Assert.Single(result.Findings);
        Assert.Empty(result.Diagnostics);
        Assert.Equal(expression, finding.Evidence);
        Assert.Equal(expression, source.Substring(finding.SpanOffset, finding.SpanLength));
        Assert.Equal("display.cs", finding.FileName);
        Assert.Equal("NEEDS_POLICY_REVIEW", finding.ReviewPriority);
    }

    [Theory]
    [InlineData("tier == null")]
    [InlineData("tier == true")]
    [InlineData("tier == configured")]
    [InlineData("tier > 2")]
    [InlineData("frontier == 2")]
    [InlineData("tier.Contains(\"gold\")")]
    [InlineData("other.tierName == 2")]
    public void ExcludesNonliteralUnsupportedAndSubstringComparisons(string expression) =>
        Assert.Empty(Scanner("tier").Scan("synthetic.cs", $"class C {{ bool M() => {expression}; }}").Findings);

    [Fact]
    public void NoDefaultDomainAndCommentsAreNotRules()
    {
        const string source = "class C { bool M() => tier == 2; /* tier == 3 */ }";
        Assert.Empty(Scanner().Scan("synthetic.cs", source).Findings);
        Assert.Single(Scanner("tier").Scan("synthetic.cs", source).Findings);
    }

    [Fact]
    public void OriginalUnicodeCrLfOffsetsDigestAndIdsAreRepeatable()
    {
        const string source = "// synthetic λ\r\nclass C {\r\n  bool M() => tier != \"gold\";\r\n}";
        var scanner = Scanner("tier");
        var first = scanner.Scan("../label-only.cs", source);
        var second = scanner.Scan("../label-only.cs", source);
        Assert.Equal(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(source))), first.SourceDigest);
        Assert.NotEqual(first.SourceDigest, scanner.Scan("label", source.Replace("\r\n", "\n", StringComparison.Ordinal)).SourceDigest);
        Assert.Equal(first.AnalyzerVersion, second.AnalyzerVersion);
        var finding = Assert.Single(first.Findings);
        Assert.Equal(finding, Assert.Single(second.Findings));
        Assert.Equal(3, finding.Line);
        Assert.Equal(15, finding.Column);
        Assert.Equal(source.IndexOf("tier", StringComparison.Ordinal), finding.SpanOffset);
        Assert.Equal(64, finding.Id.Length);
    }

    [Fact]
    public void ConfigurationProvenanceIsStableAndChangesWithTerms()
    {
        const string source = "class C {}";
        Assert.Equal(Scanner("tier", "level").Scan("x", source).AnalyzerVersion, Scanner("LEVEL", "TIER").Scan("x", source).AnalyzerVersion);
        Assert.NotEqual(Scanner("tier").Scan("x", source).AnalyzerVersion, Scanner("level").Scan("x", source).AnalyzerVersion);
    }

    [Fact]
    public void MultilineEvidenceIncludesOriginalTriviaAndUsesStartCoordinates()
    {
        const string expression = "tier /* synthetic */\r\n    !=\r\n    3";
        var source = $"class C {{\r\n  bool M() => {expression};\r\n}}";
        var finding = Assert.Single(Scanner("tier").Scan("x", source).Findings);
        Assert.Equal(expression, finding.Evidence);
        Assert.Equal(2, finding.Line);
        Assert.Equal(15, finding.Column);
        Assert.Equal(expression.Length, finding.SpanLength);
    }

    [Fact]
    public void LineDirectivesCannotForgeOriginalSourceCoordinates()
    {
        const string source = "#line 9000 \"forged.cs\"\nclass C { bool M() => tier == 3; }";
        var finding = Assert.Single(Scanner("tier").Scan("synthetic.cs", source).Findings);
        Assert.Equal("synthetic.cs", finding.FileName);
        Assert.Equal(2, finding.Line);
        Assert.Equal(23, finding.Column);
        Assert.Equal(source.IndexOf("tier", StringComparison.Ordinal), finding.SpanOffset);
    }

    [Fact]
    public void InvalidSyntaxReturnsBoundedDiagnosticCodesWithoutSource()
    {
        var result = Scanner("tier").Scan("synthetic.cs", "class C { bool M() => tier == ; SECRET_SENTINEL");
        Assert.Empty(result.Findings);
        Assert.NotEmpty(result.Diagnostics);
        Assert.All(result.Diagnostics, diagnostic =>
        {
            Assert.StartsWith("CS", diagnostic.Code);
            Assert.True(diagnostic.Line > 0 && diagnostic.Column > 0);
        });
        Assert.True(result.Diagnostics.Count <= 100);
    }

    [Fact]
    public void PrecancelledScanAborts()
    {
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        Assert.ThrowsAny<OperationCanceledException>(() => Scanner("tier").Scan("x", "class C {}", cancellation.Token));
    }
}
