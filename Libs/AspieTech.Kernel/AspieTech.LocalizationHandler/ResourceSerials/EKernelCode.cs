using AspieTech.LocalizationHandler.Attributes;
using AspieTech.LocalizationHandler.Enumerations;
using AspieTech.LocalizationHandler.i18nResources;
using AspieTech.Model.Enumerations;

namespace AspieTech.LocalizationHandler.ResourceSerials
{
    [LocalizationUtility(ESolution.Kernel, typeof(AspieTech_Kernel))]
    public enum EKernelCode
    {
        [ResourceSerialDetails(ESolutionPart.UserInterface, EResourceType.String)]
        x54x5
    }
}