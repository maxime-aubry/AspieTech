using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspieTech.Utils
{
    public static class AttributeHandler
    {
        #region Public properties

        #endregion

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
        public static TAttribute GetCustomAttributeOnType<TClass, TAttribute>()
            where TClass : class
            where TAttribute : Attribute
        {
            IEnumerable<TAttribute> attributes = AttributeHandler.GetCustomAttributesOnType<TClass, TAttribute>();
            TAttribute attribute = attributes.FirstOrDefault();
            return attribute;
        }

        public static IEnumerable<TAttribute> GetCustomAttributesOnType<TClass, TAttribute>()
            where TClass : class
            where TAttribute : Attribute
        {
            try
            {
                if (!typeof(TClass).IsClass)
                    throw new ArgumentException($"Le type {typeof(TClass).FullName} doit être une classe.");

                IEnumerable<TAttribute> attributes = typeof(TClass).GetCustomAttributes(typeof(TAttribute), false).Cast<TAttribute>();
                return attributes;
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
