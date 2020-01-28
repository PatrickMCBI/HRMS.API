using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HRMS.Filters
{
    public class DomainValidatorFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {


            if (!actionContext.ModelState.IsValid)
            {
                var modelErrors = new StringBuilder();

                foreach (var modelState in actionContext.ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Append(modelError.ErrorMessage + "<br>");

                    }
                }
                actionContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest
                };

                actionContext.Response.Content = new StringContent(modelErrors.ToString(), System.Text.Encoding.UTF8, "application/json".ToString());
            }
        }
    }
}