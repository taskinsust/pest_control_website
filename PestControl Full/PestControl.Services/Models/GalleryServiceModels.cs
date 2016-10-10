using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControl.Services.Models
{
    public class GalleryShortDetailsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDisable { get; set; }
    }

    public class GalleryImageShortDetailsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsDisable { get; set; }
    }
}
