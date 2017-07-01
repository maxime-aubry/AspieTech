using System;
using System.Globalization;

namespace AspieTech.BridgeHandler
{
    public interface IResourceHandler
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
        bool IsUserInterfaceResource<T>(T resourceSerial) where T : struct, IConvertible;
        bool IsClientErrorResource<T>(T resourceSerial) where T : struct, IConvertible;
        bool IsServerErrorResource<T>(T resourceSerial) where T : struct, IConvertible;
        string GetString<T>(T resourceSerial, CultureInfo culture, params object[] args) where T : struct, IConvertible;
        void Export();
        #endregion

        #region Private methods

        #endregion
    }
}
