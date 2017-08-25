using System;

namespace AspieTech.Engine.Handlers.Vaillant
{
    public class VaillantDetailsAttribute : Attribute
    {
        #region Private properties
        private Uri requestUri;
        #endregion

        #region Constructors
        public VaillantDetailsAttribute(string requestUri, UriKind uriKind)
        {
            this.requestUri = new Uri(requestUri, uriKind);
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public Uri RequestUri
        {
            get { return this.requestUri; }
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
