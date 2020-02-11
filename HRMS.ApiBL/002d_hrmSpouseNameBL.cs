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
    public interface I_002d_hrmSpouseNameBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _002d_hrmSpouseNameBL : Common.BaseBL, I_002d_hrmSpouseNameBL<_002d_hrmSpouseNameDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002d_hrmSpouseNameDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@empMasterID_002a", Value = projectDomain.empMasterID_002a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@firstName", Value = projectDomain.firstName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@middleName", Value = projectDomain.middleName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@lastName", Value = projectDomain.lastName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@dateOfBirth", Value = projectDomain.dateOfBirth, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp002dhrmSpouseNameCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_002d_hrmSpouseNameDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _002d_hrmSpouseNameDomain() { ID = id }, HRMSDL.Command.Delete);
        }

        public IEnumerable<_002d_hrmSpouseNameDomain> Get()
        {
            return GetData(0);
        }

        public _002d_hrmSpouseNameDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002d_hrmSpouseNameDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_002d_hrmSpouseNameDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp002dhrmSpouseNameSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_002d_hrmSpouseNameDomain>>(tabledata);

        }
    }
}
