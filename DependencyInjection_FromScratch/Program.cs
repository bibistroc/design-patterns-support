using System;

namespace DependencyInjection_FromScratch
{

    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<ISingletonDemo, SingletonDemo>();

            services.AddSingleton<SingletonDemoWithConstructor>();

            services.AddTransient<TransientDemo>();

            SingletonDemoWithConstructor singleton1 = services.GetService<SingletonDemoWithConstructor>();

            SingletonDemoWithConstructor singleton2 = services.GetService<SingletonDemoWithConstructor>();

            if (singleton1.GetHashCode() == singleton2.GetHashCode())
            {
                Console.WriteLine("[expected] Same instance");
            } 
            else
            {
                Console.WriteLine("[unexpected] Other instance");
            }

            TransientDemo transient1 = services.GetService<TransientDemo>();

            TransientDemo transient2 = services.GetService<TransientDemo>();

            if (transient1.GetHashCode() == transient2.GetHashCode())
            {
                Console.WriteLine("[unexpected] Same instance");
            }
            else
            {
                Console.WriteLine("[expected] Other instance");
            }

            SingletonDemo specificObject = services.GetService<ISingletonDemo, SingletonDemo>();

            if (specificObject != null)
            {
                Console.WriteLine("[expected] The object is not null");
            }
            else
            {
                Console.WriteLine("[unexpected] The object is null");
            }
        }
    }
}
