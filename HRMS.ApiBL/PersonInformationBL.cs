using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.DL;
using System.Data;
using System.Data.SqlClient;
using HRMS.DAL;

namespace HRMS.ApiBL
{
    public interface IPersonInformationBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class PersonInformationBL : Common.BaseBL, IPersonInformationBL<PersonInformationDL>
    {
        private IHRMSDBDAL _dbHelper = new HRMSDBDL();

        public MessageViewDomain Command(PersonInformationDL projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@FirstName", Value = projectDomain.FirstName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@MiddleName", Value = projectDomain.MiddleName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@LastName", Value = projectDomain.LastName, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("", sqlParameters, commandType));


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonInformationDL> Get()
        {
            return GetData(0);
        }

        public PersonInformationDL Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<PersonInformationDL> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<PersonInformationDL> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            return _dbHelper.Select("spGetBasicInfo", pars).Tables[0].AsEnumerable().Select
            (
                drow => new PersonInformationDL
                {
                    ID = drow.Field<int>("ID"),
                    FirstName = drow.Field<string>("FirstName"),
                    MiddleName = drow.Field<string>("MiddleName"),
                    LastName = drow.Field<string>("LastName")
                }
            );
        }
    }
}