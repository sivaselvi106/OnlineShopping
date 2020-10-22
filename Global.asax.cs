using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security;
using System.Web.Optimization;
using WebGrease.Configuration;

namespace OnlineMobileShopping
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GlobalConfiguration.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
