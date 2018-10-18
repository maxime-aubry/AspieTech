using System.Collections.Generic;
using System.Data.SqlClient;

namespace AspieTech.DependencyInjection.Abstractions.Repository
{
    public interface IStoredProcedure<TEntity>
        where TEntity : class
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
        string Name { get; }
        TEntity ResultType { get; }
        IEnumerable<SqlParameter> Parameters { get; }
        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Public methods

        #endregion

        #region Private methods

        #endregion
    }
}
