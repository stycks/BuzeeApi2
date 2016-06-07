using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BuzeeApi.Models;

namespace BuzeeApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var ctx = new DBBase())
            {
                User usr = new User() { Name = "Mall Mets" };
                Group grp = new Group() { Name = "koogigrupp" };
                Status stts = new Status() { Name = "Busy" };

                ctx.Users.Add(usr);
                ctx.Groups.Add(grp);
                ctx.Statuses.Add(stts);
                ctx.SaveChanges();
            }
        }
    }
}
