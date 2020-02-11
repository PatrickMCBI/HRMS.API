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
    /// EmpMasterList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpMasterListController : ApiController
    {
        I_002a_hrmEmpMasterListBL<_002a_hrmEmpMasterListDomain> cat1;

        public EmpMasterListController(I_002a_hrmEmpMasterListBL<_002a_hrmEmpMasterListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmpMasterList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002a_hrmEmpMasterListDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmpMasterList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002a_hrmEmpMasterListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmpMasterList
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
        /// Get List of EmpMasterList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002a_hrmEmpMasterListDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpMasterList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002a_hrmEmpMasterListDomain))]
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
