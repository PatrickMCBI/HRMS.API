using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DAL
{
    public interface IHRMSDBDAL
    {
        DataTable Command(string sp, List<SqlParameter> sqlParameters, string command);

        DataSet Select(string sp, List<SqlParameter> sqlParameters);
    }
}
