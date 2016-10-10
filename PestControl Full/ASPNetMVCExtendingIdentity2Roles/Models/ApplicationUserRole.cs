using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPNetMVCExtendingIdentity2Roles.Models
{
    public class ApplicationUserRole : IdentityUserRole
    {
        public ApplicationUserRole()
            : base()
        { }

        public ApplicationRole Role { get; set; }
    }
}