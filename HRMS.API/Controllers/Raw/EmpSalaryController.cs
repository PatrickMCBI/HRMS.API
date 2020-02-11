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
    /// EmpSalary
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpSalaryController : ApiController
    {
        I_002g_hrmEmpSalaryBL<_002g_hrmEmpSalaryDomain> cat1;

        public EmpSalaryController(I_002g_hrmEmpSalaryBL<_002g_hrmEmpSalaryDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmpSalary
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002g_hrmEmpSalaryDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmpSalary by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002g_hrmEmpSalaryDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmpSalary
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
        /// Get List of EmpSalary
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002g_hrmEmpSalaryDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpSalary by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002g_hrmEmpSalaryDomain))]
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
