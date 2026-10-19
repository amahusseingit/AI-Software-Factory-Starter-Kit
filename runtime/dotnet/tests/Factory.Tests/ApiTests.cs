using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Factory.Api.Analysis;
using Factory.Api.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.AI;
using Xunit;

namespace Factory.Tests;

public sealed class ApiTests
{
    internal sealed class ApiFactory : WebApplicationFactory<Program>
    {
        public Action<IServiceCollection>? ConfigureServices { get; init; }
        public bool EnableAi { get; init; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((_, config) => config.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["AI:Enabled"] = EnableAi.ToString(),
                ["AI:Endpoint"] = "https://provider.example.invalid/v1/",
                ["AI:AllowedEndpoints:0"] = "https://provider.example.invalid/v1/",
                ["AI:Model"] = "synthetic-model",
                ["AI:ApiKey"] = "synthetic-test-credential",
                ["Analysis:IdentifierTerms:0"] = "tier"
            }));
            if (ConfigureServices is not null) builder.ConfigureServices(ConfigureServices);
        }
    }

    [Fact]
    public async Task HealthIsLivenessAndAnalysisCannotApprove()
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        Assert.Equal(HttpStatusCode.OK, (await client.GetAsync("/health")).StatusCode);
        var first = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "../display-only.cs", sourceCode = "class C { bool M() => tier == 3; }" });
        first.EnsureSuccessStatusCode();
        var json = await first.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("BLOCKED", json.GetProperty("decision").GetString());
        Assert.Equal("NOT_RUN", json.GetProperty("agentStatus").GetString());
        Assert.Single(json.GetProperty("findings").EnumerateArray());
        var second = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "other.cs", sourceCode = "class Other {}", consentToSendCode = true });
        var secondJson = await second.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("DISABLED", secondJson.GetProperty("agentStatus").GetString());
        Assert.Equal("BLOCKED", secondJson.GetProperty("decision").GetString());
        Assert.NotEqual(json.GetProperty("runId").GetString(), secondJson.GetProperty("runId").GetString());
        Assert.Empty(secondJson.GetProperty("findings").EnumerateArray());
    }

    [Theory]
    [InlineData("{}")]
    [InlineData("{")]
    [InlineData("{\"fileName\":\"x\",\"sourceCode\":\" \"}")]
    [InlineData("{\"fileName\":\"x\\n\",\"sourceCode\":\"class C {}\"}")]
    [InlineData("{\"fileName\":1,\"sourceCode\":\"class C {}\"}")]
    public async Task InvalidRequestsAreProblemDetails(string body)
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        var response = await client.PostAsync("/api/factory/analyze", new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
    }

    [Fact]
    public async Task MediaBodyCharacterAndSyntaxBoundariesAreEnforced()
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        Assert.Equal(HttpStatusCode.UnsupportedMediaType, (await client.PostAsync("/api/factory/analyze", new StringContent("{}"))).StatusCode);
        Assert.Equal(HttpStatusCode.RequestEntityTooLarge, (await client.PostAsync("/api/factory/analyze", new StringContent(new string(' ', 65537), Encoding.UTF8, "application/json"))).StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, (await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = new string('x', 261), sourceCode = "class C {}" })).StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, (await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "x", sourceCode = new string('x', 20001) })).StatusCode);
        var invalid = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "x", sourceCode = "class C {", consentToSendCode = true });
        Assert.Equal(HttpStatusCode.UnprocessableEntity, invalid.StatusCode);
    }

    [Theory]
    [InlineData("application/problem+json")]
    [InlineData("application/vnd.synthetic+json")]
    public async Task OnlyApplicationJsonMediaTypeIsAccepted(string mediaType)
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        using var response = await client.PostAsync("/api/factory/analyze", new StringContent("{}", Encoding.UTF8, mediaType));
        Assert.Equal(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
    }

    [Theory]
    [InlineData("POST", "/api/factory/analyze")]
    [InlineData("GET", "/health")]
    [InlineData("HEAD", "/health")]
    public async Task UnknownLengthBodiesAreBoundedForEveryEndpoint(string method, string path)
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        using var request = new HttpRequestMessage(new HttpMethod(method), path) { Content = new UnknownLengthContent(new byte[65537]) };
        using var response = await client.SendAsync(request);
        Assert.Equal(HttpStatusCode.RequestEntityTooLarge, response.StatusCode);
    }

    [Fact]
    public async Task ExactCharacterLimitsAndConcurrentCallerIsolationHold()
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        var source = "class C {} //".PadRight(20000, 'x');
        var boundary = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = new string('x', 260), sourceCode = source });
        Assert.Equal(HttpStatusCode.OK, boundary.StatusCode);
        var responses = await Task.WhenAll(Enumerable.Range(0, 4).Select(index => client.PostAsJsonAsync("/api/factory/analyze", new { fileName = $"caller-{index}.cs", sourceCode = $"class C {{ bool M() => tier == {index}; }}" })));
        var ids = new HashSet<string>();
        for (var index = 0; index < responses.Length; index++)
        {
            using var response = responses[index];
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            Assert.True(ids.Add(json.GetProperty("runId").GetString()!));
            var finding = Assert.Single(json.GetProperty("findings").EnumerateArray());
            Assert.Equal($"caller-{index}.cs", finding.GetProperty("fileName").GetString());
            Assert.Equal($"tier == {index}", finding.GetProperty("evidence").GetString());
            Assert.Equal("BLOCKED", json.GetProperty("decision").GetString());
        }
    }

    [Theory]
    [InlineData("Origin", "http://127.0.0.1")]
    [InlineData("Host", "example.invalid")]
    [InlineData("X-Forwarded-Host", "127.0.0.1")]
    public async Task BrowserAndForwardedHostRequestsAreRejected(string header, string value)
    {
        await using var factory = new ApiFactory();
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        using var request = new HttpRequestMessage(HttpMethod.Get, "/health");
        request.Headers.TryAddWithoutValidation(header, value);
        var response = await client.SendAsync(request);
        Assert.False(response.IsSuccessStatusCode);
        Assert.False(response.Headers.Contains("Access-Control-Allow-Origin"));
    }

    [Fact]
    public async Task FourInFlightRequestsRejectFifthWithoutQueueAndReleasePermits()
    {
        using var scanner = new BlockingScanner();
        await using var factory = new ApiFactory { ConfigureServices = services => { services.RemoveAll<IRuleScanner>(); services.AddSingleton<IRuleScanner>(scanner); } };
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        var requests = Enumerable.Range(0, 4).Select(index => Task.Run(() => client.PostAsJsonAsync("/api/factory/analyze", new { fileName = $"{index}.cs", sourceCode = "class C {}" }))).ToArray();
        try
        {
            await scanner.AllEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
            foreach (var path in new[] { "/api/factory/analyze", "/api/factory/analyze/" })
            {
                using var rejected = await client.PostAsJsonAsync(path, new { fileName = "fifth.cs", sourceCode = "class C {}" });
                Assert.Equal(HttpStatusCode.TooManyRequests, rejected.StatusCode);
            }
        }
        finally
        {
            scanner.Release.Set();
        }
        var responses = await Task.WhenAll(requests).WaitAsync(TimeSpan.FromSeconds(10));
        foreach (var response in responses)
        {
            using (response) Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        using var afterRelease = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "after.cs", sourceCode = "class C {}" });
        Assert.Equal(HttpStatusCode.OK, afterRelease.StatusCode);
    }

    private sealed class BlockingScanner : IRuleScanner, IDisposable
    {
        private int entered;
        public TaskCompletionSource AllEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public ManualResetEventSlim Release { get; } = new();
        public ScanResult Scan(string fileName, string source, CancellationToken cancellationToken = default)
        {
            if (Interlocked.Increment(ref entered) == 4) AllEntered.TrySetResult();
            if (!Release.Wait(TimeSpan.FromSeconds(15), cancellationToken)) throw new TimeoutException("Synthetic scanner barrier expired.");
            return new("synthetic-digest", "synthetic-version", [], []);
        }
        public void Dispose() => Release.Dispose();
    }

    [Fact]
    public async Task UnexpectedFailuresAreGenericAndLogsNeverContainSensitivePayloads()
    {
        using var logs = new LogCapture();
        await using var factory = new ApiFactory
        {
            ConfigureServices = services =>
            {
                services.RemoveAll<IRuleScanner>();
                services.AddSingleton<IRuleScanner>(new ThrowingScanner());
                services.AddLogging(logging => logging.AddProvider(logs));
            }
        };
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        for (var attempt = 0; attempt < 5; attempt++)
        {
            using var response = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "FILE_SENTINEL.cs", sourceCode = "// SOURCE_SENTINEL\nclass C {}" });
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal("application/problem+json", response.Content.Headers.ContentType?.MediaType);
            var body = await response.Content.ReadAsStringAsync();
            Assert.DoesNotContain("SOURCE_SENTINEL", body);
            Assert.DoesNotContain("PROVIDER_CREDENTIAL_SENTINEL", body);
        }
        Assert.DoesNotContain("FILE_SENTINEL", logs.Text);
        Assert.DoesNotContain("SOURCE_SENTINEL", logs.Text);
        Assert.DoesNotContain("PROVIDER_CREDENTIAL_SENTINEL", logs.Text);
    }

    private sealed class ThrowingScanner : IRuleScanner
    {
        public ScanResult Scan(string fileName, string source, CancellationToken cancellationToken = default) => throw new InvalidOperationException("PROVIDER_CREDENTIAL_SENTINEL");
    }

    private sealed class UnknownLengthContent(byte[] bytes) : HttpContent
    {
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context) => stream.WriteAsync(bytes.AsMemory()).AsTask();
        protected override bool TryComputeLength(out long length) { length = 0; return false; }
    }

    [Fact]
    public async Task EnabledApiStillRequiresConsentAndValidSyntaxAndRetainsFindingsOnProviderFailure()
    {
        using var chat = new RecordingChatClient { Reply = (_, _) => throw new HttpRequestException("PROVIDER_CREDENTIAL_SENTINEL") };
        await using var factory = new ApiFactory
        {
            EnableAi = true,
            ConfigureServices = services => { services.RemoveAll<IChatClient>(); services.AddSingleton<IChatClient>(chat); }
        };
        using var client = factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = new Uri("http://127.0.0.1") });
        using var noConsent = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "x.cs", sourceCode = "class C {}" });
        Assert.Equal(HttpStatusCode.OK, noConsent.StatusCode);
        Assert.Empty(chat.Calls);
        using var badSyntax = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "x.cs", sourceCode = "class C {", consentToSendCode = true });
        Assert.Equal(HttpStatusCode.UnprocessableEntity, badSyntax.StatusCode);
        Assert.Empty(chat.Calls);
        using var failed = await client.PostAsJsonAsync("/api/factory/analyze", new { fileName = "x.cs", sourceCode = "class C { bool M() => tier == 2; }", consentToSendCode = true });
        failed.EnsureSuccessStatusCode();
        var json = await failed.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("FAILED", json.GetProperty("agentStatus").GetString());
        Assert.Equal("BLOCKED", json.GetProperty("decision").GetString());
        Assert.Single(json.GetProperty("findings").EnumerateArray());
        Assert.Single(chat.Calls);
        Assert.DoesNotContain("PROVIDER_CREDENTIAL_SENTINEL", await failed.Content.ReadAsStringAsync());
    }
}
