using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRMS.BL;
using System.Web.Http.Cors;

namespace HRMS.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonInformationController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_006_invRefAttributeBL<_006_invRefAttributeDomain> attrib = new _006_invRefAttributeBL();

        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_006_invRefAttributeDomain body)
        {
            return Json(attrib.Command(new _006_invRefAttributeDomain(), "insert"));
        }

        public IEnumerable<_006_invRefAttributeDomain> Get()
        {
            return attrib.Get();
        }



    }
}
