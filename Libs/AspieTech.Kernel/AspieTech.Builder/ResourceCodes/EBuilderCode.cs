using AspieTech.Localization.Attributes;
using AspieTech.Localization.Enumerations;

namespace AspieTech.Builder.ResourceCodes
{
    [LocalizationUtilityAttribute(typeof(Resources.AspieTech_Builder))]
    public enum EBuilderCode
    {
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        azerty,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        ytreza
    }
}
