using AspieTech.Model.Enumerations;
using System;
using System.Linq;
using System.Reflection;

namespace AspieTech.LocalizationHandler.Attributes
{
    public class ResourceSerialDetailsAttribute : Attribute
    {
        #region Private properties
        private ESolution solution;
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="solution">The solution accorded to this resource.</param>
        public ResourceSerialDetailsAttribute(ESolution solution)
        {
            this.solution = solution;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        /// <summary>
        /// The solution accorded to this resource.
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
        public static ResourceSerialDetailsAttribute GetDetails<T>(T resourceSerial) where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");

                MemberInfo memberInfo = typeof(T).GetMember(resourceSerial.ToString()).FirstOrDefault();

                if (memberInfo != null)
                {
                    ResourceSerialDetailsAttribute attribute = memberInfo
                                .GetCustomAttribute(typeof(ResourceSerialDetailsAttribute), false)
                                as ResourceSerialDetailsAttribute;
                    return attribute;
                }

                return null;
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