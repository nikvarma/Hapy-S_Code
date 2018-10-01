using Hapy.Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.MessageAPI.Controllers
{
    public class BaseController : ApiController
    {
        [NonAction]
        public IHttpActionResult GetJsonResult(Models.BaseResponse response)
        {
            return Ok(response);
        }
    }
}
