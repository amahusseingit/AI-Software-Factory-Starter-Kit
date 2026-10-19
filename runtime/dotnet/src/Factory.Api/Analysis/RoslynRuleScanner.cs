using System.Security.Cryptography;
using System.Text;
using Factory.Api.Configuration;
using Factory.Api.Contracts;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
namespace Factory.Api.Analysis;

public sealed class RoslynRuleScanner(IOptions<AnalysisOptions> options) : IRuleScanner
{
    public const string Version = "phase1-syntax-v1";
    public ScanResult Scan(string fileName, string source, CancellationToken cancellationToken = default)
    {
        var digest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(source)));
        var tree = CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.CSharp14, kind: SourceCodeKind.Regular), cancellationToken: cancellationToken);
        var diagnostics = tree.GetDiagnostics(cancellationToken).Where(d => d.Severity == DiagnosticSeverity.Error).Take(100).Select(d =>
        {
            var pos = d.Location.GetLineSpan().StartLinePosition;
            return new SyntaxIssue(d.Id, pos.Line + 1, pos.Character + 1);
        }).ToArray();
        var terms = options.Value.IdentifierTerms.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var configDigest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("\n", terms.Order(StringComparer.OrdinalIgnoreCase).Select(s => s.ToUpperInvariant())))));
        var version = $"{Version}:{configDigest}";
        if (diagnostics.Length > 0) return new(digest, version, [], diagnostics);
        var findings = new List<Finding>();
        foreach (var node in tree.GetRoot(cancellationToken).DescendantNodes().OfType<BinaryExpressionSyntax>())
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (!node.IsKind(SyntaxKind.EqualsExpression) && !node.IsKind(SyntaxKind.NotEqualsExpression)) continue;
            if (!(IsLiteral(node.Left) && IsConfigured(node.Right, terms)) && !(IsLiteral(node.Right) && IsConfigured(node.Left, terms))) continue;
            var span = node.Span;
            var position = tree.GetLineSpan(span, cancellationToken).StartLinePosition;
            const string rule = "HARDCODED_COMPARISON_V1";
            var id = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes($"{digest}:{rule}:{span.Start}:{span.Length}")));
            findings.Add(new(id, rule, fileName, position.Line + 1, position.Character + 1, span.Start, span.Length, "POSSIBLE_HARDCODED_RULE", source.Substring(span.Start, span.Length), "Review against approved policy; consider configured values."));
        }
        return new(digest, version, findings, diagnostics);
    }
    private static bool IsLiteral(ExpressionSyntax expression) => expression is LiteralExpressionSyntax literal && (literal.IsKind(SyntaxKind.StringLiteralExpression) || literal.IsKind(SyntaxKind.NumericLiteralExpression));
    private static bool IsConfigured(ExpressionSyntax expression, HashSet<string> terms) => expression switch
    {
        IdentifierNameSyntax identifier => terms.Contains(identifier.Identifier.ValueText),
        MemberAccessExpressionSyntax member => terms.Contains(member.Name.Identifier.ValueText),
        _ => false
    };
}
