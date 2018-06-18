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

        #endregion

        #region Private methods

        #endregion
    }
}