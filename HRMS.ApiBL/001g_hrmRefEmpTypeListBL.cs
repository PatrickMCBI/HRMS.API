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
    public interface I_001g_hrmRefEmpTypeListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        MessageViewDomain Command(_001g_hrmRefEmpTypeListDomain body, Command update);
    }

    public class _001g_hrmRefEmpTypeListBL : Common.BaseBL, I_001g_hrmRefEmpTypeListBL<_001g_hrmRefEmpTypeListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001g_hrmRefEmpTypeListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@typeName", Value = projectDomain.typeName, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp001ghrmRefEmpTypeListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_001g_hrmRefEmpTypeListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _001g_hrmRefEmpTypeListDomain() { ID = id }, DL.Command.Delete);
        }

        public IEnumerable<_001g_hrmRefEmpTypeListDomain> Get()
        {
            return GetData(0);
        }

        public _001g_hrmRefEmpTypeListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_001g_hrmRefEmpTypeListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_001g_hrmRefEmpTypeListDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp001ghrmRefEmpTypeListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_001g_hrmRefEmpTypeListDomain>>(tabledata);

        }
    }
}
