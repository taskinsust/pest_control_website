using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class ProductServices:BaseEntity
    {
        public ProductServices() { }
        public virtual string ShortDescription { get; set; }
        [UIHint("tinymce_jquery_full")]
        public virtual string ServiceDescription { get; set; }
        public virtual string FriendlyUrl { get; set; }
        public virtual string Title { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual IList<ServiceImages> ServiceImageses { get; set; }

        
    }
}
