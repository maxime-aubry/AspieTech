using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using System;
using System.Globalization;

namespace AspieTech.DependencyInjection.Abstractions.Localization.Interfaces
{
    public interface IResourceHandler
    {
        #region Public properties
        ILocalizableLogHandler LocalizableLogHandler { get; set; }
        #endregion

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
        void SetResourceResult<TResourceCode>(TResourceCode resourceCode, CultureInfo culture, string filename) where TResourceCode : struct, IConvertible;
        void Export<TResourceCode>(string path) where TResourceCode : struct, IConvertible;
        #endregion

        #region Private methods

            #endregion
    }
}