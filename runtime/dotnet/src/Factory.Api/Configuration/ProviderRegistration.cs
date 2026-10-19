using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.AI;
using OpenAI;
namespace Factory.Api.Configuration;

public static class ProviderRegistration
{
    public static void Validate(AIOptions options)
    {
        if (!options.Enabled) return;
        if (string.IsNullOrWhiteSpace(options.Model) || string.IsNullOrWhiteSpace(options.ApiKey)) throw new InvalidOperationException("Enabled AI requires endpoint-bound credentials and model.");
        if (!Uri.TryCreate(options.Endpoint, UriKind.Absolute, out var uri) || uri.Scheme != "https" || !string.IsNullOrEmpty(uri.UserInfo) || !string.IsNullOrEmpty(uri.Query) || !string.IsNullOrEmpty(uri.Fragment) || uri.IsLoopback || !options.AllowedEndpoints.Any(value => Uri.TryCreate(value, UriKind.Absolute, out var allowed) && allowed.AbsoluteUri == uri.AbsoluteUri)) throw new InvalidOperationException("An approved explicit HTTPS provider endpoint is required.");
    }
    public static IChatClient Create(AIOptions options, HttpMessageHandler? handler = null)
    {
        Validate(options);
        if (!options.Enabled) return new DisabledChatClient();
        handler ??= new SocketsHttpHandler { AllowAutoRedirect = false, ConnectTimeout = TimeSpan.FromSeconds(10) };
        var http = new HttpClient(new EndpointBoundHandler(new Uri(options.Endpoint!), handler), true) { Timeout = Timeout.InfiniteTimeSpan };
        return new OwnedChatClient(new OpenAIClient(new ApiKeyCredential(options.ApiKey!), new OpenAIClientOptions
        {
            ClientLoggingOptions = new ClientLoggingOptions { EnableLogging = false, EnableMessageLogging = false, EnableMessageContentLogging = false },
            EnableDistributedTracing = false,
            Endpoint = new Uri(options.Endpoint!),
            Transport = new HttpClientPipelineTransport(http),
            RetryPolicy = new ClientRetryPolicy(0)
        }).GetChatClient(options.Model!).AsIChatClient(), http);
    }
    private sealed class EndpointBoundHandler(Uri endpoint, HttpMessageHandler inner) : DelegatingHandler(inner)
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var expected = new Uri(endpoint.AbsoluteUri.TrimEnd('/') + "/chat/completions");
            if (request.RequestUri != expected) throw new InvalidOperationException("Provider destination rejected.");
            return base.SendAsync(request, cancellationToken);
        }
    }
    private sealed class OwnedChatClient(IChatClient inner, HttpClient http) : DelegatingChatClient(inner)
    {
        protected override void Dispose(bool disposing) { base.Dispose(disposing); if (disposing) http.Dispose(); }
    }
    private sealed class DisabledChatClient : IChatClient
    {
        public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) => throw new InvalidOperationException("AI disabled.");
        public IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default) => throw new InvalidOperationException("AI disabled.");
        public object? GetService(Type serviceType, object? serviceKey = null) => null;
        public void Dispose() { }
    }
}
