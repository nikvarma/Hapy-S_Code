using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Hapy.AuthoAPI.Controllers
{
    public class BaseController : ApiController
    {
        [System.Web.Http.NonAction]
        public JsonResult GetJsonResult<TData>(Object dataObject)
            where TData : class, new()
        {
            JsonResult jsonResult = new JsonResult();
            try
            {
                jsonResult.Data = dataObject;
            }
            catch (Exception Ex)
            {
                jsonResult.Data = new BaseResponse()
                {
                    Message = "Please try again after sometime",
                    StatusCode = 500,
                    LogMessage = Ex.Message
                };
            }
            return jsonResult;
        }

        [System.Web.Http.NonAction]
        public JsonResult GetJsonResult(Object dataObject)
        {
            JsonResult jsonResult = new JsonResult();
            try
            {
                jsonResult.Data = dataObject;
            }
            catch (Exception Ex)
            {
                jsonResult.Data = new BaseResponse()
                {
                    Message = "Please try again after sometime",
                    StatusCode = 500,
                    LogMessage = Ex.Message
                };

            }
            return jsonResult;
        }
    }
}
