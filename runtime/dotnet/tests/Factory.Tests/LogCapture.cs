using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Factory.Tests;

internal sealed class LogCapture : ILoggerProvider
{
    private readonly ConcurrentQueue<string> messages = new();
    public string Text => string.Join("\n", messages);
    public ILogger CreateLogger(string categoryName) => new CaptureLogger(messages);
    public void Dispose() { }

    private sealed class CaptureLogger(ConcurrentQueue<string> messages) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) => messages.Enqueue(formatter(state, exception) + (exception is null ? "" : "\n" + exception));
    }
}
