using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hapy.AppSettings
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cros = new EnableCorsAttribute("*", "*", "GET,POST,PUT,DELETE", "*");
            config.MapHttpAttributeRoutes();
            config.EnableCors(cros);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
