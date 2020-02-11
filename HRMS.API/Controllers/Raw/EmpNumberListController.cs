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
    /// EmpNumberList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpNumberListController : ApiController
    {
        I_001c_hrmRefEmpNumberListBL<_001c_hrmRefEmpNumberListDomain> cat1;

        public EmpNumberListController(I_001c_hrmRefEmpNumberListBL<_001c_hrmRefEmpNumberListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmpNumberList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_001c_hrmRefEmpNumberListDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmpNumberList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_001c_hrmRefEmpNumberListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmpNumberList
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
        /// Get List of EmpNumberList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001c_hrmRefEmpNumberListDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpNumberList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001c_hrmRefEmpNumberListDomain))]
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
