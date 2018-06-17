using AspieTech.Builder.ResourceCodes;
using AspieTech.DependencyInjection;
using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Interfaces;
using AspieTech.Logger.DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;

namespace AspieTech.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DependencyInjectionServices dis = DependencyInjectionHandler.ServiceProvider.GetService<DependencyInjectionServices>())
            {
                IResourceResult<EBuilderCode> res = dis.ResourceHandler.GetResourceResult<EBuilderCode>(EBuilderCode.azerty, CultureInfo.CurrentCulture);

                try
                {
                    NullReferenceException exception = dis.LocalizableLogHandler.ProvideException<NullReferenceException, EBuilderCode>(EBuilderCode.azerty);
                    throw exception;
                }
                catch (Exception e)
                {
                    dis.LocalizableLogHandler.LocalizableError(e);
                }
            }
        }
    }
}
