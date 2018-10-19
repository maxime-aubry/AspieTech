using AspieTech.Utils.Enums;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace AspieTech.Repository.Attributes
{
    public class StoredProcedureAttribute : Attribute
    {
        #region Public properties

        #endregion

        #region Private properties
        private string signature;
        private const string commandPattern = @"^\[(?<name>.+)\](?<parameters>.+)$";
        private const string parametersPattern = @"^\s*@{1}(?<parameterName>.+)\s(?<dbType>BigInt|Binary|Bit|Char|DateTime|Decimal|Float|Image|Int|Money|NChar|NText|NVarChar|Real|UniqueIdentifier|SmallDateTime|SmallInt|SmallMoney|Text|Timestamp|TinyInt|VarBinary|VarChar|Variant|Xml|Udt|Structured|Date|Time|DateTime2|DateTimeOffset)\s(?<direction>Input|Output|InputOutput|ReturnValue)$";
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for Stored Procedure attribute
        /// </summary>
        /// <param name="signature"></param>
        public StoredProcedureAttribute(string signature)
        {
            this.signature = signature;
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
        public void GenerateStoredProcedure(out string name, out SqlParameter[] sqlParameters)
        {
            try
            {
                // initialize output parameters
                name = null;
                sqlParameters = new SqlParameter[] { };

                // split signature to extract stored procedure name and parameters part
                string parameters = null;
                this.DivideSignature(out name, out parameters);
                
                // build Sql Parameters from the string
                if (!string.IsNullOrEmpty(parameters))
                    this.BuildToSqlParameters(parameters, out sqlParameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Private methods
        private void DivideSignature(out string name, out string parameters)
        {
            try
            {
                Match matches = Regex.Match(this.signature, StoredProcedureAttribute.commandPattern, RegexOptions.IgnoreCase);
                name = matches.Groups["name"].Value;
                parameters = matches.Groups["parameters"].Value;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void BuildToSqlParameters(string parameters, out SqlParameter[] sqlParameters)
        {
            try
            {
                sqlParameters = new SqlParameter[] { };
                
                foreach (string parameter in parameters.Split(','))
                {
                    Match matches = Regex.Match(parameter, StoredProcedureAttribute.parametersPattern, RegexOptions.IgnoreCase);

                    if (!matches.Groups.Any(g => g.Name == "parameterName"))
                        throw new ArgumentException("");

                    if (!matches.Groups.Any(g => g.Name == "dbType"))
                        throw new ArgumentException("");

                    if (!matches.Groups.Any(g => g.Name == "direction"))
                        throw new ArgumentException("");

                    if (!matches.Groups["parameterName"].Success)
                        throw new ArgumentException("");

                    if (!matches.Groups["dbType"].Success)
                        throw new ArgumentException("");

                    if (!matches.Groups["direction"].Success)
                        throw new ArgumentException("");
                    
                    string parameterName = matches.Groups["parameterName"].Value;
                    DbType dbType = EnumHandler.GetEnumFromString<DbType>(matches.Groups["dbType"].Value);
                    ParameterDirection direction = EnumHandler.GetEnumFromString<ParameterDirection>(matches.Groups["direction"].Value);

                    SqlParameter sqlParameter = new SqlParameter()
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
