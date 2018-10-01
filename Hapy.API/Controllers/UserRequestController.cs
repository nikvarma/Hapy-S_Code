using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.API.Controllers
{
    [RoutePrefix("api/v1/userrequest")]
    public class UserRequestController : BaseController
    {
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddFriend(Models.UserConnectRequest connectRequest)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                StatusCode = 200,
                Message = "Friend request sent.",
                ResponseObject = new MiddelLayer.UserConnectRequest().AddFriend(connectRequest)
            });
        }

        [HttpPost]
        [Route("remove")]
        public IHttpActionResult RemoveFriend(Models.UserConnectRequest connectRequest)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                StatusCode = 200,
                Message = "Friend request removed.",
                ResponseObject = new MiddelLayer.UserConnectRequest().RemoveFriend(connectRequest)
            });
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdateFriend(Models.UserConnectRequest connectRequest)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                StatusCode = 200,
                Message = "Friend request updated.",
                ResponseObject = new MiddelLayer.UserConnectRequest().UpdateFriend(connectRequest)
            });
        }
    }
}
