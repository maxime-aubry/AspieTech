namespace AspieTech.BridgeHandler.DataAccessLayer
{
    public interface IFactoryContainer
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
        TFactory GetFactory<TFactory>() where TFactory : IFactory;
        #endregion

        #region Private methods

        #endregion
    }
}