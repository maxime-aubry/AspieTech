using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AspieTech.Localization.Enumerations
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ESolutionPart
    {
        UserInterface,
        ClientError,
        ServerError
    }
}