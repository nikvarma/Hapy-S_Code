using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.NewsAPI.Controllers
{
    [RoutePrefix("api/v1/search")]
    public class SearchController : BaseController
    {
        [HttpPost]
        [Route("users")]
        public IHttpActionResult Search(Models.SearchOnSP search)
        {
            return GetJsonResult(new MiddelLayer.NewsAPI().SearchUser(search));
        }
    }
}
