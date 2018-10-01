using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.AppSettings.Controllers
{
    [RoutePrefix("api/v1/appusersettings")]
    public class AppSettingsController : BaseController
    {
        public IHttpActionResult StoreAppSetting()
        {
            return Ok();
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult SaveSettings(Models.AppUserSettings settings)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.AppUserSettings().Insert(settings),
                Message = "Settings updated successfully.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("get")]
        public IHttpActionResult GetSettings(Models.SearchParams search)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.AppUserSettings().Get(search),
                Message = "Settings updated successfully.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdateSettings(Models.AppUserSettings settings)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.AppUserSettings().Update(settings),
                Message = "Settings updated successfully.",
                StatusCode = 200
            });
        }
    }
}
