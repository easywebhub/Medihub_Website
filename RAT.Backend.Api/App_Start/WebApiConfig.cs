using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RAT.Backend.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Routes.MapHttpRoute(
              name: "Customer",
              routeTemplate: "customer-api/{action}/{id}",
              defaults: new { controller = "Customer", action = "Get", id = RouteParameter.Optional }
          );
         
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
