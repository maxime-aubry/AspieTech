using System;
using System.Reflection;

namespace AspieTech.Localization.Attributes
{
    public class LocalizationUtilityAttribute : Attribute, ILocalizationUtilityAttribute
    {
        #region Private properties
        private Type resourceManagerType;
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="resourceManagerType">The resource manager type.</param>
        public LocalizationUtilityAttribute(Type resourceManagerType)
        {
            this.resourceManagerType = resourceManagerType;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters

        /// <summary>
        /// The resource manager type
        /// </summary>
        public Type ResourceManagerType
        {
            get { return this.resourceManagerType; }
            set { this.resourceManagerType = value; }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        ///// <summary>
        ///// Get details provided to this resource.
        ///// </summary>
        ///// <typeparam name="TResourceCode">The resource type.</typeparam>
        ///// <param name="resourceCode">The resource code.</param>
        ///// <returns></returns>
        //public static LocalizationUtilityAttribute GetDetails<TResourceCode>()
        //    where TResourceCode : struct, IConvertible
        //{
        //    try
        //    {
        //        if (!typeof(TResourceCode).IsEnum)
        //            throw new ArgumentException("Le type T doit être une énumération.");

        //        LocalizationUtilityAttribute localizationUtility = typeof(TResourceCode).GetCustomAttribute<LocalizationUtilityAttribute>(false);

        //        if (localizationUtility == null)
        //            throw new NullReferenceException("L'énumération n'est pas un accesseur à des ressources de traduction.");

        //        return localizationUtility;
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region Private methods

        #endregion
    }
}