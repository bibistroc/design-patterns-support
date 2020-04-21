using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = Logger.Instance;

            logger.LogInfo("Hi");
            logger.LogError("Some error");

            // Test for same instance
            Logger log1 = Logger.Instance;
            Logger log2 = Logger.GetLogger();
            if (log1 == log2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
    }
}
