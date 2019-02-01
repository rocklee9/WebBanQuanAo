using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanQuanAo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "TermsConditions",
                url: "terms-conditions",
                defaults: new { controller = "GuideLine", action = "TermsConditions", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            routes.MapRoute(
                name: "PrivacyPolicy",
                url: "privacy-policy",
                defaults: new { controller = "GuideLine", action = "PrivacyPolicy", id = UrlParameter.Optional },
                namespaces: new string[] { "MvcNangCao.Areas.Home.Controllers" }
            ).DataTokens.Add("area", "home");

            


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
