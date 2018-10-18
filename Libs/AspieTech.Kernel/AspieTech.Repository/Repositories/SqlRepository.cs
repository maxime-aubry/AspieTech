using AspieTech.DependencyInjection.Abstractions.Repository;
using AspieTech.Repository.Attributes;
using AspieTech.Repository.Tools;
using AspieTech.Utils;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AspieTech.Repository
{
    public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
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
        /// <param name="entity">Entity value to process</param>
        /// <returns>Asynchronous task</returns>
        public async Task Create(TEntity entity)
        {
            try
            {
                //if (typeof(TEntity) == typeof(StoredProcedure))
                //    throw new ArgumentException("Stored procedure are not allowed for this method. Only entities can be used.");

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
        /// <returns>Queryable collection of TEntity</returns>
        public async Task<IQueryable<TEntity>> Read()
        {
            try
            {
                //if (typeof(TEntity) == typeof(StoredProcedure))
                //    throw new ArgumentException("Stored procedure are not allowed for this method. Only entities or viewes can be used.");

                //string name = null;
                //IEnumerable<SqlParameter> sqlParameter = null;
                //StoredProcedureTools.GetStoredProcedureSignature(() => StoredProcedureTest.masuperfonction("azerty", "ytreza"), out name, out sqlParameter);

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
        /// <param name="entity">Entity value to process</param>
        /// <returns>Asynchronous task with boolean value to inform about success or failure</returns>
        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                //if (typeof(TEntity) == typeof(StoredProcedure))
                //    throw new ArgumentException("Stored procedure are not allowed for this method. Only entities can be used.");

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
        /// <param name="entity">Entity value to process</param>
        /// <returns>Asynchronous task with boolean value to inform about success or failure</returns>
        public async Task<bool> Destroy(TEntity entity)
        {
            try
            {
                //if (typeof(TEntity) == typeof(StoredProcedure))
                //    throw new ArgumentException("Stored procedure are not allowed for this method. Only entities can be used.");

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

        //public Task<int> ExecStoredProcedureWithoutReturn<TEntity>(IStoredProcedure<TEntity> sp, out SqlParameter[] parameters)
        //     where TEntity : class
        //{
        //    try
        //    {
        //        StoredProcedureAttribute storedProcedureAttribute = AttributeHandler.GetCustomAttributeOnType<TEntity, StoredProcedureAttribute>();

        //        if (storedProcedureAttribute == null)
        //            throw new ArgumentException("L'argument passé en paramètre n'est pas signature de procédure stockée");

        //        //string sqlQuery = null;
        //        //parameters = sp.Parameters.Where(p => p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output).ToArray<SqlParameter>();
        //        //StoredProcedureTools.BuildSqlQuery("", null, out sqlQuery);

        //        DbRawSqlQuery<TEntity> result = this.unitOfWork.Context.Database.SqlQuery<TEntity>("", sp.Parameters);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    throw new NotImplementedException();
        //}

        //public Task<IQueryable<TEntity>> ExecStoredProcedureWithReturn<TEntity>(IStoredProcedure<TEntity> sp, out SqlParameter[] parameters)
        //     where TEntity : class
        //{
        //    try
        //    {

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    throw new NotImplementedException();
        //}

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
        /// <param name="collection">output result of IMongoCollection</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
                handle.Dispose();
            this.disposed = true;
        }

        public Task<int> ExecStoredProcedureWithoutReturn<TEntity1>(IStoredProcedure<TEntity1> sp) where TEntity1 : class
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity1>> ExecStoredProcedureWithReturn<TEntity1>(IStoredProcedure<TEntity1> sp) where TEntity1 : class
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
