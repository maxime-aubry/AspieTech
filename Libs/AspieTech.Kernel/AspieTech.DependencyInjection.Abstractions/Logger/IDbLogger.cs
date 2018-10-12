using System.Linq;
using System.Threading.Tasks;

namespace AspieTech.DependencyInjection.Abstractions.Logger.Interfaces
{
    public interface IDbLogger
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
        Task Create<TLogEventInfo>(TLogEventInfo logEventInfo);

        Task<IQueryable<ILogEventInfoEntity>> Read();
        #endregion

        #region Private methods

        #endregion
    }
}
