using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity;
using FluentNHibernate.Mapping;

namespace PestControl.Model.Mapping
{
    public partial class GalleryImagesMap: ClassMap<GalleryImages> 
    {
        public GalleryImagesMap()
        {
			Table("GalleryImages");
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
            Map(x => x.ThumbUrl);
            Map(x => x.ImageUrl);
            Map(x => x.Name);

            References(x => x.Gallery);
        }
    }
}
