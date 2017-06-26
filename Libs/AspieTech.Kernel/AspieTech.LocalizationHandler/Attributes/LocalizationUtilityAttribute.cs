using AspieTech.Model.Enumerations;
using System;
using System.Reflection;

namespace AspieTech.LocalizationHandler.Attributes
{
    public class LocalizationUtilityAttribute : Attribute
    {
        #region Private properties
        private ESolution solution;
        private Type resourceType;
        #endregion

        #region Constructors
        public LocalizationUtilityAttribute(ESolution solution, Type resourceType)
        {
            this.solution = solution;
            this.resourceType = resourceType;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        /// <summary>
        /// The solution linked to this resource.
        /// </summary>
        public ESolution Solution
        {
            get
            {
                return this.solution;
            }
            set
            {
                this.solution = value;
            }
        }

        /// <summary>
        /// The resource manager type
        /// </summary>
        public Type ResourceType
        {
            get
            {
                return this.resourceType;
            }
            set
            {
                this.resourceType = value;
            }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        /// <summary>
        /// Get details provided to this resource.
        /// </summary>
        /// <typeparam name="T">The resource type.</typeparam>
        /// <param name="resourceSerial">The resource serial.</param>
        /// <returns></returns>
        public static LocalizationUtilityAttribute GetDetails<T>() where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = typeof(T).GetCustomAttribute<LocalizationUtilityAttribute>(false);

                if (localizationUtility == null)
                    throw new NullReferenceException("L'énumération n'est pas un accesseur à des ressources de traduction.");

                return localizationUtility;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion

        #region Private methods

        #endregion
    }
}