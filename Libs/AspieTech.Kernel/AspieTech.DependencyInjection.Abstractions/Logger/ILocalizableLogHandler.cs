using System;
using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Repository;

namespace AspieTech.DependencyInjection.Abstractions.Logger.Interfaces
{
    public interface ILocalizableLogHandler
    {
        IResourceHandler ResourceHandler { get; set; }

        void LocalizableDebug(Exception exception);
        void LocalizableDebug<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        void LocalizableError(Exception exception);
        void LocalizableError<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        void LocalizableFatal(Exception exception);
        void LocalizableFatal<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        void LocalizableInfo(Exception exception);
        void LocalizableInfo<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        void LocalizableOff(Exception exception);
        void LocalizableOff<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        void LocalizableTrace(Exception exception);
        void LocalizableTrace<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        void LocalizableWarn(Exception exception);
        void LocalizableWarn<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible;
        TException ProvideException<TException, TResourceCode>(TResourceCode resourceCode, params object[] args) where TException : Exception, new();
    }
}