using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.BridgeHandler
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
        void LocalizableError<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableError<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        void LocalizableInfo<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableInfo<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        void LocalizableDebug<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableDebug<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        void LocalizableFatal<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableFatal<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        void LocalizableOff<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableOff<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        void LocalizableTrace<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableTrace<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        void LocalizableWarn<T>(T resourceCode, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableWarn<T>(T resourceCode, params object[] args) where T : struct, IConvertible;
        #endregion

        #region Private methods

        #endregion
    }
}
