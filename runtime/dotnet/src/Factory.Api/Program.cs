using System.Text.Json;
using Factory.Api.Agents;
using Factory.Api.Analysis;
using Factory.Api.Configuration;
using Factory.Api.Contracts;
using Factory.Api.Security;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
// No environment-name bypass: only the in-memory server type is a test substitution.
var urls = builder.Configuration["urls"] ?? "http://127.0.0.1:5080";
LocalHostPolicy.ValidateAddresses(urls);
if (builder.Configuration.GetSection("Kestrel:Endpoints").GetChildren().Any() ||
    !string.IsNullOrEmpty(builder.Configuration["HTTP_PORTS"]) || !string.IsNullOrEmpty(builder.Configuration["HTTPS_PORTS"]))
    throw new InvalidOperationException("Alternative endpoint configuration is unsupported.");
builder.WebHost.UseUrls(urls);
builder.WebHost.ConfigureKestrel(server =>
{
    server.Limits.MaxRequestBodySize = 65536;
    server.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(10);
    server.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(30);
    server.Limits.MinRequestBodyDataRate = new MinDataRate(240, TimeSpan.FromSeconds(5));
});
builder.Services.Configure<AnalysisOptions>(builder.Configuration.GetSection("Analysis"));
builder.Services.Configure<AIOptions>(builder.Configuration.GetSection("AI"));
var ai = builder.Configuration.GetSection("AI").Get<AIOptions>() ?? new();
ProviderRegistration.Validate(ai);
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSingleton<IChatClient>(services => ProviderRegistration.Create(services.GetRequiredService<IOptions<AIOptions>>().Value));
builder.Services.AddSingleton<IRuleScanner, RoslynRuleScanner>();
builder.Services.AddSingleton<IAgentReviewService, FactoryAgentService>();
builder.Services.AddSingleton<IAnalysisService, AnalysisService>();
builder.Services.AddProblemDetails();
builder.Services.AddSingleton(new SemaphoreSlim(4, 4));
// Do not emit provider/model/source payloads or framework exception bodies.
builder.Logging.AddFilter("Microsoft.Extensions.AI", LogLevel.None);
builder.Logging.AddFilter("Microsoft.Agents.AI", LogLevel.None);
builder.Logging.AddFilter("Microsoft.AspNetCore.Diagnostics", LogLevel.None);
var app = builder.Build();
app.Use(async (context, next) =>
{
    var permits = context.RequestServices.GetRequiredService<SemaphoreSlim>();
    var acquired = false;
    try
    {
        if (context.Request.Path.StartsWithSegments("/api/factory/analyze", StringComparison.OrdinalIgnoreCase))
        {
            acquired = await permits.WaitAsync(0, context.RequestAborted);
            if (!acquired)
            {
                await Results.Problem(statusCode: 429, title: "Analysis capacity exhausted.").ExecuteAsync(context);
                return;
            }
        }
        var server = context.RequestServices.GetRequiredService<Microsoft.AspNetCore.Hosting.Server.IServer>();
        var testServer = server.GetType().FullName == "Microsoft.AspNetCore.TestHost.TestServer";
        if (!LocalHostPolicy.IsAllowed(context, testServer))
        {
            await Results.Problem(statusCode: 400, title: "Local request policy rejected.").ExecuteAsync(context);
            return;
        }
        if (context.Request.ContentLength > 65536)
        {
            await Results.Problem(statusCode: 413, title: "Request body too large.").ExecuteAsync(context);
            return;
        }
        // Bound chunked bodies too, before endpoint JSON deserialization.
        if (context.Request.Body.CanRead)
        {
            using var body = new MemoryStream();
            var buffer = new byte[8192];
            int read;
            while ((read = await context.Request.Body.ReadAsync(buffer, context.RequestAborted)) > 0)
            {
                if (body.Length + read > 65536)
                {
                    await Results.Problem(statusCode: 413, title: "Request body too large.").ExecuteAsync(context);
                    return;
                }
                await body.WriteAsync(buffer.AsMemory(0, read), context.RequestAborted);
            }
            body.Position = 0;
            context.Request.Body = body;
            await next(context);
            return;
        }
        await next(context);
    }
    catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested) { context.Abort(); }
    catch (Microsoft.AspNetCore.Http.BadHttpRequestException exception)
    {
        await Results.Problem(statusCode: exception.StatusCode, title: "Invalid request.").ExecuteAsync(context);
    }
    catch (Exception)
    {
        if (context.Response.HasStarted) context.Abort();
        else await Results.Problem(statusCode: 500, title: "Request failed.", extensions: new Dictionary<string, object?> { ["correlationId"] = context.TraceIdentifier }).ExecuteAsync(context);
    }
    finally { if (acquired) permits.Release(); }
});
app.MapGet("/health", () => Results.Ok(new { status = "alive" }));
app.MapPost("/api/factory/analyze", async (HttpContext context, IAnalysisService service) =>
{
    if (!System.Net.Http.Headers.MediaTypeHeaderValue.TryParse(context.Request.ContentType, out var mediaType) || !string.Equals(mediaType.MediaType, "application/json", StringComparison.OrdinalIgnoreCase)) return Results.Problem(statusCode: 415, title: "application/json required.");
    {
        AnalysisRequest? request;
        try { request = await context.Request.ReadFromJsonAsync<AnalysisRequest>(context.RequestAborted); }
        catch (JsonException) { return Results.Problem(statusCode: 400, title: "Invalid JSON."); }
        if (request is null || string.IsNullOrWhiteSpace(request.FileName) || request.FileName.Length > 260 || request.FileName.Any(char.IsControl) || string.IsNullOrWhiteSpace(request.SourceCode) || request.SourceCode.Length > 20000)
            return Results.Problem(statusCode: 400, title: "Invalid analysis fields.");
        var response = await service.AnalyzeAsync(request, context.RequestAborted);
        return response.Diagnostics.Count > 0 ? Results.Json(response, statusCode: 422) : Results.Ok(response);
    }
});
app.Run();
public partial class Program { }
