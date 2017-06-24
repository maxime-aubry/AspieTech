using AspieTech.LocalizationHandler;
using AspieTech.LocalizationHandler.ResourceSerials;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceHandler provider = new ResourceHandler();
            string translation = provider.GetString<EKernelCodes>(EKernelCodes.x54x5, CultureInfo.CurrentCulture);
            provider.Export();
        }
    }
}
