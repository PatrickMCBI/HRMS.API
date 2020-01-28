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
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);

            SqlCommand sqlCommand = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sp, con);

            sqlCommand.Parameters.AddRange(sqlParameters.ToArray());

            DataSet dataSet = new DataSet();

            con.Open();

            sqlDataAdapter.Fill(dataSet);

            con.Close();

            return dataSet;
        }
    }
}
