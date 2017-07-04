using AspieTech.LocalizationHandler.Enumerations;
using System;
using System.Linq;
using System.Reflection;

namespace AspieTech.LocalizationHandler.Attributes
{
    public class ResourceCodeDetailsAttribute : Attribute
    {
        #region Private properties
        private ESolutionPart solutionPart;
        private EResourceType resourceType;
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="solutionPart">The solution part.</param>
        /// <param name="resourceType">The resource type.</param>
        public ResourceCodeDetailsAttribute(ESolutionPart solutionPart, EResourceType resourceType)
        {
            this.solutionPart = solutionPart;
            this.resourceType = resourceType;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        /// <summary>
        /// The solution part.
        /// </summary>
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
        
        /// <summary>
        /// The resource type.
        /// </summary>
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
        /// <summary>
        /// Get details provided for this resource.
        /// </summary>
        /// <typeparam name="TResourceCode">The resource type.</typeparam>
        /// <param name="resourceCode">The resource code.</param>
        /// <returns></returns>
        public static ResourceCodeDetailsAttribute GetDetails<TResourceCode>(TResourceCode resourceCode)
            where TResourceCode : struct, IConvertible
        {
            try
            {
                if (!typeof(TResourceCode).IsEnum)
                    throw new ArgumentException("Le type T doit être une énumération.");
                
                MemberInfo memberInfo = typeof(TResourceCode).GetMember(resourceCode.ToString()).FirstOrDefault();

                if (memberInfo == null)
                    throw new ArgumentException("La valeur passée en paramètre n'appartient pas au type T.");

                ResourceCodeDetailsAttribute details =
                            memberInfo
                            .GetCustomAttribute(typeof(ResourceCodeDetailsAttribute), false)
                            as ResourceCodeDetailsAttribute;

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