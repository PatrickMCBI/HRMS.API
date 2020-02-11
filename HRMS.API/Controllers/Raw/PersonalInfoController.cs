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
    /// PersonalInfo
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonalInfoController : ApiController
    {
        I_002b_hrmPersonalInfoBL<_002b_hrmPersonalInfoDomain> cat1;

        public PersonalInfoController(I_002b_hrmPersonalInfoBL<_002b_hrmPersonalInfoDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new PersonalInfo
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002b_hrmPersonalInfoDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update PersonalInfo by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002b_hrmPersonalInfoDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific PersonalInfo
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
        /// Get List of PersonalInfo
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002b_hrmPersonalInfoDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific PersonalInfo by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002b_hrmPersonalInfoDomain))]
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
