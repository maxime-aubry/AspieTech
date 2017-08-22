using AspieTech.BridgeHandler.DataAccessLayer.Entities;
using System;

namespace AspieTech.DataAccessLayer.Entities
{
    public class LogEventInfoEntity : ILogEventInfoEntity
    {
        #region Private properties
        private Guid logID;
        private string logLevel;
        private string exceptionType;
        private string message;
        private string stackTrace;
        private string innerException;
        private string additionalInfo;
        private DateTime loggedOnDate;
        private string resourceType;
        private string resourceCode;
        private string args;
        #endregion

        #region Constructors

        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public Guid LogID
        {
            get { return this.logID; }
            set { this.logID = value; }
        }

        public string Level
        {
            get { return this.logLevel; }
            set { this.logLevel = value; }
        }

        public string ExceptionType
        {
            get { return this.exceptionType; }
            set { this.exceptionType = value; }
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public string StackTrace
        {
            get { return this.stackTrace; }
            set { this.stackTrace = value; }
        }

        public string InnerException
        {
            get { return this.innerException; }
            set { this.innerException = value; }
        }

        public string AdditionalInfo
        {
            get { return this.additionalInfo; }
            set { this.additionalInfo = value; }
        }

        public DateTime LoggedOnDate
        {
            get { return this.loggedOnDate; }
            set { this.loggedOnDate = value; }
        }

        public string ResourceType
        {
            get { return this.resourceType; }
            set { this.resourceType = value; }
        }

        public string ResourceCode
        {
            get { return this.resourceCode; }
            set { this.resourceCode = value; }
        }

        public string Args
        {
            get { return this.args; }
            set { this.args = value; }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods

        #endregion

        #region Private methods

        #endregion
    }
}