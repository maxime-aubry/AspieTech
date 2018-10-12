using AspieTech.DependencyInjection.Abstractions.Repository;
using Microsoft.Win32.SafeHandles;
using System;
using System.Data.Entity;
using System.Runtime.InteropServices;

namespace AspieTech.Repository
{
    /// <summary>
    /// Database context manager
    /// </summary>
    public class SqlUnitOfWork : IUnitOfWork<DbContext>, IDisposable
    {
        #region Public properties
        /// <summary>
        /// The database context
        /// </summary>
        public DbContext Context { get; }
        #endregion

        #region Private properties
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for SQL Unit of Work
        /// </summary>
        /// <param name="context">SQL database utility</param>
        public SqlUnitOfWork(DbContext context)
        {
            Context = context;
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
        /// Disposes the database context manager
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Disposes the database context manager
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
