using System.Web.Http;
using ConsultantPortalWebApi.Formatters;

namespace TechEdDemoApi.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "TimeSheetApi",
                routeTemplate: "api/consultants/{consultant}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Insert(0, new JsonpFormatter());
        }
    }
}
