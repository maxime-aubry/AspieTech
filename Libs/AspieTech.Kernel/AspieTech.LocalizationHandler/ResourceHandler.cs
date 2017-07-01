using AspieTech.BridgeHandler;
using AspieTech.Engine.Handlers;
using AspieTech.LocalizationHandler.Attributes;
using AspieTech.LocalizationHandler.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
        private Object locker = new Object();
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
        public bool IsUserInterfaceResource<T>(T resourceSerial)
            where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<T>();

                if (localizationUtility == null)
                    throw new ArgumentException("La type doit être une resource de traduction.");

                ResourceSerialDetailsAttribute details = ResourceSerialDetailsAttribute.GetDetails<T>(resourceSerial);

                bool result = (details.SolutionPart == ESolutionPart.UserInterface);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool IsClientErrorResource<T>(T resourceSerial)
            where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<T>();

                if (localizationUtility == null)
                    throw new ArgumentException("La type doit être une resource de traduction.");

                ResourceSerialDetailsAttribute details = ResourceSerialDetailsAttribute.GetDetails<T>(resourceSerial);

                bool result = (details.SolutionPart == ESolutionPart.ClientError);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool IsServerErrorResource<T>(T resourceSerial)
            where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<T>();

                if (localizationUtility == null)
                    throw new ArgumentException("La type doit être une resource de traduction.");

                ResourceSerialDetailsAttribute details = ResourceSerialDetailsAttribute.GetDetails<T>(resourceSerial);

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
        public string GetString<T>(T resourceSerial, CultureInfo culture, params object[] args)
            where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                ResourceManager rm = this.GetResourceManager<T>();
                string result = rm.GetString(resourceSerial.ToString(), culture);

                if (args != null
                    && args.Any())
                    result = string.Format(result, args);

                return result;
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
                IEnumerable<Type> enumerations = this.GetResourceSerialTypes();

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
        /// <param name="resourceSerial">Thez resource serial.</param>
        /// <returns></returns>
        private ResourceManager GetResourceManager<T>()
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Le type T doit être une énumération.");

            LocalizationUtilityAttribute localizationUtility = LocalizationUtilityAttribute.GetDetails<T>();
            PropertyInfo propertyInfo = localizationUtility.ResourceType.GetProperty("ResourceManager", BindingFlags.Public | BindingFlags.Static);
            ResourceManager resourceManager = propertyInfo.GetValue(null, null) as ResourceManager;
            return resourceManager;
        }

        /// <summary>
        /// Get every resource serial type in the project.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Type> GetResourceSerialTypes()
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
        private JObject SerializeDictionary<T>(ResourceManager resourceManager)
            where T : struct, IConvertible
        {
            try
            {
                IEnumerable<T> resourceSerials = EnumHandler.GetValues<T>();

                JObject serializedDictionary = new JObject();

                foreach (CultureInfo culture in this.cultures)
                {
                    serializedDictionary[culture.TwoLetterISOLanguageName] = new JObject();
                    
                    foreach (T resourceSerial in resourceSerials)
                    {
                        if (!this.IsServerErrorResource<T>(resourceSerial))
                        {
                            string message = resourceManager.GetString(resourceSerial.ToString(), culture);
                            serializedDictionary[culture.TwoLetterISOLanguageName][resourceSerial.ToString()] = message;
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