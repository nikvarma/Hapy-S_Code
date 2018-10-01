using CommonLibrary;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.AuthAPI.Controllers
{
    [RoutePrefix("api/v1/otp")]
    public class OTPController : BaseController
    {
        [HttpGet]
        [Route("sendonmobile")]
        public IHttpActionResult SendOnMobile(string mobilenumber, int countrycode)
        {
            string otp = Util.GenerateRadAlphaNumaric<string>(0, 99999, 6, true);

            return GetJsonResult(new BaseResponse()
            {
                Message = "OTP sent successfully",
                ResponseObject = new MiddelLayer.OTP().Insert(new OTP()
                {
                    Account = string.Format("{0}-{1}", new object[] { countrycode, mobilenumber }),
                    Code = otp
                }),
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("verify")]
        public IHttpActionResult VerifyOTP(OTP oTP)
        {
            return GetJsonResult(new BaseResponse()
            {
                Message = "OTP validation request.",
                ResponseObject = new MiddelLayer.OTP().Update(new OTP()
                {
                    Id = oTP.Id,
                    Code = oTP.Code
                }),
                StatusCode = 200
            });
        }

        [HttpGet]
        [Route("sendonemail")]
        public IHttpActionResult SendOnEmail(string emailid)
        {
            string otp = Util.GenerateRadAlphaNumaric<string>(0, 99999, 6, true);
            return GetJsonResult(new OTP()
            {
                Code = otp,
                isMixCode = false
            });
        }

        [HttpGet]
        [Route("checksmstosend")]
        public IHttpActionResult CheckSMSToSend(string name, object value)
        {
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = new MiddelLayer.OTP().CheckSMSToSend(name, value),
                Message = "Data fetched successfully",
                StatusCode = 200
            });
        }
    }
}
