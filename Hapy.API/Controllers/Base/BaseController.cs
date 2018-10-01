using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.API.Controllers
{
    public class BaseController : ApiController
    {
        [NonAction]
        public IHttpActionResult GetJsonResult(BaseResponse response)
        {
            return Ok(response);
        }
    }
}
