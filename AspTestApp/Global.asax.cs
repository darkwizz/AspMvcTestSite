using AspTestApp.Migrations;
using AspTestApp.Models.Database;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AspTestApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Logger LOG = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            string appDataPath = HttpContext.Current.Server.MapPath("~/App_Data/");
            Database.SetInitializer(new DbInitializer(appDataPath));
            LOG.Info("AppStart()");
        }
    }
}
