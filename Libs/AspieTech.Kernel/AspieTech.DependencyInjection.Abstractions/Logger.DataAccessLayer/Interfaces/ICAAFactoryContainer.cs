using AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces.Factories;
using AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces;

namespace AspieTech.DependencyInjection.Abstractions.Logger.DataAccessLayer.Interfaces
{
    public interface ICAAFactoryContainer : IFactoryContainer
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
        ILogEventInfoFactory LogEventInfo { get; }
        #endregion

        #region Private methods

        #endregion
    }
}