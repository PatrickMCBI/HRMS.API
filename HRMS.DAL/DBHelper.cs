using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public interface IDBHelper
    {
        string ConnectionString
        {
            get;

        }

        //int GetRecords(string sp, SqlParameter[] sqlParameters);

        //int GetRecords(string sp, List<SqlParameter> sqlParameters);

        //DataSet GetRecords(string sp, SqlParameter[] sqlParameters);

        DataSet GetRecords(string sp, List<SqlParameter> sqlParameters);

        DataSet Command(string sp, string commandType, List<SqlParameter> sqlParameters);

        DataSet GetRecords(string sp);


    }
    public class DBHelper : IDBHelper
    {
        public string ConnectionString
        {
            //get { return ConfigurationManager.ConnectionStrings["con"].ConnectionString; }
            get
            {
                /*if (HRMS.DAL.Properties.Settings.Default.isTest)
                    return HRMS.DAL.Properties.Settings.Default.connectionStringTest;*/

                return HRMS.DAL.Properties.Settings.Default.connectionString;
            }
        }

        public DataSet Command(string sp, string commandType, List<SqlParameter> sqlParameters)
        {
            sqlParameters.Add(new SqlParameter { ParameterName = "@command", Value = commandType.ToString() });

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return GetRecords(sp, sqlParameters);
            }
        }

        public DataSet GetRecords(string sp, List<SqlParameter> sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp, connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (sqlParameters.Count != 0)
                    da.SelectCommand.Parameters.AddRange(sqlParameters.ToArray());
                da.Fill(ds);
                da.Dispose();
                return ds;
            }
        }
        public DataSet GetRecords(string sp)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                return GetRecords(sp, new List<SqlParameter>());
            }
        }
    }
}
