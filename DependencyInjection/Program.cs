using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Application application = serviceProvider.GetRequiredService<Application>();
                application.Run();
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            ApplicationConfig applicationConfig = configuration.GetSection("Application").Get<ApplicationConfig>();

            services.AddSingleton<ApplicationConfig>(_ => applicationConfig); // we only want one instance of ApplicationConfig

            services.AddTransient<ILogger, FileLogger>(); // this class doesn't have a state and we can get new instance every time

            services.AddScoped<Application>(); // we want one Application class for each application run (per container)
        }
    }
}
