using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.API.Controllers
{
    [RoutePrefix("api/v1/work")]
    public class WorkController : BaseController
    {
        [Route("save")]
        public IHttpActionResult SaveWorkDetail(Models.CompDetail comp)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Insert(comp),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }

        [Route("delete")]
        public IHttpActionResult DeleteWorkDetail(string id)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                Message = "Record removed successfully.",
                StatusCode = 200
            });
        }

        [Route("update")]
        public IHttpActionResult UpdateWorkDetail(Models.CompDetail comp)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(comp),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }
    }
}
