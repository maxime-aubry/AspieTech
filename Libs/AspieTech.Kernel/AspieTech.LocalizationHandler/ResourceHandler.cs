using AspieTech.LocalizationHandler.Attributes;
using AspieTech.Model.Attributes;
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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspieTech.LocalizationHandler
{
    public class ResourceHandler
    {
        #region Private properties
        private Object locker = new Object();
        private Regex regex = new Regex(@"^(?<dictionaryName>\D+).(?<languageName>[a-z]{2}).resx$");
        #endregion

        #region Constructors
        public ResourceHandler()
        {

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
        /// <summary>
        /// Get a string from the dictionary.
        /// </summary>
        /// <typeparam name="T">The resource serial type.</typeparam>
        /// <param name="resource">The resource serial.</param>
        /// <param name="culture">The user cutlure.</param>
        /// <returns></returns>
        public string GetString<T>(T resource, CultureInfo culture)
        {
            try
            {
                ResourceSerialDetailsAttribute resourceSerialDetails = ResourceSerialDetailsAttribute.GetDetails<T>(resource);
                SolutionDetailsAttribute solutionDetails = SolutionDetailsAttribute.GetDetails(resourceSerialDetails.Solution);

                string path = string.Format("{0}.{1}.{2}", typeof(ResourceHandler).Namespace, "i18nResources", solutionDetails.ResourceName);
                ResourceManager rm = new ResourceManager(path, typeof(ResourceHandler).Assembly);
                string result = rm.GetString(resource.ToString(), culture);
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
                string path = ConfigurationManager.AppSettings["i181ResourcesPath"];
                IEnumerable<string> files = Directory.GetFiles(path, "*.resx");
                IDictionary<string, IDictionary<string, string>> dictionaries = this.GetDictionaries(files);

                Parallel.ForEach(dictionaries,
                             dictionary =>
                             {
                                 lock (this.locker)
                                 {
                                     JObject serializedDictionary = this.SerializeDictionary(dictionary);
                                     this.SaveDictionary(dictionary.Key, serializedDictionary);
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
        /// Get dictionaries, grouped by dictionary name.
        /// </summary>
        /// <param name="files">List of files pathes.</param>
        /// <returns></returns>
        private IDictionary<string, IDictionary<string, string>> GetDictionaries(IEnumerable<string> files)
        {
            try
            {
                IDictionary<string, IDictionary<string, string>> dictionary = new Dictionary<string, IDictionary<string, string>>();

                foreach (string filepath in files)
                {
                    string filename = Path.GetFileName(filepath);
                    Match match = regex.Match(filename);

                    if (match.Success)
                    {
                        string dictionaryName = string.Concat(match.Groups["dictionaryName"].Value, ".json");
                        string languageName = match.Groups["languageName"].Value;
                        if (!dictionary.ContainsKey(dictionaryName))
                            dictionary[dictionaryName] = new Dictionary<string, string>();
                        dictionary[dictionaryName][languageName] = filepath;
                    }
                }

                dictionary = dictionary.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
                return dictionary;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Serialize a dictionary.
        /// </summary>
        /// <param name="dictionary">Dictionary to serialize.</param>
        /// <returns></returns>
        private JObject SerializeDictionary(KeyValuePair<string, IDictionary<string, string>> dictionary)
        {
            try
            {
                JObject serializedDictionary = new JObject();

                // Browse each part of dictionary (en, fr...)
                foreach (KeyValuePair<string, string> dictionaryParts in dictionary.Value)
                {
                    using (ResXResourceReader resxReader = new ResXResourceReader(dictionaryParts.Value))
                    {
                        // Add language to the dictionary part
                        serializedDictionary[dictionaryParts.Key] = new JObject();
                        
                        foreach (DictionaryEntry entry in resxReader)
                        {
                            serializedDictionary[dictionaryParts.Key][entry.Key] = entry.Value.ToString();
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
