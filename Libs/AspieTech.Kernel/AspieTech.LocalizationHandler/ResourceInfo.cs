using AspieTech.BridgeHandler.LocalizationHandler;
using System;
using System.IO;

namespace AspieTech.LocalizationHandler
{
    public class ResourceInfo<TResourceCode> : IResourceInfo<TResourceCode>
        where TResourceCode : struct, IConvertible
    {
        #region Private properties
        private Type resourceType;
        private TResourceCode resourceCode;
        private object[] args;
        #endregion

        #region Constructors
        public ResourceInfo()
        {

        }

        public ResourceInfo(TResourceCode resourceCode, object[] args)
        {
            this.resourceCode = resourceCode;
            this.resourceType = typeof(TResourceCode);
            this.args = args;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public Type ResourceType
        {
            get
            {
                return this.resourceType;
            }
            set
            {
                this.resourceType = value;
            }
        }

        public TResourceCode ResourceCode
        {
            get
            {
                return this.resourceCode;
            }
            set
            {
                this.resourceCode = value;
            }
        }

        public object[] Args
        {
            get
            {
                return this.args;
            }
            set
            {
                this.args = value;
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

        #endregion
    }
}