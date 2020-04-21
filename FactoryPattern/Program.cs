using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory loggerFactory = new LoggerFactory();

            Logger dbLogger = loggerFactory.GetLogger(LoggerType.Database);
            Logger consoleLogger = loggerFactory.GetLogger(LoggerType.Console);

            dbLogger.LogInfo("info");
            dbLogger.LogError("error");

            consoleLogger.LogInfo("info");
            consoleLogger.LogError("error");
        }
    }
}
