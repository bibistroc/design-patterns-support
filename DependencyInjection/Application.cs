namespace DependencyInjection
{
    public class Application
    {
        private readonly ILogger logger;

        public Application(ILogger logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            logger.LogInfo("started application");
        }
    }
}
