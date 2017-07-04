using AspieTech.BridgeHandler;
using AspieTech.BridgeHandler.LocalizationHandler;
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
        private object locker = new object();
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
        /// <summary>
        /// Get localized logger.
        /// </summary>
        /// <returns></returns>
        public static LocalizableLogHandler GetCurrentLocalizedLogger()
        {
            return (LocalizableLogHandler)LogManager.GetCurrentClassLogger(typeof(LocalizableLogHandler));
        }

        /// <summary>
        /// Get a localizable error message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableError<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Error, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable error message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableError<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableError<TResourceCode>(resourceCode, null, args);
        }

        /// <summary>
        /// Get a localizable info message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableInfo<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Info, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable info message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableInfo<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableInfo<TResourceCode>(resourceCode, null, args);
        }

        /// <summary>
        /// Get a localizable debug message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableDebug<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Debug, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable debug message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableDebug<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableDebug<TResourceCode>(resourceCode, null, args);
        }

        /// <summary>
        /// Get a localizable fatal message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableFatal<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Fatal, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable fatal message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableFatal<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableFatal<TResourceCode>(resourceCode, null, args);
        }

        /// <summary>
        /// Get a localizable off message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableOff<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Off, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable off message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableOff<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableOff<TResourceCode>(resourceCode, null, args);
        }

        /// <summary>
        /// Get a localizable trace message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableTrace<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Trace, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable trace message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableTrace<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableTrace<TResourceCode>(resourceCode, null, args);
        }

        /// <summary>
        /// Get a localizable warn message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableWarn<TResourceCode>(TResourceCode resourceCode, Exception exception = null, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal(LogLevel.Warn, resourceCode, exception, null, null, args);
        }

        /// <summary>
        /// Get a localizable warn message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableWarn<TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            this.LocalizableWarn<TResourceCode>(resourceCode, null, args);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// The localizable log internal.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="level">The log level.</param>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="startDateTime">The start datetime.</param>
        /// <param name="stopWatch">The stop watch.</param>
        /// <param name="args">The args (for string formatrting).</param>
        private void LocalizableLogInternal<TResourceCode>(LogLevel level, TResourceCode resourceCode, Exception exception, DateTime? startDateTime, Stopwatch stopWatch, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            if (!typeof(TResourceCode).IsEnum)
                throw new ArgumentException("");

            if (!this.resourceHandler.IsServerErrorResource<TResourceCode>(resourceCode))
                throw new ArgumentException("");

            Task.Run(() =>
            {
                lock (this.locker)
                {
                    this.LocalizableLogSubInternal<TResourceCode>(level, resourceCode, exception, startDateTime, stopWatch, args);
                }
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// The localizable log sub internal.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="level">The log level.</param>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="startDateTime">The start datetime.</param>
        /// <param name="stopWatch">The stop watch.</param>
        /// <param name="args">The args (for string formatrting).</param>
        private void LocalizableLogSubInternal<TResourceCode>(LogLevel level, TResourceCode resourceCode, Exception exception, DateTime? startDateTime, Stopwatch stopWatch, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            long duration = 0;

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
            IResourceResult<TResourceCode> resourceItem = this.resourceHandler.GetResourceResult<TResourceCode>(resourceCode, Thread.CurrentThread.CurrentCulture, args);

            // create log
            LogEventInfo logEventInfo = null;
            if (exception != null)
            {
                logEventInfo = LogEventInfo.Create(level, this.Name, exception, null, resourceItem.StringContent);
                logEventInfo.Parameters = args;
            }
            else
            {
                logEventInfo = LogEventInfo.Create(level, this.Name, null, resourceItem.StringContent, args);
            }

            logEventInfo.Properties.Add("ID", Guid.NewGuid());
            logEventInfo.Properties.Add("Message", resourceItem.StringContent);
            logEventInfo.Properties.Add("ResourceType", typeof(TResourceCode).FullName);
            logEventInfo.Properties.Add("ResourceCode", resourceCode);
            logEventInfo.Properties.Add("Duration", duration);

            base.Log(typeof(LocalizableLogHandler), logEventInfo);
        }
        #endregion
    }
}