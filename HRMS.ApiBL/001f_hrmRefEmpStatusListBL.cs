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
    public interface I_001f_hrmRefEmpStatusListBLv<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        MessageViewDomain Command(_001f_hrmRefEmpStatusListDomain body, Command update);
    }

    public class _001f_hrmRefEmpStatusListBLv : Common.BaseBL, I_001f_hrmRefEmpStatusListBLv<_001f_hrmRefEmpStatusListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001f_hrmRefEmpStatusListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@statusName", Value = projectDomain.statusName, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp001fhrmRefEmpStatusListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_001f_hrmRefEmpStatusListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _001f_hrmRefEmpStatusListDomain() { ID = id }, DL.Command.Delete);
        }

        public IEnumerable<_001f_hrmRefEmpStatusListDomain> Get()
        {
            return GetData(0);
        }

        public _001f_hrmRefEmpStatusListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_001f_hrmRefEmpStatusListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_001f_hrmRefEmpStatusListDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp001fhrmRefEmpStatusListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_001f_hrmRefEmpStatusListDomain>>(tabledata);

        }
    }
}
