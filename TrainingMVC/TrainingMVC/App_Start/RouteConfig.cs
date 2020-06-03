using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrainingMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "detailFormation",
               url: "formation/{nomSeo}",
               defaults: new { controller = "formation", action = "Details" }
           );


            routes.MapRoute(
                name: "touteslesformations",
                url: "toutes-les-formations",
                defaults: new { controller = "formation", action = "Index" }
            );

            routes.MapRoute(
                name: "contact",
                url: "contact",
                defaults: new { controller = "Contact", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
