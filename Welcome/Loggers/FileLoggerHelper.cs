using Microsoft.Extensions.Logging;
using System.IO;

namespace Welcome.Loggers
{
    public static class FileLoggerHelper
    {
        private static readonly string _logFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "login_log.txt");

        public static void LogSuccess(string username)
        {
            var logger = new FileLogger("LOGIN", _logFilePath);
            logger.Log(
                LogLevel.Information,
                new EventId(1),
                $"Потребител '{username}' се е логнал успешно.",
                null,
                (s, e) => s);
        }

        public static void LogFailure(string username, string errorMessage)
        {
            var logger = new FileLogger("LOGIN", _logFilePath);
            logger.Log(
                LogLevel.Warning,
                new EventId(2),
                $"Неуспешен опит за вход с потребител '{username}': {errorMessage}",
                null,
                (s, e) => s);
        }
    }
}