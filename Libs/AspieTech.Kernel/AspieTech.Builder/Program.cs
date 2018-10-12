using AspieTech.Builder.ResourceCodes;
using AspieTech.DependencyInjection;
using AspieTech.DependencyInjection.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AspieTech.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            using (DependencyInjectionServices dis = DependencyInjectionHandler.GetServiceProvider(builder).GetService<DependencyInjectionServices>())
            {
                //IResourceResult<EBuilderCode> res = dis.ResourceHandler.GetResourceResult<EBuilderCode>(EBuilderCode.azerty, CultureInfo.CurrentCulture);

                try
                {
                    //AssemblyTitleAttribute ass = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>();
                    //string filename = Path.Combine(builder.GetSection("resourceFilePath").Value, ass.Title + ".default.json");
                    //dis.ResourceHandler.Export<EBuilderCode>(filename);
                    NullReferenceException exception = dis.LocalizableLogHandler.ProvideException<NullReferenceException, EBuilderCode>(EBuilderCode.azerty);
                    throw exception;
                }
                catch (Exception e)
                {
                    dis.LocalizableLogHandler.LocalizableError(e);
                    Console.Read();
                }
            }
        }
    }
}
