using System;

namespace AspieTech.BridgeHandler.LoggerHandler
{
    public interface ILocalizableLogHandler
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
        TException ProvideException<TException, TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TException : Exception, new();
        void LocalizableTrace(Exception exception);
        void LocalizableTrace<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        void LocalizableDebug(Exception exception);
        void LocalizableDebug<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        void LocalizableInfo(Exception exception);
        void LocalizableInfo<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        void LocalizableWarn(Exception exception);
        void LocalizableWarn<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        void LocalizableError(Exception exception);
        void LocalizableError<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        void LocalizableFatal(Exception exception);
        void LocalizableFatal<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        void LocalizableOff(Exception exception);
        void LocalizableOff<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible;
        #endregion

        #region Private methods

        #endregion
    }
}