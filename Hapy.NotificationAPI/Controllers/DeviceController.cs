using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.NotificationAPI.Controllers
{
    [RoutePrefix("api/v1/device")]
    public class DeviceController : BaseController
    {
        [HttpGet]
        [Route("getsupportedlist")]
        public IHttpActionResult GetSupportedDeviceList()
        {
            MiddelLayer.Device device = new MiddelLayer.Device();
            return GetJsonResult(new BaseResponse()
            {
                ResponseObject = device.GetDevice(),
                Message = "Device retrieved successfully",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("register")]
        public IHttpActionResult RegisterDevice(UnRegisteredDevice unRegisteredDevice)
        {
            if (ModelState.IsValid && unRegisteredDevice != null)
            {
                MiddelLayer.RegisterDevice registerDevice = new MiddelLayer.RegisterDevice();

                return GetJsonResult(new BaseResponse()
                {
                    ResponseObject = registerDevice.Insert(unRegisteredDevice),
                    Message = "Device registered successfully",
                    StatusCode = 200
                });
            }
            return GetJsonResult(new BaseResponse()
            {
                Message = "All input fields are required.",
                StatusCode = 200
            });
        }

        [HttpPost]
        [Route("settoken")]
        public IHttpActionResult DeviceToken(FToken fToken)
        {
            if (ModelState.IsValid && fToken != null)
            {
                MiddelLayer.FirebaseToken firebaseToken = new MiddelLayer.FirebaseToken();

                return GetJsonResult(new BaseResponse()
                {
                    ResponseObject = firebaseToken.Insert(fToken),
                    Message = "Device registered successfully",
                    StatusCode = 200
                });
            }
            return GetJsonResult(new BaseResponse()
            {
                Message = "All input fields are required.",
                StatusCode = 200
            });
        }
    }
}