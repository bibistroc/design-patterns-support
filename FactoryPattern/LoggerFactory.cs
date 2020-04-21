using System;

namespace FactoryPattern
{
    public class LoggerFactory
    {
        private readonly LoggingContext loggingContext;

        public LoggerFactory()
        {
            loggingContext = new LoggingContext();
        }

        public Logger GetLogger(LoggerType type)
        {
            switch (type)
            {
                case LoggerType.Database:
                    return new DatabaseLogger(loggingContext);
                case LoggerType.Console:
                    return new ConsoleLogger(loggingContext);
                default:
                    throw new Exception("Invalid logger");
            }
        }
    }
}
