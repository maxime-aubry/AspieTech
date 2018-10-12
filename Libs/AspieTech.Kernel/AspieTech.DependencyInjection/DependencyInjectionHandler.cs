using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Repository;
using AspieTech.DependencyInjection.Interfaces;
using AspieTech.Localization;
using AspieTech.Logger.DataAccessLayer;
using AspieTech.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspieTech.DependencyInjection
{
    /// <summary>
    /// Dependency injection handler
    /// </summary>
    public class DependencyInjectionHandler
    {
        #region Public properties

        #endregion

        #region Private properties
        private static DependencyInjectionHandler dependencyInjectionHandler;
        private IServiceProvider serviceProvider;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for dependency injection handler
        /// </summary>
        private DependencyInjectionHandler(IConfiguration builder)
        {
            this.serviceProvider = this.ConfigureServices(builder);
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        /// <summary>
        /// Provides a service
        /// </summary>
        public static IServiceProvider GetServiceProvider(IConfiguration builder)
        {
            if (DependencyInjectionHandler.dependencyInjectionHandler == null)
            {
                DependencyInjectionHandler.dependencyInjectionHandler = new DependencyInjectionHandler(builder);
            }
            return DependencyInjectionHandler.dependencyInjectionHandler.serviceProvider;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Configures services
        /// </summary>
        /// <returns>IServiceProvider object</returns>
        private IServiceProvider ConfigureServices(IConfiguration builder)
        {
            IServiceCollection services = new ServiceCollection();
            IResourceHandler resourceHandler = new ResourceHandler();
            IRepositoryProvider repositoryProvider = new RepositoryProvider();
            IRepository loggerRepository = repositoryProvider.Provide(builder.GetConnectionString("LogsDB"));
            ILocalizableLogHandler localizableLogHandler = LocalizableLogHandler.GetCurrentLocalizedLogger(resourceHandler, loggerRepository);
            services.AddSingleton<IResourceHandler>(resourceHandler);
            services.AddSingleton<ILocalizableLogHandler>(localizableLogHandler);
            services.AddSingleton<IRepositoryProvider>(repositoryProvider);
            services.AddSingleton<DependencyInjectionServices>();
            return services.BuildServiceProvider();
        }
        #endregion
    }
}
