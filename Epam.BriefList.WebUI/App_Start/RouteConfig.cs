﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Epam.BriefList.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default",   
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "StartPage", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "/showLists",
                url: "List/ShowLists",
                defaults: new { controller = "List", action = "ShowLists" }
                );

        }
    }
}