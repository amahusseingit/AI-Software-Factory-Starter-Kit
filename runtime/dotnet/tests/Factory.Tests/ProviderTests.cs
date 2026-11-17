using System.Net;
using System.Text;
using Factory.Api.Configuration;
using Microsoft.Extensions.AI;
using Xunit;

namespace Factory.Tests;

public sealed class ProviderTests
{
    private static AIOptions Options(string? endpoint = "https://provider.example.invalid/v1/") => new()
    {
        Enabled = true,
        Endpoint = endpoint,
        AllowedEndpoints = ["https://provider.example.invalid/v1/"],
        Model = "synthetic-model",
        ApiKey = "SYNTHETIC_CREDENTIAL_SENTINEL"
    };

    [Theory]
    [InlineData(null)]
    [InlineData("http://provider.example.invalid/v1/")]
    [InlineData("https://127.0.0.1/v1/")]
    [InlineData("https://[::1]/v1/")]
    [InlineData("https://user:password@provider.example.invalid/v1/")]
    [InlineData("https://provider.example.invalid/v1/?key=synthetic")]
    [InlineData("https://provider.example.invalid/v1/#fragment")]
    [InlineData("https://other.example.invalid/v1/")]
    [InlineData("https://provider.example.invalid/different/")]
    public void RejectsUnapprovedOrUnsafeEndpoints(string? endpoint) => Assert.Throws<InvalidOperationException>(() => ProviderRegistration.Validate(Options(endpoint)));

    [Fact]
    public void RequiresExplicitAllowlistModelAndCredentialWithoutFallback()
    {
        var options = Options();
        options.AllowedEndpoints = [];
        Assert.Throws<InvalidOperationException>(() => ProviderRegistration.Validate(options));
        options = Options(); options.Model = " ";
        Assert.Throws<InvalidOperationException>(() => ProviderRegistration.Validate(options));
        options = Options(); options.ApiKey = null;
        Assert.Throws<InvalidOperationException>(() => ProviderRegistration.Validate(options));
        ProviderRegistration.Validate(new AIOptions());
        ProviderRegistration.Validate(Options());
    }

    [Fact]
    public async Task MockTransportReceivesOnlyApprovedDestinationAndBoundCredential()
    {
        var handler = new StubHandler((request, _) =>
        {
            Assert.Equal("https://provider.example.invalid/v1/chat/completions", request.RequestUri?.AbsoluteUri);
            Assert.Equal("Bearer", request.Headers.Authorization?.Scheme);
            Assert.Equal("SYNTHETIC_CREDENTIAL_SENTINEL", request.Headers.Authorization?.Parameter);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("""
                {"id":"synthetic","object":"chat.completion","created":0,"model":"synthetic-model","choices":[{"index":0,"message":{"role":"assistant","content":"synthetic response"},"finish_reason":"stop"}],"usage":{"prompt_tokens":1,"completion_tokens":1,"total_tokens":2}}
                """, Encoding.UTF8, "application/json") });
        });
        using (var client = ProviderRegistration.Create(Options(), handler))
        {
            var response = await client.GetResponseAsync([new ChatMessage(ChatRole.User, "synthetic input")]);
            Assert.Equal("synthetic response", response.Text);
            Assert.Equal(1, handler.Calls);
        }
        Assert.True(handler.Disposed);
    }

    [Theory]
    [InlineData(302)]
    [InlineData(307)]
    [InlineData(429)]
    [InlineData(503)]
    public async Task RedirectsAndTransientFailuresCauseNoSecondTransportCall(int status)
    {
        using var handler = new StubHandler((_, _) =>
        {
            var response = new HttpResponseMessage((HttpStatusCode)status) { Content = new StringContent("{}", Encoding.UTF8, "application/json") };
            response.Headers.Location = new Uri("https://unapproved.example.invalid/steal");
            return Task.FromResult(response);
        });
        using var client = ProviderRegistration.Create(Options(), handler);
        await Assert.ThrowsAnyAsync<Exception>(() => client.GetResponseAsync([new ChatMessage(ChatRole.User, "synthetic input")]));
        Assert.Equal(1, handler.Calls);
    }

    [Fact]
    public async Task TransportCancellationPropagatesWithoutRetry()
    {
        var entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        using var handler = new StubHandler(async (_, token) => { entered.TrySetResult(); await Task.Delay(Timeout.Infinite, token); return new HttpResponseMessage(HttpStatusCode.OK); });
        using var client = ProviderRegistration.Create(Options(), handler);
        using var cancellation = new CancellationTokenSource();
        var request = client.GetResponseAsync([new ChatMessage(ChatRole.User, "synthetic input")], cancellationToken: cancellation.Token);
        await entered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        cancellation.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(async () => await request);
        Assert.Equal(1, handler.Calls);
    }

    private sealed class StubHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        public int Calls { get; private set; }
        public bool Disposed { get; private set; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) { Calls++; return send(request, cancellationToken); }
        protected override void Dispose(bool disposing) { Disposed = true; base.Dispose(disposing); }
    }
}
