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
    public interface I_002b_hrmPersonalInfoBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _002b_hrmPersonalInfoBL : Common.BaseBL, I_002b_hrmPersonalInfoBL<_002b_hrmPersonalInfoDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002b_hrmPersonalInfoDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empMasterID_002a", Value = projectDomain.empMasterID_002a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@height", Value = projectDomain.height, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@weight", Value = projectDomain.weight, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@civilStatusID", Value = projectDomain.civilStatusID, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp002bhrmPersonalInfoCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002b_hrmPersonalInfoDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002b_hrmPersonalInfoDomain() { ID = id }, HRMSDL.Command.Delete);
        }

        public IEnumerable<_002b_hrmPersonalInfoDomain> Get()
        {
            return GetData(0);
        }

        public _002b_hrmPersonalInfoDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002b_hrmPersonalInfoDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002b_hrmPersonalInfoDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp002bhrmPersonalInfoSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002b_hrmPersonalInfoDomain>>(tabledata);

        }
    }
}
