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
    /// GenderList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GenderListController : ApiController
    {
        I_001b_hrmRefGenderListBL<_001b_hrmRefGenderListDomain> cat1;

        public GenderListController(I_001b_hrmRefGenderListBL<_001b_hrmRefGenderListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new GenderList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_001b_hrmRefGenderListDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update GenderList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_001b_hrmRefGenderListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific GenderList
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
        /// Get List of GenderList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001b_hrmRefGenderListDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific GenderList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001b_hrmRefGenderListDomain))]
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
