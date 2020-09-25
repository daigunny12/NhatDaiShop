using System.Web.Mvc;
using System.Web.Routing;

namespace NhatDaiShop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          //  routes.MapRoute(
          //    name: "Login",
          //    url: "Login",
          //    defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
          //    namespaces: new string[] { "NhatDaiShop.Web.Controllers" }
          //);
            routes.MapRoute(
                name: "Login",
                url: "dang-nhap",
                defaults: new { controller = "Account", action = "Login" }
                , namespaces: new string[] { "NhatDaiShop.Web.Controllers" });

            //  routes.MapRoute(
            //    "Login",                                              // Route name
            //    "{controller}/{action}/{id}",                           // URL with parameters
            //    new { controller = "Account", action = "Login", id = UrlParameter.Optional }  // Parameter defaults
            //);

            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "NhatDaiShop.Web.Controllers" }
            );


            routes.MapRoute(
                name: "Product category",
                url: "{alias}pc-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                 namespaces: new string[] { "NhatDaiShop.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Product",
               url: "{alias}p-{id}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "NhatDaiShop.Web.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new string[] { "NhatDaiShop.Web.Controllers" }
            );
        }
    }
}