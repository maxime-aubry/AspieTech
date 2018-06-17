using System;
using System.Globalization;

namespace AspieTech.DependencyInjection.Abstractions.Localization.Interfaces
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
        bool IsUserInterfaceResource<TResourceCode>(TResourceCode resourceCode) where TResourceCode : struct, IConvertible;
        bool IsClientErrorResource<TResourceCode>(TResourceCode resourceCode) where TResourceCode : struct, IConvertible;
        bool IsServerErrorResource<TResourceCode>(TResourceCode resourceCode) where TResourceCode : struct, IConvertible;
        IResourceResult<TResourceCode> GetResourceResult<TResourceCode>(TResourceCode resourceCode, CultureInfo culture, params object[] args) where TResourceCode : struct, IConvertible;
        void Export();
        #endregion

        #region Private methods

        #endregion
    }
}