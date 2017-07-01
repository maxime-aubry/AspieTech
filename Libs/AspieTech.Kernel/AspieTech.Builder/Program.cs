using AspieTech.BridgeHandler;
using AspieTech.LocalizationHandler.ResourceSerials;
using Autofac;

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

                //localizableLogHandler.LocalizableError<EKernelCode>(EKernelCode.x54x5, "test", "azerty");
                resourceHandler.Export();
            }
        }
    }
}