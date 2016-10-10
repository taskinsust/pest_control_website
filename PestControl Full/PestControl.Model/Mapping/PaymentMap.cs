using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity;
using FluentNHibernate.Mapping;

namespace PestControl.Model.Mapping
{
    public partial class PaymentMap : ClassMap<Payment>
    {
        public PaymentMap()
        {
            Table("Payments");
            LazyLoad();

            //Base
            Id(x => x.Id).GeneratedBy.Identity();
            Version(x => x.VersionNumber).Nullable();
            Map(x => x.BusinessId);
            Map(x => x.CreationDate).Column("CreationDate").Not.Nullable();
            Map(x => x.ModificationDate).Column("ModificationDate").Not.Nullable();
            Map(x => x.Status).Not.Nullable();

            Map(x => x.Email);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.CardNo);
            Map(x => x.SecurityCode);
            Map(x => x.ExpireDate);
            Map(x => x.Amount);
            Map(x => x.InvoiceNo);
            Map(x => x.Address);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.ZipCode);
            Map(x => x.Phone);
            Map(x => x.Message);

            References(x => x.CardType);

        }
    }
}
