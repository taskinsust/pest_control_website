using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class ServiceImages:BaseEntity
    {
        public ServiceImages() { }
        public virtual string ImageUrl { get; set; }
        public virtual string ThumbUrl { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ProductServices SubMenuService { get; set; }
    }
}
