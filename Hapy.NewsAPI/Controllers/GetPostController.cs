using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.NewsAPI.Controllers
{
    [RoutePrefix("api/v1/getpost")]
    public class GetPostController : BaseController
    {
        [HttpPost]
        [Route("post")]
        public IHttpActionResult GetPost(PostIds search)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().GetPostRecords(search),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("comments")]
        public IHttpActionResult Comments(SearchParams search)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().GetCommentRecords(search),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("subcomments")]
        public IHttpActionResult SubComments(SearchParams search)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().GetSubCommentRecords(search),
                Message = "",
                StatusCode = 200
            });
        }
    }
}
