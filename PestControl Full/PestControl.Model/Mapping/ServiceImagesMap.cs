using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PestControl.Model.Entity;

namespace PestControl.Model.Mapping
{
    public partial class ServiceImagesMap : ClassMap<ServiceImages>
    {
        public ServiceImagesMap()
        {
            Table("ServiceImages");
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

            Map(x => x.ImageUrl);
            Map(x => x.ThumbUrl);
            
            References(x => x.Menu);
            References(x => x.SubMenuService);
        }
    }
}
