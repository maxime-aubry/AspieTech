using AspieTech.BridgeHandler.LocalizationHandler;
using AspieTech.BridgeHandler.LoggerHandler;
using AspieTech.LocalizationHandler;
using AspieTech.LoggerHandler;
using Autofac;
using System.Reflection;

namespace AspieTech.Builder
{
    public class DependenciesHandler
    {
        public static IContainer Container { get; set; }

        public static void Configure()
        {
            // dependendies
            IResourceHandler resourceHandler = new ResourceHandler();
            ILocalizableLogHandler localizableLogHandler = LocalizableLogHandler.GetCurrentLocalizedLogger(resourceHandler);

            // builder
            ContainerBuilder builder = new ContainerBuilder();
            Assembly currentExecutingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterInstance(resourceHandler).As(typeof(IResourceHandler), typeof(ResourceHandler));
            builder.RegisterInstance(localizableLogHandler).As(typeof(ILocalizableLogHandler), typeof(LocalizableLogHandler));
            DependenciesHandler.Container = builder.Build();
        }
    }
}
