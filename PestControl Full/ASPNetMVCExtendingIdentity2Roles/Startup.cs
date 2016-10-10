using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNetMVCExtendingIdentity2Roles.Startup))]
namespace ASPNetMVCExtendingIdentity2Roles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
