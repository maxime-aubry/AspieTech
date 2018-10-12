using System;

namespace AspieTech.DependencyInjection.Abstractions.Logger
{
    public interface ILogEventInfoEntity
    {
        string AdditionalInfo { get; set; }
        string Args { get; set; }
        string ExceptionType { get; set; }
        string InnerException { get; set; }
        string Level { get; set; }
        DateTime LoggedOnDate { get; set; }
        Guid LogID { get; set; }
        string Message { get; set; }
        string ResourceCode { get; set; }
        string ResourceManagerType { get; set; }
        string StackTrace { get; set; }
    }
}
