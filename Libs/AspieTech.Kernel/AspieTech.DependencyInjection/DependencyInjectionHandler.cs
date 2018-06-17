using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using AspieTech.DependencyInjection.Interfaces;
using AspieTech.Localization;
using AspieTech.Logger.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspieTech.DependencyInjection
{
    public class DependencyInjectionHandler
    {
        private static DependencyInjectionHandler dependencyInjectionHandler;
        private IServiceProvider serviceProvider;

        private DependencyInjectionHandler()
        {
            this.serviceProvider = this.ConfigureServices();
        }

        public static IServiceProvider ServiceProvider
        {
            get
            {
                if (dependencyInjectionHandler == null)
                {
                    dependencyInjectionHandler = new DependencyInjectionHandler();
                }
                return dependencyInjectionHandler.serviceProvider;
            }
        }

        private IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            IResourceHandler resourceHandler = new ResourceHandler();
            ILocalizableLogHandler localizableLogHandler = LocalizableLogHandler.GetCurrentLocalizedLogger(resourceHandler);
            services.AddSingleton<IResourceHandler>(resourceHandler);
            services.AddSingleton<ILocalizableLogHandler>(localizableLogHandler);
            services.AddSingleton<DependencyInjectionServices>();
            return services.BuildServiceProvider();
        }
    }
}
