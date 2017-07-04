using AspieTech.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.Model.Enumerations
{
    public enum ESolution
    {
        [SolutionDetailsAttribute("AspieTech CAA Handler")]
        CAAHandler,

        [SolutionDetailsAttribute("AspieTech Kernel")]
        Kernel
    }
}