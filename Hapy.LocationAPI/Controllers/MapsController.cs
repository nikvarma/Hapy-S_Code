using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace Hapy.LocationAPI.Controllers
{
    [RoutePrefix("api/v1/location")]
    public class MapsController : BaseController
    {
        [HttpPost]
        [Route("image")]
        public IHttpActionResult GetStaticImage(LocationImage image)
        {
            image.APIKey = WebConfigurationManager.AppSettings["mapKey"];
            image.MapURL = WebConfigurationManager.AppSettings["mapStaticURL"];
            return GetJsonResult(new BaseResponse()
            {
                StatusCode = 200,
                ResponseObject = new MiddelLayer.Location().GetMapStaticImage(image),
                Message = "Static Map generated successfully."
            });
        }
    }
}
