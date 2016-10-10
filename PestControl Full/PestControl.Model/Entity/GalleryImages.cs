using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class GalleryImages : BaseEntity
    {
        public GalleryImages() { }

        public virtual string ImageUrl { get; set; }
        public virtual string ThumbUrl { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}
