namespace AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces.Factories
{
    public interface ILogEventInfoFactory : IFactory
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
        void Insert<TLogEventInfo>(TLogEventInfo logEventInfo);
        #endregion

        #region Private methods

        #endregion
    }
}