using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Lances {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes){
            routes.MapPageRoute(null,"","~/Pages/Default.aspx");
            routes.MapPageRoute(null,"lances","~/Pages/Default.aspx");
            routes.MapPageRoute(null,"lances/{lance}","~/Pages/Default.aspx");

            routes.MapPageRoute(null,"metalhoses","~/Pages/MetalHoses.aspx");
            routes.MapPageRoute(null, "metalhoses/{hose}", "~/Pages/MetalHoses.aspx");

            routes.MapPageRoute(null,"reports","~/Pages/Reports.aspx");
            routes.MapPageRoute(null,"availability","~/Pages/AvailabilityLances.aspx");

            routes.MapPageRoute("lance","editlance/{lance}","~/Pages/EditLance.aspx");
            routes.MapPageRoute("hose", "edithose/{hose}", "~/Pages/EditHose.aspx");

        }
    }
}