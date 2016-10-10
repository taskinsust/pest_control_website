using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PestControl.Model.Entity;

namespace PestControl.Model.Mapping
{
    public partial class ProductServicesMap : ClassMap<ProductServices>
    {
        public ProductServicesMap()
        {
            Table("ProductServices");
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

            Map(x => x.Title); 
            Map(x => x.ShortDescription);
            Map(x => x.ServiceDescription).CustomType("StringClob").CustomSqlType("nvarchar(max)");
            Map(x => x.FriendlyUrl);
            HasMany(x => x.ServiceImageses);
            References(x => x.Menu);
        }
    }
}
