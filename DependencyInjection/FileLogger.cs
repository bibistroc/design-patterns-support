using System;

namespace DependencyInjection
{
    public class FileLogger : ILogger
    {
        private readonly ApplicationConfig configuration;

        public FileLogger(ApplicationConfig configuration)
        {
            this.configuration = configuration;
        }

        public void LogError(string message)
        {
            Console.WriteLine($"Logging error into file {configuration.LoggingDirectory}: {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Logging info into file {configuration.LoggingDirectory}: {message}");
        }
    }
}
