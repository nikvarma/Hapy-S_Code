using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.MessageAPI.Controllers
{
    [RoutePrefix("api/v1/chat")]
    public class MessageController : BaseController
    {
        [HttpPost]
        [Route("live")]
        public IHttpActionResult LiveChat()
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new { },
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("start")]
        public IHttpActionResult InitiateChat(Models.CallChatSetting setting)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.ChatMessage().Insert(setting),
                Message = "Chat session started successfully.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("updatesettings")]
        public IHttpActionResult UpdateChatSetting(Models.CallChatSetting setting)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.ChatMessage().UpdateSetting(setting),
                Message = "Chat session updated successfully.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("getsettings")]
        public IHttpActionResult GetChatSetting(Models.SearchParams search)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.ChatMessage().GetSetting(search),
                Message = "Chat list fetched successfully.",
                StatusCode = 200
            });
        }
    }
}
