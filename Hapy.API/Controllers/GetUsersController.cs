using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.API.Controllers
{
    [RoutePrefix("api/v1/userinfo")]
    public class GetUsersController : BaseController
    {
        [HttpPost]
        [Route("get")]
        public IHttpActionResult GetUserInfo(Models.SearchParams search)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().GetUserInfo(search),
                Message = "Records fetched successfully"
            });
        }

        [HttpPost]
        [Route("getsearch")]
        public IHttpActionResult GetOnSearchUserInfo(Models.SearchParams search)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().GetUserInfoOnCloumns(search),
                Message = "Records fetched successfully"
            });
        }

        [HttpPost]
        [Route("getwork")]
        public IHttpActionResult GetUserWorkInfo(Models.SearchParams search)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().GetUserComp(search),
                Message = "Records fetched successfully."
            });
        }

        [HttpPost]
        [Route("getlocations")]
        public IHttpActionResult GetUserLocationsInfo(Models.SearchParams search)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().GetLocation(search),
                Message = "Records fetched successfully."
            });
        }

        [Route("getfiterbynamevalue")]
        public IHttpActionResult FilterByNameValue(string name, object value)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().FilterByNameValue(name, value)
            });
        }

        [Route("getprofileimage")]
        public IHttpActionResult GetUserProfileImage()
        {
            return GetJsonResult(new Models.BaseResponse()
            {
            });
        }

    }
}
