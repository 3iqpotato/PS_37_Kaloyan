using System.IO;
using Microsoft.Extensions.Logging;

namespace Welcome.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly string _name;

        public FileLogger(string name, string filePath)
        {
            _name = name;
            _filePath = filePath;
        }

        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            var logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{logLevel}] [{_name}] {message}";

            File.AppendAllText(_filePath, logLine + Environment.NewLine);
        }
    }
}