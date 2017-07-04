using AspieTech.BridgeHandler.LocalizationHandler;
using System;
using System.IO;

namespace AspieTech.LocalizationHandler
{
    public class ResourceResult<TResourceCode> : IResourceResult<TResourceCode>
        where TResourceCode : struct, IConvertible
    {
        #region Private properties
        private IResourceInfo<TResourceCode> resourceInfo;
        private object objectContent;
        private Stream streamContent;
        private string stringContent;
        #endregion

        #region Constructors
        public ResourceResult()
        {

        }

        public ResourceResult(IResourceInfo<TResourceCode> resourceInfo, object objectContent)
        {
            this.resourceInfo = resourceInfo;
            this.objectContent = objectContent;
            this.streamContent = null;
            this.stringContent = null;
        }

        public ResourceResult(IResourceInfo<TResourceCode> resourceInfo, Stream streamContent)
        {
            this.resourceInfo = resourceInfo;
            this.objectContent = null;
            this.streamContent = streamContent;
            this.stringContent = null;
        }

        public ResourceResult(IResourceInfo<TResourceCode> resourceInfo, string stringContent)
        {
            this.resourceInfo = resourceInfo;
            this.objectContent = null;
            this.streamContent = null;
            this.stringContent = stringContent;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public IResourceInfo<TResourceCode> ResourceInfo
        {
            get
            {
                return this.resourceInfo;
            }
            set
            {
                this.resourceInfo = value;
            }
        }

        public object ObjectContent
        {
            get
            {
                return this.objectContent;
            }
            set
            {
                this.objectContent = value;
            }
        }

        public Stream StreamContent
        {
            get
            {
                return this.streamContent;
            }
            set
            {
                this.streamContent = value;
            }
        }

        public string StringContent
        {
            get
            {
                return this.stringContent;
            }
            set
            {
                this.stringContent = value;
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