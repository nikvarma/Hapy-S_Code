using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.AppSettings.Controllers
{
    [RoutePrefix("api/v1/logging")]
    public class AppLoggerController : BaseController
    {
        [HttpPost]
        [Route("set")]
        public IHttpActionResult SetLogger(Models.Logging logging)
        {
            MiddelLayer.Logging _logging = new MiddelLayer.Logging();
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = _logging.Insert(logging),
                Message = "Information logged successfully.",
                StatusCode = 200
            });
        }
    }
}
