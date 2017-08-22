using AspieTech.BridgeHandler.LocalizationHandler;
using AspieTech.BridgeHandler.LoggerHandler;
using AspieTech.LocalizationHandler.ResourceCodes;
using AspieTech.LoggerHandler;
using Autofac;
using System;
using System.Threading;

namespace AspieTech.Builder
{
    public class Program
    {
        static void Main(string[] args)
        {
            DependenciesHandler.Configure();

            using (ILifetimeScope scope = DependenciesHandler.Container.BeginLifetimeScope())
            {
                ILocalizableLogHandler localizableLogHandler = scope.Resolve<ILocalizableLogHandler>();
                IResourceHandler resourceHandler = scope.Resolve<IResourceHandler>();
                
                try
                {
                    NullReferenceException exception = localizableLogHandler.ProvideException<NullReferenceException, EKernelCode>(EKernelCode.SEx1HI324MZLC);
                    throw exception;
                }
                catch (Exception e)
                {
                    localizableLogHandler.LocalizableError(e);
                }

                Console.Read();
            }
        }
    }
}