using AspieTech.BridgeHandler.LocalizationHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspieTech.LoggerHandler
{
    public class LocalizableException<TException, TResourceCode> : Exception
        where TException : Exception
        where TResourceCode : struct, IConvertible
    {
        #region Private properties
        private IResourceHandler resourceHandler;
        private string message;
        #endregion

        #region Constructors
        public LocalizableException(TResourceCode resourceCode, IResourceHandler resourceHandler)
            : this(resourceCode, resourceHandler, null)
        {

        }

        public LocalizableException(TResourceCode resourceCode, IResourceHandler resourceHandler, Exception innerException)
            : base(null, innerException)
        {
            this.resourceHandler = resourceHandler;
            IResourceResult<TResourceCode> resourceResult = this.GetResourceResult<TResourceCode>(resourceCode);
            this.message = resourceResult.StringContent;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods

        #endregion

        #region Private methods
        private IResourceResult<TResourceCode> GetResourceResult<TResourceCode>(TResourceCode resourceCode)
            where TResourceCode : struct, IConvertible
        {
            if (this.resourceHandler.IsServerErrorResource<TResourceCode>(resourceCode))
            {
                IResourceResult<TResourceCode> resourceResult = this.resourceHandler.GetResourceResult<TResourceCode>(resourceCode, Thread.CurrentThread.CurrentCulture);
                return resourceResult;
            }
            return null;
        }
        #endregion
    }
}