using AspieTech.LocalizationHandler.Attributes;
using AspieTech.Model.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AspieTech.LocalizationHandler
{
    public class LocalizationProvider
    {
        #region Private properties

        #endregion

        #region Constructors
        public LocalizationProvider()
        {

        }
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
        public void GetString<T>(T resource, CultureInfo culture)
        {
            ResourceSerialDetailsAttribute resourceSerialDetails = ResourceSerialDetailsAttribute.GetDetails<T>(resource);
            SolutionDetailsAttribute solutionDetails = SolutionDetailsAttribute.GetDetails(resourceSerialDetails.Solution);
            
            string path = string.Format("{0}.{1}.{2}", typeof(LocalizationProvider).Namespace, "i18nResources", solutionDetails.ResourceName);
            ResourceManager rm = new ResourceManager("AspieTech.LocalizationHandler.i18nResources.AspieTech.Kernel", typeof(LocalizationProvider).Assembly);
            string test = rm.GetString("test", culture);
        }
        #endregion

        #region Private methods

        #endregion
    }
}
