using System.Net;
using Factory.Api.Security;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace Factory.Tests;

public sealed class LocalHostPolicyTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(";")]
    [InlineData("http://0.0.0.0:5080")]
    [InlineData("http://[::]:5080")]
    [InlineData("http://localhost:5080")]
    [InlineData("http://example.invalid:5080")]
    [InlineData("unix:/tmp/synthetic.sock")]
    [InlineData("http://127.0.0.1:5080/path")]
    [InlineData("http://user@127.0.0.1:5080")]
    [InlineData("http://127.0.0.1:5080?query=synthetic")]
    [InlineData("http://127.0.0.1:5080#fragment")]
    public void RejectsUnsafeOrMissingBindings(string? addresses) => Assert.Throws<InvalidOperationException>(() => LocalHostPolicy.ValidateAddresses(addresses));

    [Theory]
    [InlineData("http://127.0.0.1:5080")]
    [InlineData("http://[::1]:5080")]
    [InlineData("http://127.0.0.1:5080;http://[::1]:5081")]
    public void AcceptsExplicitLoopbackIpBindings(string addresses) => LocalHostPolicy.ValidateAddresses(addresses);

    [Fact]
    public void RequiresLocalPeerAndHostAndLimitsNullPeerToTestSubstitution()
    {
        var context = new DefaultHttpContext();
        context.Request.Host = new HostString("127.0.0.1", 5080);
        context.Connection.RemoteIpAddress = IPAddress.Loopback;
        Assert.True(LocalHostPolicy.IsAllowed(context, false));
        context.Connection.RemoteIpAddress = IPAddress.Parse("192.0.2.1");
        Assert.False(LocalHostPolicy.IsAllowed(context, false));
        context.Connection.RemoteIpAddress = null;
        Assert.False(LocalHostPolicy.IsAllowed(context, false));
        Assert.True(LocalHostPolicy.IsAllowed(context, true));
        context.Request.Host = new HostString("example.invalid");
        Assert.False(LocalHostPolicy.IsAllowed(context, true));
    }

    [Theory]
    [InlineData("Origin")]
    [InlineData("Forwarded")]
    [InlineData("X-Forwarded-Host")]
    [InlineData("X-Forwarded-For")]
    [InlineData("X-Forwarded-Proto")]
    public void RejectsBrowserAndProxyHeadersWithoutTrustingValues(string header)
    {
        var context = new DefaultHttpContext();
        context.Request.Host = new HostString("127.0.0.1", 5080);
        context.Connection.RemoteIpAddress = IPAddress.Loopback;
        context.Request.Headers[header] = "127.0.0.1";
        Assert.False(LocalHostPolicy.IsAllowed(context, false));
    }
}
