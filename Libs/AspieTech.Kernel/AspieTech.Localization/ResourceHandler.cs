using AspieTech.DependencyInjection.Abstractions.Localization.Interfaces;
using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;
using AspieTech.Localization.Attributes;
using AspieTech.Localization.Enumerations;
using AspieTech.Utils.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace AspieTech.Localization
{
    public class ResourceHandler : IResourceHandler
    {
        #region Public properties
        public ILocalizableLogHandler LocalizableLogHandler { get; set; }
        #endregion

        #region Private properties
        private object locker = new object();
        private IEnumerable<CultureInfo> cultures;
        #endregion

        #region Constructors
        public ResourceHandler()
        {
            this.cultures = new List<CultureInfo>()
            {
                new CultureInfo("en"),
                new CultureInfo("fr")
            };
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        public bool IsUserInterfaceResource<TResourceCode>(TResourceCode resourceCode)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type TResourceCode doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = EnumHandler.GetCustomAttributesOnType<TResourceCode, LocalizationUtilityAttribute>();

                if (localizationUtility == null)
                    throw new ArgumentException("Le type doit être une ressource de traduction.");

                ResourceCodeDetailsAttribute details = EnumHandler.GetCustomAttributesOnValue<TResourceCode, ResourceCodeDetailsAttribute>(resourceCode);

                bool result = (details.SolutionPart == ESolutionPart.UserInterface);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool IsClientErrorResource<TResourceCode>(TResourceCode resourceCode)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type TResourceCode doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = EnumHandler.GetCustomAttributesOnType<TResourceCode, LocalizationUtilityAttribute>();

                if (localizationUtility == null)
                    throw new ArgumentException("Le type doit être une ressource de traduction.");

                ResourceCodeDetailsAttribute details = EnumHandler.GetCustomAttributesOnValue<TResourceCode, ResourceCodeDetailsAttribute>(resourceCode);

                bool result = (details.SolutionPart == ESolutionPart.ClientError);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool IsServerErrorResource<TResourceCode>(TResourceCode resourceCode)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type TResourceCode doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = EnumHandler.GetCustomAttributesOnType<TResourceCode, LocalizationUtilityAttribute>();

                if (localizationUtility == null)
                    throw new ArgumentException("Le type doit être une ressource de traduction.");

                ResourceCodeDetailsAttribute details = EnumHandler.GetCustomAttributesOnValue<TResourceCode, ResourceCodeDetailsAttribute>(resourceCode);

                bool result = (details.SolutionPart == ESolutionPart.ServerError);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a string from the dictionary.
        /// </summary>
        /// <typeparam name="T">The resource serial type.</typeparam>
        /// <param name="resource">The resource serial.</param>
        /// <param name="culture">The user cutlure.</param>
        /// <returns></returns>
        public IResourceResult<TResourceCode> GetResourceResult<TResourceCode>(TResourceCode resourceCode, CultureInfo culture, params object[] args)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type TResourceCode doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = EnumHandler.GetCustomAttributesOnType<TResourceCode, LocalizationUtilityAttribute>();

                if (localizationUtility == null)
                    throw new ArgumentException("Le type doit être une ressource de traduction.");

                ResourceCodeDetailsAttribute resourceCodeDetails = EnumHandler.GetCustomAttributesOnValue<TResourceCode, ResourceCodeDetailsAttribute>(resourceCode);
                ResourceManager rm = this.GetResourceManager<TResourceCode>();

                IResourceResult <TResourceCode> resourceResult = null;

                // Set result
                if (resourceCodeDetails.ResourceType == EResourceType.Object)
                    resourceResult = new ResourceResult<TResourceCode>(localizationUtility, resourceCodeDetails, resourceCode, rm.GetObject(resourceCode.ToString()));
                if (resourceCodeDetails.ResourceType == EResourceType.Stream)
                    resourceResult = new ResourceResult<TResourceCode>(localizationUtility, resourceCodeDetails, resourceCode, rm.GetStream(resourceCode.ToString()));
                if (resourceCodeDetails.ResourceType == EResourceType.String)
                    resourceResult = new ResourceResult<TResourceCode>(localizationUtility, resourceCodeDetails, resourceCode, rm.GetString(resourceCode.ToString()), args);
                
                // Format result
                if (resourceCodeDetails.ResourceType == EResourceType.String
                    && args != null
                    && args.Any())
                    resourceResult.StringContent = string.Format(resourceResult.StringContent, args);

                return resourceResult;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SetResourceResult<TResourceCode>(TResourceCode resourceCode, CultureInfo culture, string filename)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type TResourceCode doit être une énumération.");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Export each dictionary into a Json file.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource code</typeparam>
        /// <param name="path">the path of json file</param>
        public void Export<TResourceCode>(string filename)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type TResourceCode doit être une énumération.");

                ResourceManager rm = this.GetResourceManager<TResourceCode>();
                JObject serializedDictionary = this.SerializeDictionary<TResourceCode>(rm);

                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.Write(serializedDictionary.ToString(Formatting.Indented));
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Get resource manager from a resource serial.
        /// </summary>
        /// <typeparam name="T">The resource Type.</typeparam>
        /// <param name="resourceCode">Thez resource serial.</param>
        /// <returns></returns>
        private ResourceManager GetResourceManager<TResourceCode>()
            where TResourceCode : struct, IConvertible
        {
            if (!typeof(TResourceCode).IsEnum)
                throw new ArgumentException("Le type TResourceCode doit être une énumération.");

            LocalizationUtilityAttribute localizationUtility = EnumHandler.GetCustomAttributesOnType<TResourceCode, LocalizationUtilityAttribute>();
            PropertyInfo propertyInfo = localizationUtility.ResourceManagerType.GetProperty("ResourceManager", BindingFlags.Public | BindingFlags.Static);
            ResourceManager resourceManager = propertyInfo.GetValue(null, null) as ResourceManager;
            return resourceManager;
        }

        /// <summary>
        /// Serialize dictionary.
        /// </summary>
        /// <param name="resourceManager">the resource manager</param>
        /// <returns></returns>
        private JObject SerializeDictionary<TResourceCode>(ResourceManager resourceManager)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                JObject serializedDictionary = new JObject();

                foreach (CultureInfo culture in this.cultures)
                {
                    serializedDictionary[culture.TwoLetterISOLanguageName] = new JObject();

                    IEnumerable<TResourceCode> resourceCodes = EnumHandler.GetValues<TResourceCode>().Where(rc => !this.IsServerErrorResource<TResourceCode>(rc));

                    foreach (TResourceCode resourceCode in resourceCodes)
                    {
                        string message = resourceManager.GetString(resourceCode.ToString(), culture);
                        serializedDictionary[culture.TwoLetterISOLanguageName][resourceCode.ToString()] = message;
                    }
                }

                return serializedDictionary;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
