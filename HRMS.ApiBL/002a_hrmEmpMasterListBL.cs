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
    public interface I_002a_hrmEmpMasterListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _002a_hrmEmpMasterListBL : Common.BaseBL, I_002a_hrmEmpMasterListBL<_002a_hrmEmpMasterListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002a_hrmEmpMasterListDomain projectDomain, Command commandType)
        {
            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empNoID_001c", Value = projectDomain.empNoID_001c, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@firstName", Value = projectDomain.firstName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@middleName", Value = projectDomain.middleName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@lastName", Value = projectDomain.lastName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@dateOfBirth", Value = projectDomain.dateOfBirth, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@genderID", Value = projectDomain.genderID, Direction = ParameterDirection.Input },
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002bhrmPersonalInfo", "t002b", projectDomain.PersonalInfo),
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002chrmEmploymentInfo", "t002c", projectDomain.EmploymentInfo),
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002dhrmSpouseName", "t002d", projectDomain.SpouseName),
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002ehrmEmpAllowance", "t002e", projectDomain.EmpAllowance),
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002fhrmEmpPosition", "t002f", projectDomain.EmpPosition),
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002ghrmEmpSalary", "t002g", projectDomain.EmpSalary),
                 Helper.SqlTableParameter.DotnetPiperExtentionMethod("@002hhrmEmpSalaryAddOn", "t002h", projectDomain.EmpSalaryAddOn)
            };

            return this.GetMessage(_dbHelper.Command("sp002ahrmEmpMasterListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002a_hrmEmpMasterListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002a_hrmEmpMasterListDomain() { ID = id }, HRMSDL.Command.Delete);
        }

        public IEnumerable<_002a_hrmEmpMasterListDomain> Get()
        {
            return GetData(0);
        }

        public _002a_hrmEmpMasterListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002a_hrmEmpMasterListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002a_hrmEmpMasterListDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp002ahrmEmpMasterListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002a_hrmEmpMasterListDomain>>(tabledata);

        }
    }
}
