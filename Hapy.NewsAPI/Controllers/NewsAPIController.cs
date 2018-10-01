using CommonLibrary;
using Hapy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Configuration;

namespace Hapy.NewsAPI.Controllers
{
    [RoutePrefix("api/v1/news")]
    public class NewsAPIController : BaseController
    {
        new string Url = WebConfigurationManager.AppSettings["newAPIURL"];
        string NewsAPIKey = WebConfigurationManager.AppSettings["newAPIKey"];

        [HttpGet]
        [Route("setfeed/{type}")]
        public async Task<IHttpActionResult> SetNews()
        {
            HttpResponseMessage _json = await HttpClientRequest.Get<HttpResponseMessage>(new HttpClientOptions()
            {
                OutPutFormat = OutPutFormat.HttpResponse,
                URL = new Uri(Url + "&" + NewsAPIKey)
            });
            string dataList = await _json.Content.ReadAsStringAsync();
            Models.NewsAPI newsList = JsonConvert.DeserializeObject<Models.NewsAPI>(dataList);
            return GetJsonResult(new BaseResponse()
            {
                Message = "News saved successfully",
                ResponseObject = new MiddelLayer.NewsAPI().Insert(newsList.articles),
                StatusCode = 200
            });
        }

        [HttpGet]
        [Route("getfeed/{type}/{pageindex}/{pagesize}")]
        public async Task<IHttpActionResult> GetNews()
        {
            HttpResponseMessage _json = await HttpClientRequest.Get<HttpResponseMessage>(new HttpClientOptions()
            {
                OutPutFormat = OutPutFormat.HttpResponse,
                URL = new Uri(Url + "&" + NewsAPIKey)
            });
            string dataList = await _json.Content.ReadAsStringAsync();
            Models.NewsAPI newsList = JsonConvert.DeserializeObject<Models.NewsAPI>(dataList);
            return GetJsonResult(new BaseResponse()
            {
                Message = "News saved successfully",
                ResponseObject = new MiddelLayer.NewsAPI().Insert(newsList.articles),
                StatusCode = 200
            });
        }
    }
}
