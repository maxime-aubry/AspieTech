using System;
using System.Collections.Generic;
using System.Linq;

namespace AspieTech.Engine.Handlers
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
        #endregion

        #region Private methods

        #endregion
    }
}