using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PynkTalent
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Frontend", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Deposit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Frontend",action = "Deposit",id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Withdraw",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Frontend",action = "Withdraw",id = UrlParameter.Optional }
            );
        }
    }
}