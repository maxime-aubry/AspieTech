using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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