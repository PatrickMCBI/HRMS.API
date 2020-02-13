using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMSDL;
using HRMS.Filters;
using HRMS.ApiBL;
using HRMS.DL;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace HRMS.API.Controllers
{
    public class PersonInformationController : ApiController
    {

        I_PersonInformationBL<PersonInformationDL> attrib;

        public PersonInformationController(I_PersonInformationBL<PersonInformationDL> _001)
        {
            attrib = _001;
        }
        /// <summary>
        /// Add new EmpAllowance
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]PersonInformationDL body)
        {

            return Json(attrib.Command(body, Command.Insert));
        }

        /*//Update
        /// <summary>
        /// Update EmpAllowance by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]PersonInformationDL body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }*/

        /// <summary>
        /// Delete Specific EmpAllowance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /*[ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }*/

        /// <summary>
        /// Get List of EmpAllowance
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<PersonInformationDL>))]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpAllowance by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(PersonInformationDL))]
        public IHttpActionResult Get(int id)
        {
            var result = attrib.Get(id);
            /*
             *
             */

            return Ok(result);
        }
    }
}
