using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.AuthAPI.Controllers
{
    public class BaseController : ApiController
    {
        [NonAction]
        public IHttpActionResult GetJsonResult(Object dataObject)
        {
            return Ok(dataObject);
        }
    }
}
