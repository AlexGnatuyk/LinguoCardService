using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;

namespace LinguoCardService
{
    /// <summary>
    /// Web Api Config
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Route Prefix
        /// </summary>
        public const string RoutePrefix = "api";
        /// <summary>
        /// Register method
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
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
