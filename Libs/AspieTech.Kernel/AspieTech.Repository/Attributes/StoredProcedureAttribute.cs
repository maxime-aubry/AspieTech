using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AspieTech.Repository.Attributes
{
    public class StoredProcedureAttribute : Attribute
    {
        #region Public properties

        #endregion

        #region Private properties
        private string signature;
        private static readonly string pattern = @"^\[(?<name>.+)\](?<parameters>\@.+ .+ .+)";
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
        public void GenerateStoredProcedure(out string name, out SqlParameter[] parameters)
        {
            name = null;
            parameters = null;

            Match matches = Regex.Match(this.signature, StoredProcedureAttribute.pattern, RegexOptions.IgnoreCase);
            name = matches.Groups["name"].Value;


            //BigInt|Binary|Bit|Char|DateTime|Decimal|Float|Image|Int|Money|NChar|NText|NVarChar|Real|UniqueIdentifier|SmallDateTime|SmallInt|SmallMoney|Text|Timestamp|TinyInt|VarBinary|VarChar|Variant|Xml|Udt|Structured|Date|Time|DateTime2|DateTimeOffset
            string[] test = Regex.Split(matches.Groups["parameters"].Value, @"(,)");

            SqlParameter test = new SqlParameter("monparametre", SqlDbType., 10)
            {
                Direction = ParameterDirection.Input
            };
        }
        #endregion

        #region Private methods

        #endregion
    }
}
