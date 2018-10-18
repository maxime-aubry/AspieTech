using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Repository;
using AspieTech.Logger.DataAccessLayer.Entities;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace AspieTech.DependencyInjection.Interfaces
{
    public class DependencyInjectionServices : IDisposable
    {
        #region Public properties

        #endregion

        #region Private properties
        private readonly ILocalizableLogHandler localizableLogHandler;
        private readonly IResourceHandler resourceHandler;
        private readonly IRepositoryProvider repositoryProvider;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for Dependency injection dervices
        /// </summary>
        /// <param name="localizableLogHandler">Localizable log handler</param>
        /// <param name="resourceHandler">Resource provider</param>
        /// <param name="repositoryProvider">Repository provider</param>
        public DependencyInjectionServices(ILocalizableLogHandler localizableLogHandler, IResourceHandler resourceHandler, IRepositoryProvider repositoryProvider)
        {
            this.localizableLogHandler = localizableLogHandler;
            this.resourceHandler = resourceHandler;
            this.repositoryProvider = repositoryProvider;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        /// <summary>
        /// Provides the Localizable log handler
        /// </summary>
        public ILocalizableLogHandler LocalizableLogHandler
        {
            get
            {
                return this.localizableLogHandler;
            }
        }

        /// <summary>
        /// Provides the resource provider
        /// </summary>
        public IResourceHandler ResourceHandler
        {
            get
            {
                return this.resourceHandler;
            }
        }

        /// <summary>
        /// Provides the repository provider
        /// </summary>
        public IRepositoryProvider RepositoryProvider
        {
            get
            {
                return this.repositoryProvider;
            }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        /// <summary>
        /// Disposes the repository
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Disposes the repository
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
                handle.Dispose();
            this.disposed = true;
        }
        #endregion
    }
}
