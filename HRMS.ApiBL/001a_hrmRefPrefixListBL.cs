﻿using System;
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
    public interface I_001a_hrmRefPrefixListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _001a_hrmRefPrefixListBL : Common.BaseBL, I_001a_hrmRefPrefixListBL<_001a_hrmRefPrefixListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001a_hrmRefPrefixListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@prefix", Value = projectDomain.prefix, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@definition", Value = projectDomain.definition, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp001ahrmRefPrefixListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Command(_001a_hrmRefPrefixListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }

        /*public MessageViewDomain Command(_001a_hrmRefPrefixListDomain entity, string commandType)
        {
            throw new NotImplementedException();
        }*/

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _001a_hrmRefPrefixListDomain() { ID = id }, HRMSDL.Command.Delete) ;
        }

        public IEnumerable<_001a_hrmRefPrefixListDomain> Get()
        {
            return GetData(0);
        }

        public _001a_hrmRefPrefixListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_001a_hrmRefPrefixListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_001a_hrmRefPrefixListDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp001ahrmRefPrefixListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_001a_hrmRefPrefixListDomain>>(tabledata);

        }
    }
}
