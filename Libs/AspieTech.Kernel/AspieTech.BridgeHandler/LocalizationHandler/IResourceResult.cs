using System;
using System.IO;

namespace AspieTech.BridgeHandler.LocalizationHandler
{
    public interface IResourceResult<TResourceCode>
        where TResourceCode : struct, IConvertible
    {
        #region Private properties

        #endregion

        #region Constructors

        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        IResourceInfo<TResourceCode> ResourceInfo { get; set; }
        object ObjectContent { get; set; }
        Stream StreamContent { get; set; }
        string StringContent { get; set; }
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