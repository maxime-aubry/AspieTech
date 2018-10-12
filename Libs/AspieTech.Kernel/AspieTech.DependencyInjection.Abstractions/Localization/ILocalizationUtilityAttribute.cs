using System;

namespace AspieTech.Localization.Attributes
{
    public interface ILocalizationUtilityAttribute
    {
        Type ResourceManagerType { get; set; }
    }
}