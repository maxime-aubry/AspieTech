using AspieTech.BridgeHandler.LocalizationHandler;
using AspieTech.Engine.Handlers;
using AspieTech.LocalizationHandler.Attributes;
using AspieTech.LocalizationHandler.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace AspieTech.LocalizationHandler
{
    public class ResourceHandler : IResourceHandler
    {
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

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<TResourceCode>();

                if (localizationUtility == null)
                    throw new ArgumentException("La type doit être une resource de traduction.");

                ResourceCodeDetailsAttribute details = ResourceCodeDetailsAttribute.GetDetails<TResourceCode>(resourceCode);

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

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<TResourceCode>();

                if (localizationUtility == null)
                    throw new ArgumentException("La type doit être une resource de traduction.");

                ResourceCodeDetailsAttribute details = ResourceCodeDetailsAttribute.GetDetails<TResourceCode>(resourceCode);

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

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<TResourceCode>();

                if (localizationUtility == null)
                    throw new ArgumentException("La type doit être une resource de traduction.");

                ResourceCodeDetailsAttribute details = ResourceCodeDetailsAttribute.GetDetails<TResourceCode>(resourceCode);

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

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<TResourceCode>();

                if (localizationUtility == null)
                    throw new ArgumentException("");

                ResourceCodeDetailsAttribute details = ResourceCodeDetailsAttribute.GetDetails<TResourceCode>(resourceCode);
                ResourceManager rm = this.GetResourceManager<TResourceCode>();

                IResourceInfo<TResourceCode> resourceInfo = new ResourceInfo<TResourceCode>(resourceCode, args);
                IResourceResult<TResourceCode> resourceResult = null;

                // Set result
                if (details.ResourceType == EResourceType.Object)
                    resourceResult = new ResourceResult<TResourceCode>(resourceInfo, rm.GetObject(resourceCode.ToString()));
                if (details.ResourceType == EResourceType.Stream)
                    resourceResult = new ResourceResult<TResourceCode>(resourceInfo, rm.GetStream(resourceCode.ToString()));
                if (details.ResourceType == EResourceType.String)
                    resourceResult = new ResourceResult<TResourceCode>(resourceInfo, rm.GetString(resourceCode.ToString()));

                // Format result
                if (details.ResourceType == EResourceType.String
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

        /// <summary>
        /// Export each dictionary into a Json file.
        /// </summary>
        public void Export()
        {
            try
            {
                IEnumerable<Type> enumerations = this.GetResourceCodeTypes();

                Parallel.ForEach(enumerations,
                    enumeration =>
                    {
                        lock (this.locker)
                        {
                            // get resource manager
                            ResourceManager resourceManager = null;
                            {
                                MethodInfo method = typeof(ResourceHandler).GetMethod("GetResourceManager", BindingFlags.NonPublic | BindingFlags.Instance);
                                MethodInfo genericMethod = method.MakeGenericMethod(enumeration);
                                resourceManager = genericMethod.Invoke(this, null) as ResourceManager;
                            }

                            // serializing
                            JObject serializedDictionary = null;
                            {
                                MethodInfo method = typeof(ResourceHandler).GetMethod("SerializeDictionary", BindingFlags.NonPublic | BindingFlags.Instance);
                                MethodInfo genericMethod = method.MakeGenericMethod(enumeration);
                                serializedDictionary = genericMethod.Invoke(this, new object[] { resourceManager }) as JObject;
                            }

                            // saving
                            this.SaveDictionary(enumeration.Name + ".json", serializedDictionary);
                        }
                    });
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

            LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<TResourceCode>();
            PropertyInfo propertyInfo = localizationUtility.ResourceType.GetProperty("ResourceManager", BindingFlags.Public | BindingFlags.Static);
            ResourceManager resourceManager = propertyInfo.GetValue(null, null) as ResourceManager;
            return resourceManager;
        }

        /// <summary>
        /// Get every resource serial type in the project.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Type> GetResourceCodeTypes()
        {
            try
            {
                IEnumerable<Type> types = new List<Type>();

                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type type in assembly.GetTypes())
                    {
                        LocalizationUtilityAttribute localizationUtility = type.GetCustomAttribute<LocalizationUtilityAttribute>();

                        if (localizationUtility != null)
                            types = types.Concat(new[] { type });
                    }
                }

                return types;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Serialize dictionary.
        /// </summary>
        /// <param name="resourceManager"></param>
        /// <returns></returns>
        private JObject SerializeDictionary<TResourceCode>(ResourceManager resourceManager)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                IEnumerable<TResourceCode> resourceCodes = EnumHandler.GetValues<TResourceCode>();

                JObject serializedDictionary = new JObject();

                foreach (CultureInfo culture in this.cultures)
                {
                    serializedDictionary[culture.TwoLetterISOLanguageName] = new JObject();
                    
                    foreach (TResourceCode resourceCode in resourceCodes)
                    {
                        if (!this.IsServerErrorResource<TResourceCode>(resourceCode))
                        {
                            string message = resourceManager.GetString(resourceCode.ToString(), culture);
                            serializedDictionary[culture.TwoLetterISOLanguageName][resourceCode.ToString()] = message;
                        }
                    }
                }
                
                return serializedDictionary;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Saves the serialized dictionary into a Json file.
        /// </summary>
        /// <param name="filename">The file name.</param>
        /// <param name="dictionary">The dictionary so save.</param>
        private void SaveDictionary(string filename, JObject dictionary)
        {
            try
            {
                string path = Path.Combine(ConfigurationManager.AppSettings["i181JsonResourcesPath"], filename);

                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    outputFile.Write(dictionary.ToString(Formatting.Indented));
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}