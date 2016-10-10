using System.Web;
using System.Web.Mvc;

namespace ASPNetMVCExtendingIdentity2Roles
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
