using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjection_FromScratch
{
    public class ServiceCollection
    {
        private enum ServiceType
        {
            None = 0,
            Singleton,
            Transient,
            Scoped
        }
        private class Service
        {
            public ServiceType Type { get; set; }

            public Type ServiceType { get; set; }

            public Type ImplementationType { get; set; }

            public object Instance { get; set; }
        }

        private readonly Dictionary<string, Service> services;

        public ServiceCollection()
        {
            services = new Dictionary<string, Service>();
        }

        #region AddServicesMethods
        public ServiceCollection AddSingleton<TImplementation>()
            where TImplementation : class
        {
            return AddService<TImplementation, TImplementation>(ServiceType.Singleton);
        }

        public ServiceCollection AddSingleton<TService, TImplementation>()
            where TImplementation : class, TService
        {
            return AddService<TService, TImplementation>(ServiceType.Singleton);
        }

        public ServiceCollection AddSingleton<TService, TImplementation>(TImplementation instance)
            where TImplementation : class, TService
        {
            return AddService<TService, TImplementation>(ServiceType.Singleton, instance);
        }

        public ServiceCollection AddTransient<TImplementation>()
            where TImplementation : class
        {
            return AddService<TImplementation, TImplementation>(ServiceType.Transient);
        }

        public ServiceCollection AddTransient<TService, TImplementation>()
            where TImplementation : class, TService
        {
            return AddService<TService, TImplementation>(ServiceType.Transient);
        }

        public ServiceCollection AddTransient<TService, TImplementation>(TImplementation instance)
            where TImplementation : class, TService
        {
            return AddService<TService, TImplementation>(ServiceType.Transient, instance);
        }
        #endregion AddServicesMethods

        public TService GetService<TService>()
        {
            Type serviceType = typeof(TService);
            return (TService)GetService(serviceType);
        }

        public TImplementation GetService<TService, TImplementation>()
        {
            Type serviceType = typeof(TService);
            return (TImplementation)GetService(serviceType);
        }

        private object GetService(Type serviceType)
        {
            if (services.TryGetValue(serviceType.FullName, out Service service))
            {
                return GetService(service);
            }
            else
            {
                return null;
            }
        }

        private object GetService(Service service)
        {
            switch (service.Type)
            {
                case ServiceType.Singleton:
                case ServiceType.Scoped:
                    if (service.Instance == null)
                    {
                        service.Instance = BuildService(service.ImplementationType);
                    }
                    break;
                case ServiceType.Transient:
                    service.Instance = BuildService(service.ImplementationType);
                    break;
            }
            return service.Instance;
        }

        private object BuildService(Type serviceTypeToBuild)
        {
            object service = null;

            ConstructorInfo[] constructors = serviceTypeToBuild.GetConstructors();
            if (constructors.Length == 0)
            {
                return Activator.CreateInstance(serviceTypeToBuild);
            }
            foreach (ConstructorInfo constructor in constructors)
            {
                var parameters = constructor.GetParameters();
                object[] constructorArguments = parameters.Select(p => GetService(p.ParameterType)).Where(p => p != null).ToArray();
                if (parameters.Length != constructorArguments.Length)
                {
                    continue;
                }
                service = Activator.CreateInstance(serviceTypeToBuild, constructorArguments);
                break;
            }
            return service;
        }

        private ServiceCollection AddService<TService, TImplementation>(ServiceType type, object instance = null)
        {
            Type serviceType = typeof(TService);
            Service service = new Service
            {
                Type = type,
                ServiceType = serviceType,
                ImplementationType = typeof(TImplementation),
                Instance = instance
            };

            try
            {
                services.Add(serviceType.FullName, service);
            } 
            catch (ArgumentException)
            {
                throw new Exception($"Service {serviceType.FullName} already have an implementation defined.");
            }

            return this;
        }
    }
}
