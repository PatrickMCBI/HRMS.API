using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMS.ApiBL;
using System.Web.Http.Cors;
using HRMS.DL;
using HRMS.Filters;

namespace HRMS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonInformationController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        IPersonInformationBL <PersonInformationDL> attrib = new PersonInformationBL();

        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]PersonInformationDL body)
        {
            return Json(attrib.Command(new PersonInformationDL(), "insert"));
        }

        /*public IEnumerable<PersonInformationDL> Get()
        {
            return attrib.Get();
        }*/

        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

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
