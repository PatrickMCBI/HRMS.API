﻿using System;
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
    /// SpouseName
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SpouseNameController : ApiController
    {
       I_002d_hrmSpouseNameBL<_002d_hrmSpouseNameDomain> cat1;

        public SpouseNameController(I_002d_hrmSpouseNameBL<_002d_hrmSpouseNameDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new SpouseName
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002d_hrmSpouseNameDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update PrefixList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002d_hrmSpouseNameDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific PrefixList
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
        /// Get List of PrefixList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002d_hrmSpouseNameDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific PrefixList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002d_hrmSpouseNameDomain))]
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
