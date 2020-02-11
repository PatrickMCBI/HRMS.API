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
    public interface I_002c_hrmEmploymentInfoBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _002c_hrmEmploymentInfoBL : Common.BaseBL, I_002c_hrmEmploymentInfoBL<_002c_hrmEmploymentInfoDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002c_hrmEmploymentInfoDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empMasterId_002a", Value = projectDomain.empMasterId_002a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@employmentTypeID", Value = projectDomain.employmentTypeID, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@biometricIdentity", Value = projectDomain.biometricIdentity, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@resignedDate", Value = projectDomain.resignedDate, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@employementStatusID", Value = projectDomain.employementStatusID, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp002chrmEmploymentInfoCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002c_hrmEmploymentInfoDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002c_hrmEmploymentInfoDomain() { ID = id }, HRMSDL.Command.Delete);
        }

        public IEnumerable<_002c_hrmEmploymentInfoDomain> Get()
        {
            return GetData(0);
        }

        public _002c_hrmEmploymentInfoDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002c_hrmEmploymentInfoDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002c_hrmEmploymentInfoDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp002chrmEmploymentInfoSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002c_hrmEmploymentInfoDomain>>(tabledata);

        }
    }
}
