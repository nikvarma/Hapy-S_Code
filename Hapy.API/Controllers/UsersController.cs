using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.API.Controllers
{
    [RoutePrefix("api/v1/users")]
    public class UsersController : BaseController
    {
        [Route("save")]
        public IHttpActionResult UserInfo(Models.UserInfo userInfo)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Insert(userInfo),
                Message = "Data saved successfully.",
                StatusCode = 200
            });
        }

        [Route("updateabout")]
        public IHttpActionResult UserInfoAbout(Models.UserAbout about)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(about),
                Message = "Data saved successfully.",
                StatusCode = 200
            });
        }

        [Route("savework")]
        public IHttpActionResult UserWorkInfo(Models.UserCompDetail userComp)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Insert(userComp),
                Message = "Data saved successfully.",
                StatusCode = 200
            });
        }

        [Route("savelocation")]
        public IHttpActionResult UserLocationInfo(Models.LocationDetail location)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Insert(location),
                Message = "Data saved successfully.",
                StatusCode = 200
            });
        }

        [Route("profileimage")]
        public IHttpActionResult UserProfileImage(Models.UserImage image)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(image),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }

        [Route("update")]
        public IHttpActionResult UserInfoUpdate(Models.UserInfo userInfo)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(userInfo),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }

        [Route("workupdate")]
        public IHttpActionResult UserWorkInfoUpdate(Models.UserCompDetail userComp)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(userComp),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }

        [Route("locationupdate")]
        public IHttpActionResult UserLocationInfoUpdate(Models.LocationDetail location)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(location),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("workdelete")]
        public IHttpActionResult DeleteUserWork(IdKey id)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().DeleteWork(id.UId),
                Message = "Work location deleted successfully.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("locationdelete")]
        public IHttpActionResult LocationUserWork(IdKey id)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().DeleteLocation(id.UId),
                Message = "Location deleted successfully.",
                StatusCode = 200
            });
        }

        [Route("profilewallimage")]
        public IHttpActionResult UserProfileWallImageUpdate(Models.UserImage user)
        {
            return GetJsonResult(new Models.BaseResponse()
            {
                ResponseObject = new MiddelLayer.Users().Update(user),
                Message = "Data update successfully.",
                StatusCode = 200
            });
        }
    }
}
