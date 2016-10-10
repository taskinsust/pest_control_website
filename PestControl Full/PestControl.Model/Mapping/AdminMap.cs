using System; 
using System.Collections.Generic; 
using System.Text; 

using OnnorokomSms.Model.Mapping;
using PestControl.Model.Entity;
using FluentNHibernate.Mapping;

namespace PestControl.Model.Mapping
{
    
    
    public partial class AdminMap: ClassMap<Admin>  {
        
        public AdminMap() {
			Table("Admin");
			LazyLoad();

            //Base
            Id(x => x.Id).GeneratedBy.Identity();
            Version(x => x.VersionNumber).Nullable();
            Map(x => x.BusinessId);
            Map(x => x.CreationDate).Column("CreationDate").Not.Nullable();
            Map(x => x.ModificationDate).Column("ModificationDate").Not.Nullable();
            Map(x => x.Status).Not.Nullable();
            Map(x => x.CreateBy).Not.Nullable();
            Map(x => x.ModifiedBy);

            //Map(x => x.AdminType).Column("AdminType").Not.Nullable();
			Map(x => x.IsLocked).Column("IsLocked").Not.Nullable();
			// References(x => x.AppUser).Not.Nullable();
        }
    }
}
