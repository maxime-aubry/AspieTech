using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspieTech.Utils.Enums
{
    public static class EnumHandler
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

        public static TAttribute GetCustomAttributesOnType<TEnum, TAttribute>()
            where TEnum : struct, IConvertible
            where TAttribute : Attribute
        {
            try
            {
                if (!typeof(TEnum).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                TAttribute attribute = typeof(TEnum).GetCustomAttribute<TAttribute>(false);

                if (attribute == null)
                    throw new NullReferenceException("L'énumération n'est pas un accesseur à des ressources de traduction.");

                return attribute;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static TAttribute GetCustomAttributesOnValue<TEnum, TAttribute>(TEnum value)
            where TEnum : struct, IConvertible
            where TAttribute : Attribute
        {
            try
            {
                if (!typeof(TEnum).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                MemberInfo memberInfo = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

                if (memberInfo == null)
                    throw new ArgumentException("La valeur passée en paramètre n'appartient pas au type T.");

                TAttribute details =
                            memberInfo
                            .GetCustomAttribute(typeof(TAttribute), false)
                            as TAttribute;

                if (details == null)
                    throw new NullReferenceException("L'énumération n'est pas un accesseur à des ressources de traduction.");

                return details;
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
