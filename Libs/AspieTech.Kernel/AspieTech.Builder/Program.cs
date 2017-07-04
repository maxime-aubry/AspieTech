using AspieTech.BridgeHandler;
using AspieTech.BridgeHandler.LocalizationHandler;
using AspieTech.LocalizationHandler.ResourceCodes;
using AspieTech.LoggerHandler;
using Autofac;
using System;

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

                LocalizableException<ArgumentNullException, EKernelCode> ex = new LocalizableException<ArgumentNullException, EKernelCode>(EKernelCode.SEx1HI324MZLC, resourceHandler);

                //localizableLogHandler.LocalizableError<EKernelCode>(EKernelCode.SEx1HI324MZLC, "test", "azerty");
                //resourceHandler.Export();
            }
        }
    }
}