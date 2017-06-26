using AspieTech.LocalizationHandler.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.LocalizationHandler.Attributes
{
    public class ResourceSerialDetailsAttribute : Attribute
    {
        #region Private properties
        private ESolutionPart solutionPart;
        #endregion

        #region Constructors
        public ResourceSerialDetailsAttribute(ESolutionPart solutionPart)
        {
            this.solutionPart = solutionPart;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public ESolutionPart MyProperty
        {
            get
            {
                return this.solutionPart;
            }
            set
            {
                this.solutionPart = value;
            }
        }

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        public static ResourceSerialDetailsAttribute GetDetails<T>(T resourceSerial) where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");
                
                MemberInfo memberInfo = typeof(T).GetMember(resourceSerial.ToString()).FirstOrDefault();

                if (memberInfo == null)
                    throw new ArgumentException("La valeur passée en paramètre n'appartient pas au type T.");

                ResourceSerialDetailsAttribute details =
                            memberInfo
                            .GetCustomAttribute(typeof(ResourceSerialDetailsAttribute), false)
                            as ResourceSerialDetailsAttribute;

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