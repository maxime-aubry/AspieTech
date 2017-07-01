using AspieTech.BridgeHandler;
using NLog;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AspieTech.LoggerHandler
{
    public class LocalizableLogHandler : Logger, ILocalizableLogHandler
    {
        #region Private properties
        private IResourceHandler resourceHandler { get; set; }
        #endregion

        #region Constructors
        public LocalizableLogHandler(IResourceHandler resourceHandler)
            : base()
        {
            this.resourceHandler = resourceHandler;
        }
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
        public static LocalizableLogHandler GetCurrentLocalizedLogger()
        {
            return (LocalizableLogHandler)LogManager.GetCurrentClassLogger(typeof(LocalizableLogHandler));
        }

        public void LocalizableError<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Error, resourceSerial, exception, null, null, args);
        }

        public void LocalizableError<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableError<T>(resourceSerial, null, args);
        }

        public void LocalizableInfo<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Info, resourceSerial, exception, null, null, args);
        }

        public void LocalizableInfo<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableInfo<T>(resourceSerial, null, args);
        }

        public void LocalizableDebug<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Debug, resourceSerial, exception, null, null, args);
        }

        public void LocalizableDebug<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableDebug<T>(resourceSerial, null, args);
        }

        public void LocalizableFatal<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Fatal, resourceSerial, exception, null, null, args);
        }

        public void LocalizableFatal<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableFatal<T>(resourceSerial, null, args);
        }

        public void LocalizableOff<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Off, resourceSerial, exception, null, null, args);
        }

        public void LocalizableOff<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableOff<T>(resourceSerial, null, args);
        }

        public void LocalizableTrace<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Trace, resourceSerial, exception, null, null, args);
        }

        public void LocalizableTrace<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableTrace<T>(resourceSerial, null, args);
        }

        public void LocalizableWarn<T>(T resourceSerial, Exception exception = null, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Warn, resourceSerial, exception, null, null, args);
        }

        public void LocalizableWarn<T>(T resourceSerial, params object[] args)
            where T : struct, IConvertible
        {
            this.LocalizableWarn<T>(resourceSerial, null, args);
        }
        #endregion

        #region Private methods
        private void LocalizableLogInternal<T>(LogLevel level, T resourceSerial, Exception exception, DateTime? startDateTime, Stopwatch stopWatch, params object[] args)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("");

            if (!this.resourceHandler.IsServerErrorResource<T>(resourceSerial))
                throw new ArgumentException("");

            Task.Run(() =>
            {
                this.LocalizableLogSubInternal(level, resourceSerial, exception, startDateTime, stopWatch, args);
            }).ConfigureAwait(false);
        }
        
        private void LocalizableLogSubInternal<T>(LogLevel level, T resourceSerial, Exception exception, DateTime? startDateTime, Stopwatch stopWatch, params object[] args)
            where T : struct, IConvertible
        {
            long duration = 0;
            LogEventInfo logEventInfo = null;

            // get watch duration
            if (stopWatch != null)
            {
                if (stopWatch.IsRunning)
                    stopWatch.Stop();
                duration = stopWatch.ElapsedMilliseconds;
            }
            else if (startDateTime.HasValue)
            {
                duration = Convert.ToInt64((DateTime.Now - startDateTime.Value).TotalMilliseconds);
            }

            // get localized message
            string message = this.resourceHandler.GetString<T>(resourceSerial, Thread.CurrentThread.CurrentCulture, args);

            // create log
            if (exception != null)
            {
                logEventInfo = LogEventInfo.Create(level, this.Name, exception, null, message);
                logEventInfo.Parameters = args;
            }
            else
            {
                logEventInfo = LogEventInfo.Create(level, this.Name, null, message, args);
            }

            logEventInfo.Properties.Add("ID", Guid.NewGuid());
            logEventInfo.Properties.Add("Message", message);
            logEventInfo.Properties.Add("ResourceType", typeof(T).FullName);
            logEventInfo.Properties.Add("ResourceSerial", resourceSerial);
            logEventInfo.Properties.Add("Duration", duration);
            base.Log(typeof(LocalizableLogHandler), logEventInfo);
        }
        #endregion
    }
}
