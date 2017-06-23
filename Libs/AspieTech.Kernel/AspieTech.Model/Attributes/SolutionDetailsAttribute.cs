using AspieTech.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.Model.Attributes
{
    public class SolutionDetailsAttribute : Attribute
    {
        #region Private properties
        private string name;
        private string resourceName;
        #endregion

        #region Constructors
        public SolutionDetailsAttribute(string name, string resourceName)
        {
            this.name = name;
            this.resourceName = resourceName;
        }
        #endregion

        #region Finalizers

        #endregion

        #region Getters & Setters
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string ResourceName
        {
            get
            {
                return this.resourceName;
            }
            set
            {
                this.resourceName = value;
            }
        }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods
        public static SolutionDetailsAttribute GetDetails(ESolution solution)
        {
            try
            {
                MemberInfo memberInfo = typeof(ESolution).GetMember(solution.ToString()).FirstOrDefault();

                if (memberInfo != null)
                {
                    SolutionDetailsAttribute attribute = 
                                memberInfo
                                .GetCustomAttribute(typeof(SolutionDetailsAttribute), false)
                                as SolutionDetailsAttribute;
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