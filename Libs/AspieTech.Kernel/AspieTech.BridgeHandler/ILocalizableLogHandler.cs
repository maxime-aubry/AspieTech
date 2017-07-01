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
        void LocalizableError<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableError<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        void LocalizableInfo<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableInfo<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        void LocalizableDebug<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableDebug<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        void LocalizableFatal<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableFatal<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        void LocalizableOff<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableOff<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        void LocalizableTrace<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableTrace<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        void LocalizableWarn<T>(T resourceSerial, Exception exception = null, params object[] args) where T : struct, IConvertible;
        void LocalizableWarn<T>(T resourceSerial, params object[] args) where T : struct, IConvertible;
        #endregion

        #region Private methods

        #endregion
    }
}
