using AspieTech.LocalizationHandler.Attributes;
using AspieTech.LocalizationHandler.Enumerations;
using AspieTech.LocalizationHandler.i18nResources;
using AspieTech.Model.Enumerations;

namespace AspieTech.LocalizationHandler.ResourceCodes
{
    [LocalizationUtility(ESolution.Kernel, typeof(AspieTech_Kernel))]
    public enum EKernelCode
    {
        #region
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIx0IO08HBPDT,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxXSAYE22OM6,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxZUXIGZ6VP3,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxPC0YDG3D1R,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxVIK357XKQJ,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxE0NEN6A21G,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxNLN9B4HDPV,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIx7PBNNNUA2M,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIx8XS0FWBOGC,
        [ResourceCodeDetails(ESolutionPart.UserInterface, EResourceType.String)]
        UIxT1LJ8RRX10,
        #endregion

        #region
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CExZYLA8236NF,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CEx960SECD2D4,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CEx0HXVYBUB1D,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CExTHXBE1OM9M,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CExEKAO5BNOC7,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CEx2J729WRZRJ,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CExJSMQSFH7BO,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CExOTZUP3IXB4,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CExC6SBLUBKHQ,
        [ResourceCodeDetails(ESolutionPart.ClientError, EResourceType.String)]
        CEx2MHJ1MIZYH,
        #endregion

        #region
        /// <summary>
        /// Provided T type must be an Enum.
        /// </summary>
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SExX4J4OSAG2G,
        /// <summary>
        /// Provided T type variable must be utility resource for linguistic module.
        /// </summary>
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SEx1HI324MZLC,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SEx10OKEDD12L,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SExRA8VJ47FOB,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SExXVGA3HF2GI,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SExJPBWK6YXBA,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SExJ9W0I290S5,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SEx4PH4MWT4KN,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SExC9ABNNBND8,
        [ResourceCodeDetails(ESolutionPart.ServerError, EResourceType.String)]
        SEx8RJJI382GP
        #endregion
    }
}