using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PestControl.Core
{   
    public static class HttpPostedFileBaseExtension
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
    }
}
