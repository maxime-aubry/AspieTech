using System;
using System.IO;

namespace AspieTech.BridgeHandler.LocalizationHandler
{
    public interface IResourceInfo<TResourceCode>
        where TResourceCode : struct, IConvertible
    {
        #region Private properties

        #endregion

        #region Constructors

        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        Type ResourceType { get; set; }
        TResourceCode ResourceCode { get; set; }
        object[] Args { get; set; }
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