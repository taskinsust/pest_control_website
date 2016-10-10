using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class Gallery : BaseEntity
    {
        public Gallery() { }

        public virtual IList<GalleryImages> GalleryImages { get; set; }
    }
}
