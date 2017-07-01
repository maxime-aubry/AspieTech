using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static IEnumerable<T> GetValues<T>()
            where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                IEnumerable<T> items = new List<T>();

                foreach (Enum item in Enum.GetValues(typeof(T)))
                {
                    T parsedEnum = (T)(object)item;
                    items = items.Concat<T>(new[] { parsedEnum });
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
