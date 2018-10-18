using AspieTech.DependencyInjection.Abstractions.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AspieTech.Repository.Tools
{
    public class StoredProcedure<TEntity> : IStoredProcedure<TEntity>
        where TEntity : class
    {
        #region Public properties

        #endregion

        #region Private properties
        private string name;
        private TEntity resultType;
        private IEnumerable<SqlParameter> parameters;
        #endregion

        #region Constructors
        public StoredProcedure(string name, TEntity resultType, params SqlParameter[] parameters)
        {
            this.name = name;
            this.resultType = resultType;
            this.parameters = parameters.AsEnumerable<SqlParameter>();
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
        }

        public TEntity ResultType
        {
            get
            {
                return this.resultType;
            }
        }

        public IEnumerable<SqlParameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }
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
