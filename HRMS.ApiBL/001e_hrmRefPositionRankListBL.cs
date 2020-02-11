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
    public interface I_001e_hrmRefPositionRankListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        
    }

    public class _001e_hrmRefPositionRankListBL : Common.BaseBL, I_001e_hrmRefPositionRankListBL<_001e_hrmRefPositionRankListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001e_hrmRefPositionRankListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@positionID_001d", Value = projectDomain.positionID_001d, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@positionRank", Value = projectDomain.positionRank, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@baseSalary", Value = projectDomain.baseSalary, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp001ehrmRefPositionRankListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_001e_hrmRefPositionRankListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _001e_hrmRefPositionRankListDomain() { ID = id }, DL.Command.Delete);
        }

        public IEnumerable<_001e_hrmRefPositionRankListDomain> Get()
        {
            return GetData(0);
        }

        public _001e_hrmRefPositionRankListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_001e_hrmRefPositionRankListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_001e_hrmRefPositionRankListDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp001ehrmRefPositionRankListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_001e_hrmRefPositionRankListDomain>>(tabledata);

        }
    }
}
