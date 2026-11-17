using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Factory.Api.Contracts;
using Xunit;

namespace Factory.Tests;

public sealed class HostingTests
{
    [Theory]
    [InlineData("http://0.0.0.0:5100")]
    [InlineData("http://[::]:5100")]
    [InlineData("http://localhost:5100")]
    [InlineData("http://*:5100")]
    [InlineData("http://example.invalid:5100")]
    [InlineData("http://unix:/tmp/factory-disallowed.sock")]
    public async Task RealHostRejectsUnsafeAddressConfiguration(string address)
    {
        using var process = StartHost(address);
        try
        {
            await process.WaitForExitAsync().WaitAsync(TimeSpan.FromSeconds(15));
            Assert.NotEqual(0, process.ExitCode);
        }
        finally { Kill(process); }
    }

    [Fact]
    public async Task EnabledProviderWithoutConfigurationFailsStartup()
    {
        using var process = StartHost("http://127.0.0.1:0", "--AI:Enabled=true");
        try
        {
            await process.WaitForExitAsync().WaitAsync(TimeSpan.FromSeconds(15));
            Assert.NotEqual(0, process.ExitCode);
        }
        finally { Kill(process); }
    }

    [Fact]
    public async Task RealLoopbackHostAcceptsLivenessAndRejectsBrowserOrForgedHost()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        using var process = StartHost($"http://127.0.0.1:{port}");
        using var handler = new HttpClientHandler { UseProxy = false };
        using var client = new HttpClient(handler) { BaseAddress = new Uri($"http://127.0.0.1:{port}"), Timeout = TimeSpan.FromSeconds(2) };
        try
        {
            var ready = false;
            for (var attempt = 0; attempt < 100; attempt++)
            {
                Assert.False(process.HasExited, "Synthetic loopback host exited before liveness.");
                try
                {
                    using var health = await client.GetAsync("/health");
                    ready = health.IsSuccessStatusCode;
                    if (ready) break;
                }
                catch (HttpRequestException) { }
                await Task.Delay(50);
            }
            Assert.True(ready, "Synthetic loopback host did not become live.");
            using var browserRequest = new HttpRequestMessage(HttpMethod.Get, "/health");
            browserRequest.Headers.Add("Origin", "http://127.0.0.1");
            using var browser = await client.SendAsync(browserRequest);
            Assert.False(browser.IsSuccessStatusCode);
            using var forgedRequest = new HttpRequestMessage(HttpMethod.Get, "/health");
            forgedRequest.Headers.Host = "example.invalid";
            using var forged = await client.SendAsync(forgedRequest);
            Assert.False(forged.IsSuccessStatusCode);
        }
        finally { Kill(process); }
    }

    private static Process StartHost(string address, params string[] arguments)
    {
        var dotnet = Environment.GetEnvironmentVariable("DOTNET_HOST_PATH") ?? Path.GetFullPath(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "../../../dotnet"));
        var tests = typeof(HostingTests).Assembly.Location;
        var info = new ProcessStartInfo(dotnet) { UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true, WorkingDirectory = AppContext.BaseDirectory };
        foreach (var argument in new[] { "exec", "--runtimeconfig", Path.ChangeExtension(tests, ".runtimeconfig.json"), "--depsfile", Path.ChangeExtension(tests, ".deps.json"), typeof(AnalysisRequest).Assembly.Location, "--urls", address, "--AI:Enabled=false" }.Concat(arguments)) info.ArgumentList.Add(argument);
        info.Environment["ASPNETCORE_ENVIRONMENT"] = "Production";
        info.Environment["DOTNET_ENVIRONMENT"] = "Production";
        var process = Process.Start(info) ?? throw new InvalidOperationException("Could not start synthetic loopback host.");
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        return process;
    }

    private static void Kill(Process process)
    {
        if (!process.HasExited) { process.Kill(entireProcessTree: true); process.WaitForExit(5000); }
    }
}
