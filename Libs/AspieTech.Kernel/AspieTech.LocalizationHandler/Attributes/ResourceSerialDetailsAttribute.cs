using AspieTech.LocalizationHandler.Enumerations;
using System;
using System.Linq;
using System.Reflection;

namespace AspieTech.LocalizationHandler.Attributes
{
    public class ResourceSerialDetailsAttribute : Attribute
    {
        #region Private properties
        private ESolutionPart solutionPart;
        private EResourceType resourceType;
        #endregion

        #region Constructors
        public ResourceSerialDetailsAttribute(ESolutionPart solutionPart, EResourceType resourceType)
        {
            this.solutionPart = solutionPart;
            this.resourceType = resourceType;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public ESolutionPart SolutionPart
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
        
        public EResourceType ResourceType
        {
            get
            {
                return this.resourceType;
            }
            set
            {
                this.resourceType = value;
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