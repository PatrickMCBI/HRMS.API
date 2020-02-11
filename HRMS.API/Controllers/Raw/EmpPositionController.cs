using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMSDL;
using HRMS.Filters;
using HRMS.ApiBL;
using System.Web.Http.Cors;
using System.Web.Http.Description;


namespace HRMS.API.Controllers
{

    /// <summary>
    /// EmpPosition
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpPositionController : ApiController
    {
        I_002f_hrmEmpPositionBL<_002f_hrmEmpPositionDomain> cat1;

        public EmpPositionController(I_002f_hrmEmpPositionBL<_002f_hrmEmpPositionDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmpPosition
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002f_hrmEmpPositionDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmpPosition by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002f_hrmEmpPositionDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmpPosition
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
        /// Get List of EmpPosition
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002f_hrmEmpPositionDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpPosition by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002f_hrmEmpPositionDomain))]
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
