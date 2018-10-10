using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.NewsAPI.Controllers
{
    [RoutePrefix("api/v1/post")]
    public class PostController : BaseController
    {
        [HttpPut]
        [Route("create")]
        public IHttpActionResult SavePost([FromBody] BasePost post)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().Insert(post),
                Message = "Post created successfully.",
                StatusCode = 200
            });
        }

        [HttpPut]
        [Route("hiderequest")]
        public IHttpActionResult PostHide([FromBody]PostIds search, [FromUri] string hideType)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().HideRecords(search, hideType),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("like")]
        public IHttpActionResult PostLike(Likes likes)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().Like(likes),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPut]
        [Route("share")]
        public IHttpActionResult Postshare([FromBody]Share share)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().Share(share),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPut]
        [Route("comment")]
        public IHttpActionResult PostComment([FromBody]Comments comments)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().Comment(comments),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPut]
        [Route("updatecomment")]
        public IHttpActionResult PostUpdateComment([FromBody]Comments comments, [FromUri]string action)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().Update(comments, action),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPut]
        [Route("subcomment")]
        public IHttpActionResult PostSubComment([FromBody]SubComments comments)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().SubComment(comments),
                Message = "",
                StatusCode = 200
            });
        }

        [HttpPut]
        [Route("updatesubcomment")]
        public IHttpActionResult PostUpdateSubComment([FromBody]SubComments comments, [FromUri]string action)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.Posts().Update(comments, action),
                Message = "",
                StatusCode = 200
            });
        }
    }
}
