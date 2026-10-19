using System.Runtime.CompilerServices;
using Microsoft.Extensions.AI;

namespace Factory.Tests;

internal sealed class RecordingChatClient : IChatClient
{
    public List<(IReadOnlyList<ChatMessage> Messages, ChatOptions? Options)> Calls { get; } = [];
    public Func<int, CancellationToken, Task<string>> Reply { get; set; } = (index, _) => Task.FromResult(index == 0 ? "Synthetic analyst report" : "Synthetic advisory critique");

    public async Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default)
    {
        int index;
        lock (Calls)
        {
            index = Calls.Count;
            Calls.Add((messages.ToArray(), options));
        }
        var reply = await Reply(index, cancellationToken);
        return new ChatResponse(new ChatMessage(ChatRole.Assistant, reply));
    }

    public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var response = await GetResponseAsync(messages, options, cancellationToken);
        yield return new ChatResponseUpdate(ChatRole.Assistant, response.Text);
    }

    public object? GetService(Type serviceType, object? serviceKey = null) => serviceKey is null && serviceType.IsInstanceOfType(this) ? this : null;
    public void Dispose() { }
}
