using PestControl.Core;
using PestControl.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PestControl.Web.Models
{
   public class ServiceDetailsViewModel
   {
       public string Name { get; set; }
       public string ShortDescription { get; set; }
       public string FullDescription { get; set; }
       public IList<ServiceImageDetails> Images { get; set; }
   }

    public class ServiceImageDetails
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class DynamicMenuViewModel
    {
        public IList<MenuViewDetails> Menus { get; set; }
    }

    public class MenuViewDetails
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public IList<SubMenuViewDetails> SubMenus { get; set; }
    }

    public class SubMenuViewDetails
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}