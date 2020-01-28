using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public class HRMSDBDL : IHRMSDBDAL
    {
        public DataTable Command(string sp, List<SqlParameter> sqlParameters, string command)
        {
            sqlParameters.Add(new SqlParameter("@command", SqlDbType.VarChar, 10)
            {

                Direction = ParameterDirection.Input,

                Value = command

            });

            return this.Select(sp, sqlParameters).Tables[0];
        }

        public DataSet Select(string sp, List<SqlParameter> sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.connection))
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
           //return null;
        }
    }
}
