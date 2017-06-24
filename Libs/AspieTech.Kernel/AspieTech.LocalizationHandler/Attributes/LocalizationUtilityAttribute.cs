using System;
using System.Reflection;

namespace AspieTech.LocalizationHandler.Attributes
{
    public class LocalizationUtilityAttribute : Attribute
    {
        #region Private properties

        #endregion

        #region Constructors

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
        /// Inform about if this element is a resource utility.
        /// </summary>
        /// <typeparam name="T">The resource type.</typeparam>
        /// <returns></returns>
        public static bool IsLocalizationUtility<T>() where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                LocalizationUtilityAttribute localizationUtility = typeof(T).GetCustomAttribute<LocalizationUtilityAttribute>(false);
                bool isLocalizationUtility = (localizationUtility != null);
                return isLocalizationUtility;
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