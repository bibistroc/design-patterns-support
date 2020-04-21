using System;

namespace FactoryPattern
{
    public class DatabaseLogger : Logger
    {
        private readonly LoggingContext loggingContext;

        public DatabaseLogger(LoggingContext loggingContext)
        {
            this.loggingContext = loggingContext;
        }

        public override void LogError(string message)
        {
            Console.WriteLine("Logging error into DB: {0}", message);
        }

        public override void LogInfo(string message)
        {
            Console.WriteLine("Logging info into DB: {0}", message);
        }
    }
}
