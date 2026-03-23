using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
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

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine("— LOGGER —");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($" [{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("— LOGGER —");
            Console.ResetColor();

            _logMessages[eventId.Id] = message;
        }

        // Домашно 1: Принтира всички записани съобщения
        public void PrintAll()
        {
            Console.WriteLine("— ВСИЧКИ СЪОБЩЕНИЯ —");
            foreach (var entry in _logMessages)
            {
                Console.WriteLine($"[ID: {entry.Key}] {entry.Value}");
            }
            Console.WriteLine("— КРАЙ —");
        }

        // Домашно 2: Принтира съобщение по eventId
        public void PrintById(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out string? message))
            {
                Console.WriteLine($"[ID: {eventId}] {message}");
            }
            else
            {
                Console.WriteLine($"Няма съобщение с ID: {eventId}");
            }
        }

        // Домашно 3: Изтрива съобщение по eventId
        public void DeleteById(int eventId)
        {
            if (_logMessages.TryRemove(eventId, out _))
            {
                Console.WriteLine($"Съобщението с ID: {eventId} беше изтрито.");
            }
            else
            {
                Console.WriteLine($"Няма съобщение с ID: {eventId}");
            }
        }
    }
}