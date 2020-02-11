using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.DAL;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using DL;
using HRMS.DL;

namespace HRMS.ApiBL
{
    public interface I_002g_hrmEmpSalaryBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        MessageViewDomain Command(_002h_hrmEmpSalaryAddOnBL body, Command insert);
        MessageViewDomain Command(_002g_hrmEmpSalaryDomain body, Command insert);
    }

    public class _002g_hrmEmpSalaryBL : Common.BaseBL, I_002g_hrmEmpSalaryBL<_002g_hrmEmpSalaryDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002g_hrmEmpSalaryDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empMasterId_002a", Value = projectDomain.empMasterId_002a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@salary", Value = projectDomain.salary, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@date", Value = projectDomain.date, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isCurrent", Value = projectDomain.isCurrent, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp002ghrmEmpSalaryCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002g_hrmEmpSalaryDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002g_hrmEmpSalaryDomain() { ID = id }, DL.Command.Delete);
        }

        public IEnumerable<_002g_hrmEmpSalaryDomain> Get()
        {
            return GetData(0);
        }

        public _002g_hrmEmpSalaryDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002g_hrmEmpSalaryDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002g_hrmEmpSalaryDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _001_invRefCategory1Domain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp002ghrmEmpSalarySelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002g_hrmEmpSalaryDomain>>(tabledata);

        }
    }
}
