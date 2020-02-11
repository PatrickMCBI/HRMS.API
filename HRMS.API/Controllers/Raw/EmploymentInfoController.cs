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
    /// EmploymentInfo
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmploymentInfoController : ApiController
    {
        I_002c_hrmEmploymentInfoBL<_002c_hrmEmploymentInfoDomain> cat1;

        public EmploymentInfoController(I_002c_hrmEmploymentInfoBL<_002c_hrmEmploymentInfoDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmploymentInfo
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002c_hrmEmploymentInfoDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmploymentInfo by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002c_hrmEmploymentInfoDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmploymentInfo
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
        /// Get List of EmploymentInfo
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002c_hrmEmploymentInfoDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmploymentInfo by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002c_hrmEmploymentInfoDomain))]
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
