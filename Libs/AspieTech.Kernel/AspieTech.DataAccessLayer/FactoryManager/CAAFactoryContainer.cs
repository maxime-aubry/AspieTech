using AspieTech.BridgeHandler.DataAccessLayer;
using AspieTech.BridgeHandler.DataAccessLayer.Factories;
using AspieTech.DataAccessLayer.Factories;

namespace AspieTech.DataAccessLayer.FactoryManager
{
    public class CAAFactoryContainer : FactoryContainerBase, ICAAFactoryContainer
    {
        #region Private properties

        #endregion

        #region Constructors
        public CAAFactoryContainer()
            : base()
        {
            this.factories.Add(typeof(ILogEventInfoFactory), new LogEventInfoFactory());
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
        public ILogEventInfoFactory LogEventInfo
        {
            get { return this.GetFactory<ILogEventInfoFactory>(); }
        }
        #endregion

        #region Private methods

        #endregion
    }
}