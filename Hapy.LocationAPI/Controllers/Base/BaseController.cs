using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hapy.Models;

namespace Hapy.LocationAPI.Controllers
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
