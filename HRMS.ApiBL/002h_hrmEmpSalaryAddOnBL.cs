using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.DAL;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using HRMSDL;

namespace HRMS.ApiBL
{
    public interface I_002h_hrmEmpSalaryAddOnBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _002h_hrmEmpSalaryAddOnBL : Common.BaseBL, I_002h_hrmEmpSalaryAddOnBL<_002h_hrmEmpSalaryAddOnDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002h_hrmEmpSalaryAddOnDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empMasterID_002a", Value = projectDomain.empMasterID_002a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@salaryAddOn", Value = projectDomain.salaryAddOn, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@date", Value = projectDomain.date, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isCurrent", Value = projectDomain.isCurrent, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp002hhrmEmpSalaryAddOnCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002h_hrmEmpSalaryAddOnDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002h_hrmEmpSalaryAddOnDomain() { ID = id }, HRMSDL.Command.Delete);
        }

        public IEnumerable<_002h_hrmEmpSalaryAddOnDomain> Get()
        {
            return GetData(0);
        }

        public _002h_hrmEmpSalaryAddOnDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002h_hrmEmpSalaryAddOnDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002h_hrmEmpSalaryAddOnDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp002hhrmEmpSalaryAddOnSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002h_hrmEmpSalaryAddOnDomain>>(tabledata);

        }
    }
}
