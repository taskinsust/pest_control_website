using ASPNetMVCExtendingIdentity2Roles.Controllers;
using PestControl.Web.Models;
using PestControl.Core;
using PestControl.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PestControl.Services;
using PestControl.Model.Entity;
using System.IO;

namespace PestControl.Web.ModelBuilders
{
    public static class AdminGalleryEditModelBuilder
    {
        public static AdminGalleryEditModel Build(long id, IGalleryService galleryService)
        {
            var gallery = galleryService.GetGallery(id);
            var model = new AdminGalleryEditModel();

            if (gallery != null)
            {
                model.Id = gallery.Id;
                model.Name = gallery.Name;
                model.Active = gallery.Status > 0;
            }

            return model;
        }

        public static void Save(AdminGalleryEditModel model, IGalleryService galleryService)
        {
            var gallery = galleryService.GetGallery(model.Id);

            if (gallery == null) gallery = new Gallery { CreationDate = DateTime.UtcNow, ModificationDate = DateTime.UtcNow };
            model.Active = true;
            gallery.Id = model.Id;
            gallery.Name = model.Name;
            gallery.Status = model.Active ? 1 : 0;

            galleryService.Save(gallery);
        }
    }
    public static class AdminGalleryImageEditModelBuilder
    {
        public static AdminGalleryImageEditModel Build(long id, long galleryId, IGalleryService galleryService)
        {
            var image = galleryService.GetImage(id);
            var model = new AdminGalleryImageEditModel();

            if (image != null)
            {
                model.Id = image.Id;
                model.Name = image.Name;
                model.ImageName = image.ImageUrl;
                model.Active = image.Status > 0;
            }

            model.GalleryId = galleryId;

            return model;
        }

        public static GalleryImages Save(AdminGalleryImageEditModel model, IGalleryService galleryService)
        {
            var image = galleryService.GetImage(model.Id);

            if (image == null) image = new GalleryImages { CreationDate = DateTime.UtcNow, ModificationDate = DateTime.UtcNow };

            image.Id = model.Id;
            image.Name = model.Name;
            image.ImageUrl = model.ImageName;
            image.Status = model.Active ? 1 : 0;

            galleryService.Save(image);

            return image;
        }
    }
    public static class AdminGalleryViewModelBuilder
    {
        public static AdminGalleryViewModel Build(int pageIndex, IGalleryService galleryService)
        {
            var pageSize = 8;
            var model = new AdminGalleryViewModel();

            model.Galleries = galleryService.GalleryList(pageIndex, pageSize);

            return model;
        }
    }
    public static class AdminGalleryImageViewModelBuilder
    {
        public static AdminGalleryImageViewModel Build(long galleryId, int pageIndex, IGalleryService galleryService)
        {
            var pageSize = 8;
            var model = new AdminGalleryImageViewModel();

            model.GalleryId = galleryId;
            model.Images = galleryService.ImageList(galleryId, pageIndex, pageSize);

            return model;
        }
    }
    public static class MenuEditAdminModelBuilder
    {
        public static MenuEditAdminModel Build(long id, IMenuService menuService)
        {
            var menu = menuService.GetById(id);
            var model = new MenuEditAdminModel();

            if (menu != null)
            {
                model.Id = menu.Id;
                model.FriendlyUrl = menu.FriendlyUrl;
                model.ShortDescription = menu.ShortDescription;
                model.FullDescription = menu.Description;
                model.Images = menu.ServiceImageses.Select(x => new ImageViewModel { Name = x.ThumbUrl }).ToList();
            }

            return model;
        }

        public static void Save(MenuEditAdminModel model, IMenuService menuService, string storageRoot)
        {
            var menu = menuService.GetById(model.Id);

            menu = menu != null ? menu : new Menu();

            if (model.Name != menu.Title)
                menu.FriendlyUrl = menuService.CreateFriendlyUrl(model.Name);
            model.Active = true;
            menu.Title = model.Name;
            menu.Description = model.FullDescription;
            menu.ShortDescription = model.ShortDescription;
            menu.Status = model.Active ? 1 : 0;

            menuService.Save(menu);

            //Save images

            //var path = Path.Combine(storageRoot, "sub-menu", subMenu.Id.ToString());

            //if(model.Image1.HasFile())
            //{
            //    var fileName = Guid.NewGuid().NewGuidString() + Path.GetExtension(model.Image1.FileName);

            //}

        }
    }
    public static class SubMenuEditAdminModelBuilder
    {
        public static SubMenuEditAdminModel Build(long id, IMenuService menuService)
        {
            var subMenu = menuService.GetSubMenuById(id);
            var model = new SubMenuEditAdminModel();

            if (subMenu != null)
            {
                model.Id = subMenu.Id;
                model.FriendlyUrl = subMenu.FriendlyUrl;
                model.ShortDescription = subMenu.ShortDescription;
                model.FullDescription = subMenu.ServiceDescription;
                model.Name = subMenu.Title;
                //model.Images = subMenu.ServiceImageses.Select(x => new ImageViewModel { Name = x.ThumbUrl }).ToList();
                model.MenuId = subMenu.Menu.Id.ToString();

            }
            model.AvailableMenus = menuService.GetMenuList().Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }).ToList();
            return model;
        }

        public static void Save(SubMenuEditAdminModel model, IMenuService menuService, string storageRoot)
        {
            var subMenu = menuService.GetSubMenuById(model.Id);

            subMenu = subMenu != null ? subMenu : new ProductServices();

            if (model.Name != subMenu.Title)
                subMenu.FriendlyUrl = menuService.CreateFriendlyUrl(model.Name);
            model.Active = true;
            subMenu.Title = model.Name;
            subMenu.ServiceDescription = model.FullDescription;
            subMenu.ShortDescription = model.ShortDescription;
            subMenu.Status = model.Active ? 1 : 0;
            // subMenu.Status = model.Active;
            subMenu.Menu = menuService.GetById(Convert.ToInt64(model.MenuId));
            //var service = new ServiceImages();
            //service.ImageUrl = storageRoot;
            //subMenu.ServiceImageses.Add(service);
            menuService.Save(subMenu);

            //Save images

            //var path = Path.Combine(storageRoot, "sub-menu", subMenu.Id.ToString());

            //if(model.Image1.HasFile())
            //{
            //    var fileName = Guid.NewGuid().NewGuidString() + Path.GetExtension(model.Image1.FileName);

            //}

        }
    }
    public static class ContactEditAdminModelBuilder
    {
        public static ContactEditAdminModel Build(long id, IContactService contactService)
        {
            var contact = contactService.GetContact(id);
            var model = new ContactEditAdminModel();

            if (contact != null)
            {
                model.Id = contact.Id;
                model.Firstname = contact.FirstName;
                model.LastName = contact.LastName;
                model.Email = contact.Email;
                model.Phone = contact.Phone;
                model.Address = contact.Address;
                model.City = contact.City;
                model.State = contact.State;
                model.PostalCode = contact.ZipCode;
                model.Schedual = contact.Schedual;
                model.Message = contact.Message;
            };
            return model;
        }

        public static void Save(ContactEditAdminModel model, IContactService contactService)
        {
        }
    }
}