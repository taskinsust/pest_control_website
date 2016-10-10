using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Mapping
{
    public class BaseEntityMap<TEntity> : ClassMap<TEntity> where TEntity : BaseEntity 
    {
        public BaseEntityMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Version(x => x.VersionNumber).Nullable();
            Map(x => x.BusinessId);
        }
    }
}
