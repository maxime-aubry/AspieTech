using AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces.Entities;
using AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces.Factories;
using Microsoft.Win32.SafeHandles;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace AspieTech.Logger.DataAccessLayer
{
    public class AppLogsDBManager : IDisposable
    {
        #region Private properties
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<ILogEventInfoFactory> logs;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        #region Constructors
        public AppLogsDBManager(string connectionString)
        {
            this.client = new MongoClient(connectionString);
            this.database = client.GetDatabase("AppLogsDB");
            this.logs = this.database.GetCollection<ILogEventInfoFactory>("Logs");
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public IMongoCollection<ILogEventInfoFactory> Logs
        {
            get
            {
                return this.logs;
            }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        public IEnumerable<ILogEventInfoEntity> Search(Expression<Func<ILogEventInfoEntity, bool>> filter)
        {
            return this.GetCollection<ILogEventInfoEntity>().Find<ILogEventInfoEntity>(filter).ToEnumerable<ILogEventInfoEntity>();
        }

        public ILogEventInfoEntity GetById<ILogEventInfoEntity>(string id)
        {
            ObjectId objectId = ObjectId.Empty;

            if (ObjectId.TryParse(id, out objectId))
            {
                FilterDefinition<ILogEventInfoEntity> filter = Builders<ILogEventInfoEntity>.Filter.Eq("Id", id);
                return this.GetCollection<ILogEventInfoEntity>().Find(filter).FirstOrDefault();
            }

            return default(ILogEventInfoEntity);
        }

        public IEnumerable<ILogEventInfoEntity> GetAll()
        {
            return this.GetCollection<ILogEventInfoEntity>().Find(new BsonDocument()).ToEnumerable<ILogEventInfoEntity>();
        }

        public void Update(ILogEventInfoEntity entity, string id)
        {
            FilterDefinition<ILogEventInfoEntity> filter = Builders<ILogEventInfoEntity>.Filter.Eq("Id", id);
            this.GetCollection<ILogEventInfoEntity>().ReplaceOne(filter, entity);
        }

        public void Store(ILogEventInfoEntity entity)
        {
            this.GetCollection<ILogEventInfoEntity>().InsertOne(entity);
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
        #endregion

        #region Private methods
        private void CheckCollections()
        {
            CheckCollection<ILogEventInfoEntity>();
        }

        private void CheckCollection<ILogEventInfoEntity>()
        {
            Type entity = typeof(ILogEventInfoEntity);
            IMongoCollection<ILogEventInfoEntity> collection = this.database.GetCollection<ILogEventInfoEntity>(entity.Name);
            if (collection == null)
            {
                this.database.CreateCollection(entity.Name);
            }
        }

        private IMongoCollection<ILogEventInfoEntity> GetCollection<ILogEventInfoEntity>()
        {
            Type entity = typeof(ILogEventInfoEntity);
            IMongoCollection<ILogEventInfoEntity> collection = this.database.GetCollection<ILogEventInfoEntity>(entity.Name);
            return collection;
        }
        #endregion
    }
}
