using Autofac;
using Microsoft.Extensions.Configuration;

namespace DependencyInjection_Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer servicesContainer = ConfigureServices();

            using (var applicationScope = servicesContainer.BeginLifetimeScope())
            {
                var application = applicationScope.Resolve<Application>();
                application.Run();
            }
        }

        private static IContainer ConfigureServices()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            ApplicationConfig applicationConfig = configuration.GetSection("Application").Get<ApplicationConfig>();

            var builder = new ContainerBuilder(); // The builder where the components/services gets registerd

            // register components/services
            
            builder.RegisterType<FileLogger>().As<ILogger>().InstancePerDependency(); // transient

            builder.RegisterInstance(applicationConfig).As<ApplicationConfig>().SingleInstance(); // singleton

            builder.RegisterType<Application>().AsSelf().InstancePerLifetimeScope(); // scoped

            // return the container which has all the registered components/services
            return builder.Build();
        }
    }
}
