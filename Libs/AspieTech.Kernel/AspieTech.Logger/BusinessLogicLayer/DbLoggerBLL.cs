using AspieTech.DependencyInjection.Abstractions.Repository;
using AspieTech.Logger.DataAccessLayer.Entities;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspieTech.Logger.BusinessLogicLayer
{
    public class DbLoggerBLL
    {
        #region Public properties

        #endregion

        #region Private properties
        private IRepository repository { get; set; }
        #endregion

        #region Constructors
        public DbLoggerBLL(IRepository repository)
        {
            this.repository = repository;
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
        public async Task Create<TLogEventInfo>(TLogEventInfo logEventInfo)
        {
            try
            {
                LogEventInfoEntity entity = Mapper.Map<LogEventInfoEntity>(logEventInfo);
                await this.repository.Create<LogEventInfoEntity>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IQueryable<LogEventInfoEntity>> Read()
        {
            try
            {
                return await this.repository.Read<LogEventInfoEntity>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Private methods

        #endregion
    }
}
