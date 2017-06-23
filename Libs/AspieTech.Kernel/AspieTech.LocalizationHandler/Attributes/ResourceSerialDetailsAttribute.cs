using AspieTech.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.LocalizationHandler.Attributes
{
    class ResourceSerialDetailsAttribute : Attribute
    {
        #region Private properties
        private ESolution solution;
        #endregion

        #region Constructors
        public ResourceSerialDetailsAttribute(ESolution solution)
        {
            this.solution = solution;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
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
        public static ResourceSerialDetailsAttribute GetDetails<T>(T resourceSerial)
        {
            try
            {
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
