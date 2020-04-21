namespace FactoryPattern
{
    public abstract class Logger
    {
        public abstract void LogInfo(string message);

        public abstract void LogError(string message);
    }
}
