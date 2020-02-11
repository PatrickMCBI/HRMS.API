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
    /// EmpSalaryAddOn
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmpSalaryAddOnController : ApiController
    {
        I_002h_hrmEmpSalaryAddOnBL<_002h_hrmEmpSalaryAddOnDomain> cat1;

        public EmpSalaryAddOnController(I_002h_hrmEmpSalaryAddOnBL<_002h_hrmEmpSalaryAddOnDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new EmpSalaryAddOn
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_002h_hrmEmpSalaryAddOnDomain body)
        {

            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update EmpSalaryAddOn by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_002h_hrmEmpSalaryAddOnDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific EmpSalaryAddOn
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
        /// Get List of EmpSalaryAddOn
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_002h_hrmEmpSalaryAddOnDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific EmpSalaryAddOn by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_002h_hrmEmpSalaryAddOnDomain))]
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
