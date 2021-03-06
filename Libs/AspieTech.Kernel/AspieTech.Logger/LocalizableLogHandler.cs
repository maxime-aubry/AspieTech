﻿using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Repository;
using AspieTech.Logger.BusinessLogicLayer;
using AspieTech.Logger.DataAccessLayer.Entities;
using Microsoft.Win32.SafeHandles;
using NLog;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace AspieTech.Logger.DataAccessLayer
{
    public class LocalizableLogHandler : NLog.Logger, ILocalizableLogHandler, IDisposable
    {
        #region Public properties
        public IResourceHandler ResourceHandler { get; set; }
        #endregion

        #region Private properties
        private IRepository<LogEventInfoEntity> repository { get; set; }
        private DbLoggerBLL dbLogger { get; set; }
        private object locker = new object();
        private const string resourceCodeType = "ResourceCodeType";
        private const string resourceCode = "ResourceCode";
        private const string args = "Args";
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        #endregion

        #region Constructors
        public LocalizableLogHandler()
            : base()
        {

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
        public static LocalizableLogHandler GetCurrentLocalizedLogger(IResourceHandler resourceHandler, IRepositoryProvider repositoryProvider, string connectionString)
        {
            IRepository<LogEventInfoEntity> loggerRepository = repositoryProvider.Provide<LogEventInfoEntity>(connectionString);
            LocalizableLogHandler logger = (LocalizableLogHandler)LogManager.GetCurrentClassLogger(typeof(LocalizableLogHandler));
            logger.ResourceHandler = resourceHandler;
            logger.dbLogger = new DbLoggerBLL(loggerRepository);
            return logger;
        }

        public TException ProvideException<TException, TResourceCode>(TResourceCode resourceCode, params object[] args)
            where TException : Exception, new()
        {
            TException exception = new TException();
            exception.Data.Add(LocalizableLogHandler.resourceCodeType, typeof(TResourceCode));
            exception.Data.Add(LocalizableLogHandler.resourceCode, resourceCode);
            exception.Data.Add(LocalizableLogHandler.args, args);
            return exception;
        }

        /// <summary>
        /// Get a localizable trace message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableTrace(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Trace, exception);
        }

        /// <summary>
        /// Get a localizable trace message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableTrace<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Trace, null, resourceCode, args);
        }

        /// <summary>
        /// Get a localizable debug message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableDebug(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Debug, exception);
        }

        /// <summary>
        /// Get a localizable debug message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableDebug<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Debug, null, resourceCode, args);
        }

        /// <summary>
        /// Get a localizable info message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableInfo(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Info, exception);
        }

        /// <summary>
        /// Get a localizable info message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableInfo<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Info, null, resourceCode, args);
        }

        /// <summary>
        /// Get a localizable warn message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableWarn(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Warn, exception);
        }

        /// <summary>
        /// Get a localizable warn message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableWarn<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Warn, null, resourceCode, args);
        }

        /// <summary>
        /// Get a localizable error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableError(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Error, exception);
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
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Error, null, resourceCode, args);
        }

        /// <summary>
        /// Get a localizable fatal error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableFatal(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Fatal, exception);
        }

        /// <summary>
        /// Get a localizable fatal error message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableFatal<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Fatal, null, resourceCode, args);
        }

        /// <summary>
        /// Get a localizable off message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void LocalizableOff(Exception exception)
        {
            this.LocalizableLogInternal(LogLevel.Off, exception);
        }

        /// <summary>
        /// Get a localizable off message.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <param name="args">The args (for string formatting).</param>
        public void LocalizableOff<TResourceCode>(TResourceCode resourceCode, params object[] args) where TResourceCode : struct, IConvertible
        {
            this.LocalizableLogInternal<TResourceCode>(LogLevel.Off, null, resourceCode, args);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private methods
        private void LocalizableLogInternal(LogLevel level, Exception exception)
        {
            Type resourceCodeType = exception.Data[LocalizableLogHandler.resourceCodeType] as Type;
            object resourceCode = exception.Data[LocalizableLogHandler.resourceCode];
            string[] args = exception.Data[LocalizableLogHandler.args] as string[];

            MethodInfo method = (from m in typeof(LocalizableLogHandler).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                               where m.Name == "LocalizableLogInternal"
                                                   && m.IsGenericMethod
                                                   && m.ContainsGenericParameters
                                               select m).FirstOrDefault();
            MethodInfo genericMethod = method.MakeGenericMethod(resourceCodeType);
            object[] parameters = new object[]
            {
                level,
                exception,
                resourceCode,
                args
            };
            genericMethod.Invoke(this, parameters);
        }

        private void LocalizableLogInternal<TResourceCode>(LogLevel level, Exception exception, TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            if (!typeof(TResourceCode).IsEnum)
                throw new ArgumentException("");

            if (!this.ResourceHandler.IsServerErrorResource<TResourceCode>(resourceCode))
                throw new ArgumentException("");

            Task.Run(() =>
            {
                lock (this.locker)
                {
                    this.LocalizableLogSubInternal<TResourceCode>(level, exception, resourceCode, args);
                }
            }).ConfigureAwait(false);
        }

        private void LocalizableLogSubInternal<TResourceCode>(LogLevel level, Exception exception, TResourceCode resourceCode, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            // get localized message
            IResourceResult<TResourceCode> resourceItem = this.ResourceHandler.GetResourceResult<TResourceCode>(resourceCode, Thread.CurrentThread.CurrentCulture, args);

            // create log
            LogEventInfo logEventInfo = LogEventInfo.Create(level, this.Name, exception, null, resourceItem.StringContent, args);
            logEventInfo.Properties.Add("ID", Guid.NewGuid());
            logEventInfo.Properties.Add("ResourceType", typeof(TResourceCode).FullName);
            logEventInfo.Properties.Add("ResourceCode", resourceCode);
            logEventInfo.Properties.Add("Args", args);

            base.Log(typeof(LocalizableLogHandler), logEventInfo);

            this.dbLogger.Create(logEventInfo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;
            if (disposing)
                handle.Dispose();
            this.disposed = true;
        }
        #endregion
    }
}