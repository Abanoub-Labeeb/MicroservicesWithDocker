using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;

namespace BMWSurvey
{
    /**
     * deprecated : replaced at app by endpoint routing
     * https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-2.1
     * and AddControllers() will enable attribute mapping by default 
     * and configure return json in camel notation is defined in Startup.CS >> ConfigureServices
    **/
    public class WebApiConfig
    {
        /**
        public static void Register(HttpConfiguration config)
        {
            //define router for the web api
            //we sort the routes from most specific to the most general
            //as the router controller will fist check the first one if it does not match will go to the second route config and so on
            //patterens used : https://www.youtube.com/watch?v=UjrheegKpSg
            config.MapHttpAttributeRoutes();

            //must be in the next order
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RouteApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            

            //configure return json in camel notation
            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented; 
        }
        **/
    }
}