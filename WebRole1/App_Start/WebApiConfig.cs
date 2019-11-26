using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebRole1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{action}/{id}",
                defaults: new { controller = "Custom", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApiWithoutAction",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            config.Routes.MapHttpRoute(
                name: "RootApiPath",
                routeTemplate: "api/{id}",
                defaults: new { controller = "Custom", id = RouteParameter.Optional }
                );
        }
    }
}
