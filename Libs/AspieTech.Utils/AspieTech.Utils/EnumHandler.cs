using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspieTech.Utils.Enums
{
    public static class EnumHandler
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
        public static IEnumerable<TEnum> GetValues<TEnum>()
            where TEnum : struct, IConvertible
        {
            try
            {
                if (!typeof(TEnum).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                IEnumerable<TEnum> items = new List<TEnum>();

                foreach (Enum item in Enum.GetValues(typeof(TEnum)))
                {
                    TEnum parsedEnum = (TEnum)(object)item;
                    items = items.Concat<TEnum>(new[] { parsedEnum });
                }

                return items;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static TAttribute GetCustomAttributeOnType<TEnum, TAttribute>()
            where TEnum : struct, IConvertible
            where TAttribute : Attribute
        {
            IEnumerable<TAttribute> attributes = EnumHandler.GetCustomAttributesOnType<TEnum, TAttribute>();
            TAttribute attribute = attributes.FirstOrDefault();
            return attribute;
        }

        public static IEnumerable<TAttribute> GetCustomAttributesOnType<TEnum, TAttribute>()
            where TEnum : struct, IConvertible
            where TAttribute : Attribute
        {
            try
            {
                if (!typeof(TEnum).IsEnum)
                    throw new ArgumentException($"Le type {typeof(TEnum).FullName} doit être une énumération.");

                IEnumerable<TAttribute> attributes = typeof(TEnum).GetCustomAttributes<TAttribute>(false);
                return attributes;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static TAttribute GetCustomAttributeOnValue<TEnum, TAttribute>(TEnum value)
            where TEnum : struct, IConvertible
            where TAttribute : Attribute
        {
            IEnumerable<TAttribute> attributes = EnumHandler.GetCustomAttributesOnValue<TEnum, TAttribute>(value);
            TAttribute attribute = attributes.FirstOrDefault();
            return attribute;
        }

        public static IEnumerable<TAttribute> GetCustomAttributesOnValue<TEnum, TAttribute>(TEnum value)
            where TEnum : struct, IConvertible
            where TAttribute : Attribute
        {
            try
            {
                if (!typeof(TEnum).IsEnum)
                    throw new ArgumentException($"Le type {typeof(TEnum).FullName} doit être une énumération.");

                MemberInfo memberInfo = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

                if (memberInfo == null)
                    throw new ArgumentException($"La valeur passée en paramètre n'appartient pas au type {typeof(TEnum).FullName}.");

                IEnumerable<TAttribute> attributes = memberInfo.GetCustomAttributes<TAttribute>(false);
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
