using AspieTech.Model.Enumerations;
using System;
using System.Linq;
using System.Reflection;

namespace AspieTech.Model.Attributes
{
    public class SolutionDetailsAttribute : Attribute
    {
        #region Private properties
        private string name;
        #endregion

        #region Constructors
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="name">The solution name.</param>
        public SolutionDetailsAttribute(string name)
        {
            this.name = name;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        /// <summary>
        /// The solution name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        /// <summary>
        /// Get solution details.
        /// </summary>
        /// <param name="solution">The solution enumeration.</param>
        /// <returns></returns>
        public static SolutionDetailsAttribute GetDetails(ESolution solution)
        {
            try
            {
                MemberInfo memberInfo = typeof(ESolution).GetMember(solution.ToString()).FirstOrDefault();
                
                if (memberInfo == null)
                    throw new ArgumentException("La valeur passée en paramètre n'appartient pas au type ESolution.");

                SolutionDetailsAttribute details =
                            memberInfo
                            .GetCustomAttribute(typeof(SolutionDetailsAttribute), false)
                            as SolutionDetailsAttribute;

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