using AspieTech.BridgeHandler.DataAccessLayer.Factories;
using AspieTech.DataAccessLayer.Entities;
using AutoMapper;
using NLog;
using System;

namespace AspieTech.DataAccessLayer.Factories
{
    public class LogEventInfoFactory : ILogEventInfoFactory
    {
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
        public void Insert<LogEventInfo>(LogEventInfo logEventInfo)
        {
            try
            {
                using (AspieTechCAAContext context = new AspieTechCAAContext())
                {
                    LogEventInfoEntity entity = Mapper.Map<LogEventInfoEntity>(logEventInfo);
                    context.Logs.Add(entity);
                    context.SaveChanges();
                }
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