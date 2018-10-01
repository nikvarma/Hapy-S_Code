using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Hapy.NewsAPI.Controllers
{
    [RoutePrefix("api/v1/scarping")]
    public class ScarpingWebController : BaseController
    {
        [Route("web")]
        public IHttpActionResult GetContent()
        {
            WebClient webClient = new WebClient();

            byte[] _bytes = webClient.DownloadData("https://stackoverflow.com/questions/5320231/scraping-a-webpage-with-c-sharp-and-htmlagility");
            string webData = Encoding.UTF8.GetString(_bytes);
            return Ok(_bytes);
        }
    }
}