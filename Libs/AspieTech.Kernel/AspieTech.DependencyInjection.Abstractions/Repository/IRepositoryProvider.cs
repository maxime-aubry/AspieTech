using AspieTech.DependencyInjection.Abstractions.Logger.Interfaces;

namespace AspieTech.DependencyInjection.Abstractions.Repository
{
    public interface IRepositoryProvider
    {
        #region Public properties

        #endregion

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
        IRepository Provide(string connectionString);
        #endregion

        #region Private methods

        #endregion
    }
}
