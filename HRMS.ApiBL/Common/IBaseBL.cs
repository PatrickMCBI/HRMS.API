using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HRMS.DL;

namespace HRMS.BL.Common
{
    public interface IBaseBL<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        IEnumerable<TEntity> Search(int offset, int limit, string orderBy);
        MessageViewDomain Command(TEntity entity, string commandType);
        MessageViewDomain Delete(int id);
    }

    public class BaseBL
    {

        protected MessageViewDomain GetMessage(DataTable dataTable)
        {
            return dataTable.AsEnumerable()
                .Select(dataRow => new MessageViewDomain
                {
                    DataID = dataRow.Field<int>("DataID"),
                    Message = dataRow.Field<string>("Message"),
                    RetVal = dataRow.Field<int>("RetVal")
                }).FirstOrDefault();
        }
    }
