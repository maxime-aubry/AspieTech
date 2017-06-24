using System;
using System.Globalization;

namespace AspieTech.LocalizationHandler
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
        string GetString<T>(T resourceSerial, CultureInfo culture) where T : struct, IConvertible;
        void Export();
        #endregion

        #region Private methods

        #endregion
    }
}
