using ASPNetMVCExtendingIdentity2Roles.Context;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ASPNetMVCExtendingIdentity2Roles
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if DEBUG
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbContext.DropCreateAlwaysInitializer());
#endif
        }
    }
}
