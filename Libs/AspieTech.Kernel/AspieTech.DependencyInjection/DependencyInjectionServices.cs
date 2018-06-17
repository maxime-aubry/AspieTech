using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace AspieTech.DependencyInjection.Interfaces
{
    public class DependencyInjectionServices : IDisposable
    {
        private readonly ILocalizableLogHandler localizableLogHandler;
        private readonly IResourceHandler resourceHandler;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public DependencyInjectionServices(ILocalizableLogHandler localizableLogHandler, IResourceHandler resourceHandler)
        {
            this.localizableLogHandler = localizableLogHandler;
            this.resourceHandler = resourceHandler;
        }

        public ILocalizableLogHandler LocalizableLogHandler
        {
            get
            {
                return this.localizableLogHandler;
            }
        }

        public IResourceHandler ResourceHandler
        {
            get
            {
                return this.resourceHandler;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
                handle.Dispose();
            this.disposed = true;
        }
    }
}