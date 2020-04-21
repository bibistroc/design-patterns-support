using System;

namespace SingletonPattern
{

    public class Logger
    {
        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        private Logger()
        {
        }

        public static Logger GetLogger()
        {
            return Instance;
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }

        public void LogError(string message)
        {
            Console.Error.WriteLine(message);
        }
    }
}
