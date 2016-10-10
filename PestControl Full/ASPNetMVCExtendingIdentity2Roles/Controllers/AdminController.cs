using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVCExtendingIdentity2Roles.App_code;
using PestControl.Core;
using NHibernate;
using PestControl.Model.Entity;
using PestControl.Services;
using PestControl.Web.Models;
using PestControl.Web.ModelBuilders;
using System.IO;

namespace ASPNetMVCExtendingIdentity2Roles.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Menu/
        private readonly IMenuService _menuService;
        private readonly IPaymentService _paymentService;
        private readonly IGalleryService _galleryService;
        private readonly IContactService _contactService;
        private readonly IEmailService _emailService;
        private ISession _session;
        private ISessionFactory _sessionFactory;
        private string _storageRoot;
        private void CreateSession()
        {
            _sessionFactory = new NhSessionFactory().GetSessionFactory();
            _session = _sessionFactory.OpenSession();
        }
        public AdminController()
        {
            CreateSession();
            _menuService = new MenuService(_session);
            _galleryService = new GalleryService(_session);
            _paymentService = new PaymentService(_session);
            _contactService = new ContactService(_session);
            _emailService = new PestControl.Services.EmailService();
            //_storageRoot = Server.MapPath("~/media");
            _storageRoot = "media";
        }

        [Authorize]
        public ActionResult MenuList(int? pageIndex)
        
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 0;
            var pageSize = 8; //Should come from config. So required some configuration code here.
            var model = new MenuAdminViewModel
            {
                MenuList = _menuService.GetMenuList(pageIndex.Value, pageSize)
            };

            return View(model);
        }

        [Authorize]
        public ActionResult SubMenuList(int? pageIndex, long? menuId)
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 0;
            var pageSize = 10; //Should come from config. So required some configuration code here.

            var model = new SubMenuAdminViewModel
            {
                SubMenuList = _menuService.GetSubMenuList(pageIndex.Value, pageSize)
            };

            return View(model);
        }

        [Authorize]
        public ActionResult EditMenu(long? id)
        {
            id = id.HasValue ? id.Value : 0;

            var model = MenuEditAdminModelBuilder.Build(id.Value, _menuService);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public virtual ActionResult EditMenu(MenuEditAdminModel model)
        {
            //model.Images = _menuService.GetById(model.Id).ServiceImageses.Select(x => new ImageViewModel { Name = x.ImageUrl }).ToList();
            model.Images = new List<ImageViewModel>();
            string storageRoot = Path.Combine(Server.MapPath("~/media"));

            if (!ModelState.IsValid) return View(model);

            MenuEditAdminModelBuilder.Save(model, _menuService, storageRoot);

            return RedirectToRoute("MenuAdminList");
        }

        [Authorize]
        public virtual ActionResult EditSubMenu(long? id)
        {
            id = id.HasValue ? id.Value : 0;

            var model = SubMenuEditAdminModelBuilder.Build(id.Value, _menuService);

            return View(model);
        }
        [HttpPost]
        //[ValidateInput(false)]
        public virtual ActionResult EditSubMenu(SubMenuEditAdminModel model)
        {
            //model.Images = _menuService.GetById(model.Id).ServiceImageses.Select(x => new ImageViewModel { Name = x.ImageUrl }).ToList();
            model.AvailableMenus = _menuService.GetMenuList().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();

            if (!ModelState.IsValid) return View(model);

            string storageRoot = Path.Combine(Server.MapPath("~/media"));

            SubMenuEditAdminModelBuilder.Save(model, _menuService, storageRoot);

            return RedirectToRoute("SubMenuAdminList", new { menuId = model.MenuId });
        }

        [Authorize]
        public ActionResult ChangeSubmenuActivation(int? pageIndex, long? id)
        {
            var submenu = _menuService.LoadSubmenuById(Convert.ToInt64(id));
            if (submenu != null)
            {
                var prevStatus = submenu.Status;
                if (prevStatus == 1)
                {
                    submenu.Status = 0;
                }
                else
                    submenu.Status = 1;
                bool isUpdateSuccessfully = _menuService.IsUpdateSuccessfully(submenu, submenu.Id);
                if (isUpdateSuccessfully)
                {
                    return RedirectToRoute("MenuAdminList", new { pageIndex = pageIndex.HasValue });
                }

            }
            return View();
        }

        [Authorize]
        public ActionResult ChangeMenuActivation(int? pageIndex, long? id)
        {
            var menu = _menuService.LoadMenuById(Convert.ToInt64(id));
            if (menu != null)
            {
                var prevStatus = menu.Status;
                if (prevStatus == 1)
                {
                    menu.Status = 0;
                }
                else
                    menu.Status = 1;
                bool isUpdateSuccessfully = _menuService.IsUpdateMenuSuccessfully(menu, menu.Id);
                if (isUpdateSuccessfully)
                {
                    return RedirectToRoute("MenuAdminList", new { pageIndex = pageIndex.HasValue });
                }

            }
            return View();
        }

        [Authorize]
        public virtual ActionResult ChangeActivation(bool? active, bool? isMenu, long? menuId, int? pageIndex, long? id)
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 0;

            if (!active.HasValue && !isMenu.HasValue && !menuId.HasValue && !id.HasValue)
                return RedirectToRoute("MenuAdminList", new { pageIndex = pageIndex.HasValue });
            if (!active.HasValue && !isMenu.HasValue && !id.HasValue)
                return RedirectToRoute("SubMenuAdminList", new { menuId = menuId.Value, pageIndex = pageIndex.HasValue });

            if (isMenu.Value)
            {
                var menu = _menuService.GetById(Convert.ToInt64(id));
                if (menu != null)
                {
                    menu.Status = active.Value ? 0 : 1;
                    _menuService.Save(menu);
                }

                return RedirectToRoute("MenuAdminList", new { pageIndex = pageIndex.HasValue });
            }
            else
            {
                var subMenu = _menuService.GetSubMenuById(id.Value);
                if (subMenu != null)
                {
                    subMenu.Status = active.Value ? 0 : 1;
                    _menuService.Save(subMenu);
                }

                return RedirectToRoute("SubMenuAdminList", new { menuId = menuId.Value, pageIndex = pageIndex.HasValue });
            }

        }

        [Authorize]
        public virtual ActionResult Delete(bool? isMenu, long? menuId, int? pageIndex, long? id)
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 0;

            if (!isMenu.HasValue && !menuId.HasValue && !id.HasValue)
                return RedirectToRoute("MenuAdminList", new { pageIndex = pageIndex.HasValue });
            if (!isMenu.HasValue && !id.HasValue)
                return RedirectToRoute("SubMenuAdminList", new { menuId = menuId.Value, pageIndex = pageIndex.HasValue });

            if (isMenu.Value)
            {
                var menu = _menuService.GetById(id.Value);
                if (menu != null)
                {
                    menu.Status = -404;
                    _menuService.Save(menu);

                    //Do something with images
                }

                return RedirectToRoute("MenuAdminList", new { pageIndex = pageIndex.HasValue });
            }
            else
            {
                var subMenu = _menuService.GetSubMenuById(id.Value);
                if (subMenu != null)
                {
                    subMenu.Status = -404;
                    _menuService.Save(subMenu);

                    //Do something with images
                }

                return RedirectToRoute("SubMenuAdminList", new { menuId = menuId.Value, pageIndex = pageIndex.HasValue });
            }
        }


        [Authorize]
        public virtual ActionResult GaleryList(int? pageIndex)
        {
            pageIndex = pageIndex.HasValue ? pageIndex.Value : 0;
            //var model = AdminGalleryViewModelBuilder.Build(pageIndex.Value, _galleryService);
            IList<Gallery> gallaryList = _galleryService.GetOk();
            return View(gallaryList);
        }

        [Authorize]
        public virtual ActionResult DeleteGallery(long id, int? pageIndex)
        {
            var gallery = _galleryService.GetGallery(id);
			pageIndex = pageIndex.HasValue ? pageIndex : 0;
            if (gallery != null)
            {
                if (gallery.GalleryImages != null)
                {
                    foreach (var image in gallery.GalleryImages)
                    {
                        if(System.IO.File.Exists(image.ImageUrl))
                            System.IO.File.Delete(image.ImageUrl);
                        //_galleryService.DeleteImage(image);
                    }
                }

                _galleryService.DeleteGallery(gallery);
            }

            return RedirectToRoute("AdminGalleryList", new { pageIndex = pageIndex.Value });
        }

        [Authorize]
        public virtual ActionResult ChangeGalleryStatus(long id, bool? activate, int? pageIndex)
        {
            activate = activate.HasValue ? activate : false;
            var gallery = _galleryService.GetGallery(id);

            if (gallery != null)
            {
                gallery.Status = activate.Value ? 1 : 0;
                _galleryService.Save(gallery);
            }

            return RedirectToRoute("AdminGalleryList", new { pageIndex = pageIndex.Value });
        }

        [Authorize]
        public virtual ActionResult GaleryImageList(int? pageIndex, long id)
        {
            pageIndex = pageIndex.HasValue ? pageIndex.Value : 0;
            var model = AdminGalleryImageViewModelBuilder.Build(id, pageIndex.Value, _galleryService);

            return View(model);
        }

        public virtual ActionResult DeleteImage(long id, long galleryId, int? pageIndex)
        {
            var image = _galleryService.GetImage(id);

            if (image != null)
            {
                var path = Path.Combine(_storageRoot, "galleries", id.ToString());

                if (Directory.Exists(path))
                {
                    var filePath = Path.Combine(path, image.ImageUrl);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _galleryService.DeleteImage(image);
            }

            return RedirectToRoute("AdminGalleryImageList", new { pageIndex = pageIndex.Value, id = galleryId });
        }

        [Authorize]
        public virtual ActionResult ChangeGalleryImageStatus(long id, long galleryId, bool? activate, int? pageIndex)
        {
            activate = activate.HasValue ? activate : false;
            var image = _galleryService.GetImage(id);

            if (image != null)
            {
                image.Status = activate.Value ? 1 : 0;
                _galleryService.Save(image);
            }

            return RedirectToRoute("AdminGalleryImageList", new { pageIndex = pageIndex.Value, id = galleryId });
        }

        [Authorize]
        public virtual ActionResult CreateGallery(long? id)
        {
            id = id.HasValue ? id : 0;
            var model = AdminGalleryEditModelBuilder.Build(id.Value, _galleryService);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public virtual ActionResult CreateGallery(AdminGalleryEditModel model)
        {
            if (!ModelState.IsValid) return View(model);
            AdminGalleryEditModelBuilder.Save(model, _galleryService);

            return RedirectToRoute("AdminGalleryList");
        }

        [Authorize]
        public virtual ActionResult CreateImage(long? id, long? galleryId)
        {
            id = id.HasValue ? id : 0;
            galleryId = galleryId.HasValue ? galleryId : 0;
            //var model = AdminGalleryImageEditModelBuilder.Build(id.Value, galleryId.Value, _galleryService);
            IList<Gallery> galleryList = _galleryService.GetOk();
            var imageObj = new GalleryImages();
            ViewBag.gallery = new SelectList(galleryList, "Id", "Name");
            return View(imageObj);
        }
        
        [HttpPost]
        [Authorize]
        public virtual ActionResult CreateImage(GalleryImages model,HttpPostedFileBase filebase){
        
            var file = Request.Files[1];
            var validImageTypes = new string[]
                {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            //if (!ModelState.IsValid) return View(model);

            //if (model.Image == null || model.Image.ContentLength == 0)
            //{
            //    ModelState.AddModelError("ImageUrl", "This field is required");
            //}
            //else if (!validImageTypes.Contains(model.Image.ContentType))
            //{
            //    ModelState.AddModelError("ImageUrl", "Please choose either a GIF, JPG or PNG image.");
            //}

            //var image = AdminGalleryImageEditModelBuilder.Save(model, _galleryService);

            //if(model.Image.HasFile())
            //{
            //    var fileName = model.Image.FileName;
            //    var path = Path.Combine(_storageRoot, "galleries", model.GalleryId.ToString());

            //    if(!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }

            //    var filePath = Path.Combine(path + fileName);
            //    if (System.IO.File.Exists(filePath))
            //    {
            //        model.Image.SaveAs(filePath);
            //    }

            //    image.ImageUrl = fileName;

            //    _galleryService.Save(image);
            //}

            return RedirectToRoute("AdminGalleryList");
        }

        [Authorize]
        public ActionResult PaymentList(int? pageIndex)
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 0;
            var pageSize = App.Configurations.ItemPerPage.Value;

            var model = new PaymentListViewModel
            {
                Payments = _paymentService.GetAllPayments(pageIndex.Value, pageSize)
            };

            return View(model);
        }

        [Authorize]
        public ActionResult ContactList(int? pageIndex)
        {
            pageIndex = pageIndex.HasValue ? pageIndex : 0;
            var pageSize = App.Configurations.ItemPerPage.Value;

            var model = new ContactListViewModel
            {
                Contacts = _paymentService.GetAllContacts(pageIndex.Value, pageSize)
            };

            return View(model);
        }

        [Authorize]
        public ActionResult EditContact(long? id)
        {
            id = id.HasValue ? id.Value : 0;
            var model = ContactEditAdminModelBuilder.Build(id.Value, _contactService);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditContact(ContactEditAdminModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                var scedual = DateTime.UtcNow;
                //DateTime.TryParse(model.Schedual, out scedual);

                var contact = new Contact
                {
                    Id = model.Id,
                    Address = model.Address,
                    City = model.City,
                    ContactStatus = ContactStatusText.Pending,
                    CreationDate = DateTime.UtcNow,
                    ModificationDate = DateTime.UtcNow,
                    Phone = model.Phone,
                    Schedual = model.Schedual,
                    State = model.State,
                    ZipCode = model.PostalCode,
                    FirstName = model.Firstname,
                    LastName = model.LastName,
                    Email = model.Email,
                    Message = model.Message
                };
                var isUpdated = _contactService.UpdateContact(contact);
                if (isUpdated)
                {
                    ViewBag.SuccessMessage = "Contact successfully updated!";
                }
                return RedirectToRoute("ContactAdminList");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Unexpected error ocour. Please inform your admin";
                return View("Home");
            }
        }

        [Authorize]
        public ActionResult ApproveContact(long Id)
        {
            var contact = _contactService.GetContact(Id);
            //contact.ContactStatus = ContactStatusText.Approved;

            bool isUpdateSucessful = _contactService.ChangeContactStatus(contact, ContactStatusText.Approved);
            if (isUpdateSucessful)
            {

                var adminEmail = App.Configurations.AdminEmail.Value;
                _emailService.SendContactApprovalLinkToClient(contact.FirstName + " " + contact.LastName, contact.Email, contact.Id.ToString());
                //_emailService.SendContactApproval(contact.FirstName + " " + contact.LastName, adminEmail); 
            }
            else
            {
                ViewBag.ErrorMessage = "Approvel failed. please inform your administrator.";
            }
            return RedirectToRoute("ContactAdminList");
        }

    }
}