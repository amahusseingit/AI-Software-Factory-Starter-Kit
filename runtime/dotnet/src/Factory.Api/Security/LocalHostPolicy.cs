using System.Net;
namespace Factory.Api.Security;

public static class LocalHostPolicy
{
    public static void ValidateAddresses(string? addresses)
    {
        if (string.IsNullOrWhiteSpace(addresses) || addresses.Split(';', StringSplitOptions.RemoveEmptyEntries).Length == 0) throw new InvalidOperationException("Explicit loopback binding required.");
        foreach (var address in addresses.Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            if (!Uri.TryCreate(address, UriKind.Absolute, out var uri) || (uri.Scheme != "http" && uri.Scheme != "https") || !IsLoopback(uri.Host) || !string.IsNullOrEmpty(uri.UserInfo) || uri.AbsolutePath != "/" || !string.IsNullOrEmpty(uri.Query) || !string.IsNullOrEmpty(uri.Fragment)) throw new InvalidOperationException("Only explicit loopback IP bindings are supported.");
        }
    }
    public static bool IsLoopback(string host) => IPAddress.TryParse(host.Trim('[', ']'), out var address) && IPAddress.IsLoopback(address);
    public static bool IsAllowed(HttpContext context, bool testServer) =>
        !context.Request.Headers.ContainsKey("Origin") &&
        !context.Request.Headers.Keys.Any(k => k.Equals("Forwarded", StringComparison.OrdinalIgnoreCase) || k.StartsWith("X-Forwarded-", StringComparison.OrdinalIgnoreCase)) &&
        IsLoopback(context.Request.Host.Host) &&
        (context.Connection.RemoteIpAddress is { } peer ? IPAddress.IsLoopback(peer) : testServer);
}
