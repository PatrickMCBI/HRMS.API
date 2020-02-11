using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DL;
using HRMS.Filters;
using HRMS.ApiBL;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using HRMS.DL;

namespace HRMS.API.Controllers
{
    
    /// <summary>
    /// EmpStatusList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpStatusListController : ApiController
    {
        I_001f_hrmRefEmpStatusListBLv<_001f_hrmRefEmpStatusListDomain> cat1;

        public EmpStatusListController(I_001f_hrmRefEmpStatusListBLv<_001f_hrmRefEmpStatusListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmpStatusList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_001f_hrmRefEmpStatusListDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmpStatusList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_001f_hrmRefEmpStatusListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmpStatusList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of EmpStatusList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001f_hrmRefEmpStatusListDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpStatusList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001f_hrmRefEmpStatusListDomain))]
        public IHttpActionResult Get(int id)
        {
            var result = cat1.Get(id);
            /*
             *
             */

            return Ok(result);
        }
    }
}
