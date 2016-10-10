using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class Menu:BaseEntity
    {
        public Menu() { }

        public virtual string Title { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string Description { get; set; }
        public virtual string FriendlyUrl { get; set; }

        public virtual IList<ServiceImages> ServiceImageses { get; set; }
        public virtual IList<ProductServices> SubMenuServices { get; set; }
    }
}
