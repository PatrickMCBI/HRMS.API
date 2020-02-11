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
    public interface I_002f_hrmEmpPositionBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        MessageViewDomain Command(_002f_hrmEmpPositionDomain body, Command update);
    }

    public class _002f_hrmEmpPositionBL : Common.BaseBL, I_002f_hrmEmpPositionBL<_002f_hrmEmpPositionDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002f_hrmEmpPositionDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empMasterID_002a", Value = projectDomain.empMasterID_002a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@positionRankId_001e", Value = projectDomain.positionRankId_001e, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Date", Value = projectDomain.Date, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isActive", Value = projectDomain.isActive, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp002fhrmEmpPositionCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002f_hrmEmpPositionDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002f_hrmEmpPositionDomain() { ID = id }, DL.Command.Delete);
        }

        public IEnumerable<_002f_hrmEmpPositionDomain> Get()
        {
            return GetData(0);
        }

        public _002f_hrmEmpPositionDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002f_hrmEmpPositionDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002f_hrmEmpPositionDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp002fhrmEmpPositionSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002f_hrmEmpPositionDomain>>(tabledata);

        }
    }
}
