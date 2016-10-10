using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PestControl.Model.Entity;

namespace ASPNetMVCExtendingIdentity2Roles.Controllers
{
    public class ProductServiceController : Controller
    {
        //
        // GET: /ProductService/
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var service = new ProductServices();
            return View(service);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ProductServices productServices)
        {
            return View();
        }
	}
}