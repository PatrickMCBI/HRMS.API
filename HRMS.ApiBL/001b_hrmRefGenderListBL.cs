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
    public interface I_001b_hrmRefGenderListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        MessageViewDomain Command(_001b_hrmRefGenderListDomain body, Command update);
    }

    public class _001b_hrmRefGenderListBL : Common.BaseBL, I_001b_hrmRefGenderListBL<_001b_hrmRefGenderListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001b_hrmRefGenderListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@genderName", Value = projectDomain.genderName, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp001bhrmRefGenderListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_001b_hrmRefGenderListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _001b_hrmRefGenderListDomain() { ID = id }, DL.Command.Delete);
        }

        public IEnumerable<_001b_hrmRefGenderListDomain> Get()
        {
            return GetData(0);
        }

        public _001b_hrmRefGenderListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_001b_hrmRefGenderListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_001b_hrmRefGenderListDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp001bhrmRefGenderListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_001b_hrmRefGenderListDomain>>(tabledata);

        }
    }
}
