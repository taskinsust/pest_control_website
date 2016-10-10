using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVCExtendingIdentity2Roles.App_code;
using NHibernate;
using PestControl.Model.Entity;
using PestControl.Services;
using PestControl.Web.Models;

namespace ASPNetMVCExtendingIdentity2Roles.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        private readonly IMenuService _menuService;
        private ISession _session;
        private ISessionFactory _sessionFactory;
        private void CreateSession()
        {
            _sessionFactory = new NhSessionFactory().GetSessionFactory();
            _session = _sessionFactory.OpenSession();
        }
        public MenuController()
        {
            CreateSession();
            _menuService = new MenuService(_session);
        }        

        [Authorize]
        public ActionResult Create()
        {
            var menu = new Menu();
            menu.Description = "DEs";
            menu.Name = "PestControl";
            menu.CreationDate = DateTime.Now;
            _menuService.Save(menu);

            var MenuList = _menuService.GetMenuList(0, 8);
            return View();
        }

        public virtual ActionResult DynamicMenu()
        {
            var model = new DynamicMenuViewModel
            {
                Menus = _menuService.GetActiveMenusOnly().Select(x =>
                new MenuViewDetails
                {
                    Name = x.Title,
                    Url = Url.RouteUrl("Service", new { friendlyUrl = x.FriendlyUrl }),
                    SubMenus = _menuService.GetActiveSubMenusOnly(x.Id).Select(y =>
                        new SubMenuViewDetails
                        {
                            Name = y.Title,
                            Url = Url.RouteUrl("Service", new { friendlyUrl = y.FriendlyUrl })
                        }).ToList()
                }).ToList()
            };

            return PartialView("_DynamicMenu", model);
        }

        [Authorize]
        public virtual ActionResult Details(string friendlyUrl)
        {
            var menu = _menuService.GetMenuByFriendlyUrl(friendlyUrl);

            if (menu != null)
            {
                var model = new ServiceDetailsViewModel
                {
                    Name = menu.Name,
                    FullDescription = menu.Description,
                    ShortDescription = menu.ShortDescription,
                    Images = menu.ServiceImageses.Select(x => new ServiceImageDetails { Name = x.Name, Url = x.ImageUrl }).ToList()
                };

                return View(model);
            }

            var subMenu = _menuService.GetSubMenuByFriendlyUrl(friendlyUrl);

            if (subMenu != null)
            {
                var model = new ServiceDetailsViewModel
                {
                    Name = subMenu.Title,
                    FullDescription = subMenu.ServiceDescription,
                    ShortDescription = subMenu.ShortDescription,
                    //Images = subMenu.ServiceImageses.Select(x => new ServiceImageDetails { Name = x.Name, Url = x.ImageUrl }).ToList()
                };

                return View(model);
            }

            return RedirectToRoute("Home");
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}