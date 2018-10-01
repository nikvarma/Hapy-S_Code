using CommonLibrary;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Hapy.AuthoAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/v1/otp")]
    public class OTPController : BaseController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("sendonmobile")]
        public ActionResult SendOnMobile(double mobilenumber, int countrycode)
        {
            string otp = Util.GenerateRadAlphaNumaric<string>(0, 99999, 6, true);
            MiddelLayer.OTP tP = new MiddelLayer.OTP(string.Format("+{0}-{1}", countrycode, mobilenumber), otp);
            return GetJsonResult(new BaseResponse()
            {
                Message = "OTP sent successfully",
                ResponseObject = new OTP()
                {
                    Code = otp,
                    isMixCode = false
                },
                StatusCode = 200
            });
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("sendonemail")]
        public ActionResult SendOnEmail(string emailid)
        {
            string otp = Util.GenerateRadAlphaNumaric<string>(0, 99999, 6, true);
            return GetJsonResult(new OTP()
            {
                Code = otp,
                isMixCode = false
            });
        }
    }
}
