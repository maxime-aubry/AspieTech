using AspieTech.DependencyInjection.Abstractions.Repository;
using Microsoft.Win32.SafeHandles;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AspieTech.Repository
{
    /// <summary>
    /// MongoDB repository
    /// </summary>
    public class MongoRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Public properties

        #endregion

        #region Private properties
        private IUnitOfWork<IMongoDatabase> unitOfWork { get; set; }
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for MongoDB Repository
        /// </summary>
        /// <param name="unitOfWork">Database context manager</param>
        public MongoRepository(IUnitOfWork<IMongoDatabase> unitOfWork)
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
                IMongoCollection<TEntity> collection = null;
                this.CreateCollectionIfDoesNotExists(out collection);
                await collection.InsertOneAsync(entity);
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
                IMongoCollection<TEntity> collection = null;
                this.CreateCollectionIfDoesNotExists(out collection);
                return collection.AsQueryable<TEntity>();
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
            throw new Exception();
            //try
            //{
            //    IMongoCollection<TEntity> collection = null;
            //    this.CreateCollectionIfDoesNotExists<TEntity>(out collection);

            //    PropertyInfo idField = MongoRepository.GetIdField<TEntity>();
            //    string id = MongoRepository.GetValue<TEntity>(entity, idField);
            //    ObjectId objectId = ObjectId.Empty;

            //    if (ObjectId.TryParse(id, out objectId))
            //    {
            //        FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(idField.Name, id);
            //        UpdateDefinition<TEntity> update = null;

            //        foreach (PropertyInfo property in MongoRepository.GetDataFields<TEntity>())
            //        {
            //            object value = property.GetValue(entity);
            //            update = Builders<TEntity>.Update.Set(property.Name, value);
            //        }

            //        UpdateResult result = await collection.UpdateOneAsync(filter, update);
            //        return (result.ModifiedCount > 0);
            //    }

            //    throw new Exception("Unable to get object identifier");
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
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
                IMongoCollection<TEntity> collection = null;
                this.CreateCollectionIfDoesNotExists(out collection);

                PropertyInfo idField = MongoRepository<TEntity>.GetIdField();
                string id = MongoRepository<TEntity>.GetValue(entity, idField);
                ObjectId objectId = ObjectId.Empty;

                if (ObjectId.TryParse(id, out objectId))
                {
                    FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(idField.Name, id);
                    DeleteResult result = await collection.DeleteOneAsync(filter);
                    return (result.DeletedCount > 0);
                }

                throw new Exception("Unable to get object identifier");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> ExecStoredProcedureWithoutReturn<TEntity>(IStoredProcedure<TEntity> sp)
             where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> ExecStoredProcedureWithReturn<TEntity>(IStoredProcedure<TEntity> sp)
             where TEntity : class
        {
            throw new NotImplementedException();
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
        /// <param name="collection">output result of IMongoCollection</param>
        private void CreateCollectionIfDoesNotExists(out IMongoCollection<TEntity> collection)
        {
            collection = this.unitOfWork.Context.GetCollection<TEntity>(typeof(TEntity).Name);

            if (collection == null)
            {
                this.unitOfWork.Context.CreateCollection(typeof(TEntity).Name);
                collection = this.unitOfWork.Context.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        /// <summary>
        /// Provides a identifier field from current class model
        /// </summary>
        /// <returns>PropertyInfo of identifier field</returns>
        private static PropertyInfo GetIdField()
        {
            IEnumerable<PropertyInfo> properties = typeof(TEntity).GetProperties().AsEnumerable().Where(p => Attribute.IsDefined(p, typeof(BsonIdAttribute)));

            if (properties.Any())
                return properties.First();

            throw new Exception("Unable to get Bson identifier field");
        }

        /// <summary>
        /// Provides a collection of data fields from current class model
        /// </summary>
        /// <returns>Collection of PropertyInfo of data field</returns>
        private static IEnumerable<PropertyInfo> GetDataFields()
        {
            IEnumerable<PropertyInfo> properties = typeof(TEntity).GetProperties().AsEnumerable().Where(p => !Attribute.IsDefined(p, typeof(BsonIdAttribute)));
            return properties;
        }

        /// <summary>
        /// Provides the value of a field from current class model
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private static string GetValue(TEntity entity, PropertyInfo property)
        {
            string value = property.GetValue(entity) as string;
            return value;
        }

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
