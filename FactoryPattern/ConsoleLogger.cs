using System;

namespace FactoryPattern
{
    public class ConsoleLogger : Logger
    {
        private readonly LoggingContext loggingContext;

        public ConsoleLogger(LoggingContext loggingContext)
        {
            this.loggingContext = loggingContext;
        }

        public override void LogError(string message)
        {
            Console.WriteLine("Logging error into console: {0}", message);
        }

        public override void LogInfo(string message)
        {
            Console.WriteLine("Logging info into console: {0}", message);
        }
    }
}
