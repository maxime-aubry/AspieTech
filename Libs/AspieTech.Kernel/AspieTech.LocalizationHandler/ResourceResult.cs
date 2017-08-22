using AspieTech.BridgeHandler.LocalizationHandler;
using AspieTech.LocalizationHandler.Attributes;
using System;
using System.IO;

namespace AspieTech.LocalizationHandler
{
    public class ResourceResult<TResourceCode> : IResourceResult<TResourceCode>
        where TResourceCode : struct, IConvertible
    {
        #region Private properties
        private object localizationUtility;
        private object resourceCodeDetails;
        private TResourceCode resourceCode;
        private object[] args;
        private object objectContent;
        private Stream streamContent;
        private string stringContent;
        #endregion

        #region Constructors
        public ResourceResult()
        {

        }

        public ResourceResult(object localizationUtility, object resourceCodeDetails, TResourceCode resourceCode)
            : this()
        {
            this.localizationUtility = localizationUtility;
            this.resourceCodeDetails = resourceCodeDetails;
            this.resourceCode = resourceCode;
        }

        public ResourceResult(object localizationUtility, object resourceCodeDetails, TResourceCode resourceCode, object objectContent)
            : this(localizationUtility, resourceCodeDetails, resourceCode)
        {
            this.objectContent = objectContent;
            this.streamContent = null;
            this.stringContent = null;
        }

        public ResourceResult(object localizationUtility, object resourceCodeDetails, TResourceCode resourceCode, Stream streamContent)
            : this(localizationUtility, resourceCodeDetails, resourceCode)
        {
            this.objectContent = null;
            this.streamContent = streamContent;
            this.stringContent = null;
        }

        public ResourceResult(object localizationUtility, object resourceCodeDetails, TResourceCode resourceCode, string stringContent, object[] args)
            : this(localizationUtility, resourceCodeDetails, resourceCode)
        {
            this.objectContent = null;
            this.streamContent = null;
            this.stringContent = stringContent;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public object LocalizationUtility
        {
            get { return this.localizationUtility; }
            set { this.localizationUtility = value; }
        }

        public object ResourceCodeDetails
        {
            get { return this.resourceCodeDetails; }
            set { this.resourceCodeDetails = value; }
        }

        public TResourceCode ResourceCode
        {
            get { return this.resourceCode; }
            set { this.resourceCode = value; }
        }

        public object[] Args
        {
            get { return this.args; }
            set { this.args = value; }
        }

        public object ObjectContent
        {
            get { return this.objectContent; }
            set { this.objectContent = value; }
        }

        public Stream StreamContent
        {
            get { return this.streamContent; }
            set { this.streamContent = value; }
        }

        public string StringContent
        {
            get { return this.stringContent; }
            set { this.stringContent = value; }
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