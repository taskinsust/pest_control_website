using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity;
using FluentNHibernate.Mapping;

namespace PestControl.Model.Mapping
{
    public partial class CardTypeMap : ClassMap<CardType>
    {
        public CardTypeMap()
        {
            Table("CardTypes");
            LazyLoad();

            //Base
            Id(x => x.Id).GeneratedBy.Identity();
            Version(x => x.VersionNumber).Nullable();
            Map(x => x.BusinessId);
            Map(x => x.CreationDate).Column("CreationDate").Not.Nullable();
            Map(x => x.ModificationDate).Column("ModificationDate").Not.Nullable();
            Map(x => x.Status).Not.Nullable();

            Map(x => x.Name);

            HasMany(x => x.Payments).KeyColumn("CardType_Id");

        }
    }
}
