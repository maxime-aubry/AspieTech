using AspieTech.DependencyInjection.Abstractions.Repository;
using MongoDB.Driver;
using System;
using System.Data.Common;
using System.Data.Entity;

namespace AspieTech.Repository
{
    /// <summary>
    /// SQL repository
    /// </summary>
    public class RepositoryProvider : IRepositoryProvider
    {
        #region Public properties

        #endregion

        #region Private properties

        #endregion

        #region Constructors

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
        /// Provides a data repository
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public IRepository<TEntity> Provide<TEntity>(string connectionString)
             where TEntity : class
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                    throw new Exception("connexion string manquante");

                using (DbContext context = new DbContext(connectionString))
                {
                    if (!context.Database.Exists())
                        throw new Exception("connexion impossible");

                    DbProviderFactory factory = DbProviderFactories.GetFactory(context.Database.Connection);
                    Type factoryType = factory.GetType();
                    Type connectionType = context.Database.Connection.GetType();

                    if (factoryType.FullName == "System.Data.SqlClient.SqlClientFactory")
                        return RepositoryProvider.ProvideSqlRepository<TEntity>(connectionString);
                    if (factoryType.FullName == "mongo")
                        return RepositoryProvider.ProvideMongoRepository<TEntity>(connectionString);

                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Provides a MongoDB repository
        /// </summary>
        /// <param name="connectionString">Connection string for database</param>
        /// <returns>MongoDB repository</returns>
        private static IRepository<TEntity> ProvideMongoRepository<TEntity>(string connectionString)
             where TEntity : class
        {
            string databaseName = MongoUrl.Create(connectionString).DatabaseName;
            IMongoClient client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(databaseName);

            using (IUnitOfWork<IMongoDatabase> unitOfWork = new MongoUnitOfWork(database))
            {
                return new MongoRepository<TEntity>(unitOfWork);
            }
        }

        /// <summary>
        /// Provides a SQL repository
        /// </summary>
        /// <param name="connectionString">Connection string for database</param>
        /// <returns>SQL repository</returns>
        private static IRepository<TEntity> ProvideSqlRepository<TEntity>(string connectionString)
             where TEntity : class
        {
            DbContext context = new DbContext(connectionString);
            using (IUnitOfWork<DbContext> unitOfWork = new SqlUnitOfWork(context))
            {
                return new SqlRepository<TEntity>(unitOfWork);
            }
        }
        #endregion
    }
}
