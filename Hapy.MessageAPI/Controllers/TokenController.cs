using Hapy.Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hapy.MessageAPI.Controllers
{
    [RoutePrefix("api/v1/token")]
    public class TokenController : BaseController
    {
        protected readonly ITokenGenerator _tokenGenerator;

        public TokenController() : this(new TokenGenerator()) { }

        public TokenController(ITokenGenerator tokenGenerator)
        {
            this._tokenGenerator = tokenGenerator;
        }

        [HttpGet]
        [Route("genrate")]
        public IHttpActionResult Index(string device, string identity)
        {
            if (device == null || identity == null) return null;

            const string appName = "TwilioChatDemo";
            var endpointId = string.Format("{0}:{1}:{2}", appName, identity, device);

            var token = _tokenGenerator.Generate(identity, endpointId);
            return Json(new { identity, token });
        }
    }
}
