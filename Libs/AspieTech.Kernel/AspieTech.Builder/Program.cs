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
            provider.Export();
        }
    }
}
