using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.LocalizationHandler.Enumerations
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ESolutionPart
    {
        UserInterface,
        ClientError,
        ServerError
    }
}