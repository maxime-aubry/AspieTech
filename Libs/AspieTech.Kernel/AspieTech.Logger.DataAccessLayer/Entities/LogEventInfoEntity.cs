using AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AspieTech.Logger.DataAccessLayer.Entities
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
        private string resourceManagerType;
        private string resourceCode;
        private string args;
        #endregion

        #region Constructors

        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        [BsonId]
        public Guid LogID
        {
            get { return this.logID; }
            set { this.logID = value; }
        }

        [BsonElement("level")]
        public string Level
        {
            get { return this.logLevel; }
            set { this.logLevel = value; }
        }

        [BsonElement("exception_type")]
        public string ExceptionType
        {
            get { return this.exceptionType; }
            set { this.exceptionType = value; }
        }

        [BsonElement("message")]
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        [BsonElement("stack_trace")]
        public string StackTrace
        {
            get { return this.stackTrace; }
            set { this.stackTrace = value; }
        }

        [BsonElement("inner_exception")]
        public string InnerException
        {
            get { return this.innerException; }
            set { this.innerException = value; }
        }

        [BsonElement("additional_info")]
        public string AdditionalInfo
        {
            get { return this.additionalInfo; }
            set { this.additionalInfo = value; }
        }

        [BsonElement("logged_on_date")]
        public DateTime LoggedOnDate
        {
            get { return this.loggedOnDate; }
            set { this.loggedOnDate = value; }
        }

        [BsonElement("resource_manager_type")]
        public string ResourceManagerType
        {
            get { return this.resourceManagerType; }
            set { this.resourceManagerType = value; }
        }

        [BsonElement("resource_code")]
        public string ResourceCode
        {
            get { return this.resourceCode; }
            set { this.resourceCode = value; }
        }

        [BsonElement("args")]
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