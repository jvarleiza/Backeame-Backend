using Backeame.Resolver;
using Backeame.WebApi.App_Start;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Unity.WebApi;

namespace Backeame.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new OptionMethodHandler());

            //Reduces data transfer overload over 30%
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new
                {
                    action = "DefaultAction",
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi1",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new
                {
                    action = "DefaultAction",
                    id = RouteParameter.Optional,
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{action}/{id}/{id1}",
                defaults: new
                {
                    action = "DefaultAction",
                    id = RouteParameter.Optional,
                    id1 = RouteParameter.Optional,
                }
            );

            var container = new UnityContainer();

            ComponentLoader.LoadContainer(container, "./bin/", "Backeame.*.dll");
            //var cors = new System.Web.Http.Cors.EnableCorsAttribute("*","*","*");//http://172.20.10.4:4200

            //config.EnableCors(cors);

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
