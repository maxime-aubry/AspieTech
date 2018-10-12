using AspieTech.DependencyInjection.Abstractions.Repository;
using Microsoft.Win32.SafeHandles;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AspieTech.Repository
{
    public class SqlRepository : IRepository
    {
        #region Public properties

        #endregion

        #region Private properties
        private IUnitOfWork<DbContext> unitOfWork { get; set; }
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for SQL Repository
        /// </summary>
        /// <param name="unitOfWork">Database context manager</param>
        public SqlRepository(IUnitOfWork<DbContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
        /// CRUD. Stores an item into database
        /// </summary>
        /// <typeparam name="TEntity">Entity type to process</typeparam>
        /// <param name="entity">Entity value to process</param>
        /// <returns>Asynchronous task</returns>
        public async Task Create<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                this.unitOfWork.Context.Set<TEntity>().Add(entity);
                this.unitOfWork.Context.Entry(entity).State = EntityState.Added;
                await this.unitOfWork.Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// CRUD. Reads items from database
        /// </summary>
        /// <typeparam name="TEntity">Entity type to process</typeparam>
        /// <returns>Queryable collection of TEntity</returns>
        public async Task<IQueryable<TEntity>> Read<TEntity>() where TEntity : class
        {
            try
            {
                return this.unitOfWork.Context.Set<TEntity>().AsQueryable<TEntity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// CRUD. Updates an item from database
        /// </summary>
        /// <typeparam name="TEntity">Entity type to process</typeparam>
        /// <param name="entity">Entity value to process</param>
        /// <returns>Asynchronous task with boolean value to inform about success or failure</returns>
        public async Task<bool> Update<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                TEntity existing = this.unitOfWork.Context.Set<TEntity>().Find(entity);

                if (existing != null)
                {
                    this.unitOfWork.Context.Set<TEntity>().Attach(entity);
                    this.unitOfWork.Context.Entry(entity).State = EntityState.Modified;
                }
                
                int result = await this.unitOfWork.Context.SaveChangesAsync();
                return (result > 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// CRUD. Destroys an item from database
        /// </summary>
        /// <typeparam name="TEntity">Entity type to process</typeparam>
        /// <param name="entity">Entity value to process</param>
        /// <returns>Asynchronous task with boolean value to inform about success or failure</returns>
        public async Task<bool> Destroy<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                TEntity existing = this.unitOfWork.Context.Set<TEntity>().Find(entity);

                if (existing != null)
                {
                    this.unitOfWork.Context.Set<TEntity>().Remove(existing);
                    this.unitOfWork.Context.Entry(entity).State = EntityState.Deleted;
                }

                int result = await this.unitOfWork.Context.SaveChangesAsync();
                return (result > 0);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

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
        /// Creates a collection into MongoDB if does not exist
        /// </summary>
        /// <typeparam name="TEntity">Entity type to process</typeparam>
        /// <param name="collection">output result of IMongoCollection</param>
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
