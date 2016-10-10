using PestControl.Web.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPNetMVCExtendingIdentity2Roles
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Routes for Admin

            routes.MapRoute(
               name: "ChangeSubmenuActivation",
               url: "admin/ChangeSubmenu-Activation",
               defaults: new { controller = "Admin", action = "ChangeSubmenuActivation" }
           );

            routes.MapRoute(
               name: "ChangeMenuActivation",
               url: "admin/ChangeMenu-Activation",
               defaults: new { controller = "Admin", action = "ChangeMenuActivation" }
           );

            routes.MapRoute(
               name: "MenuAdminList",
               url: "admin/all-menu",
               defaults: new { controller = "Admin", action = "MenuList" }
           );

            routes.MapRoute(
               name: "SubMenuAdminList",
               url: "admin/all-sub-menu",
               defaults: new { controller = "Admin", action = "SubMenuList" }
           );

            routes.MapRoute(
               name: "EditMenu",
               url: "admin/menu/create",
               defaults: new { controller = "Admin", action = "EditMenu" }
           );

            routes.MapRoute(
               name: "EditSubMenu",
               url: "admin/sub-menu/create",
               defaults: new { controller = "Admin", action = "EditSubMenu" }
           );

            routes.MapRoute(
              name: "DynamicMenu",
              url: "dynamic-menu",
              defaults: new { controller = "Menu", action = "DynamicMenu" }
          );

            routes.MapRoute(
               name: "ChangeActivation",
               url: "admin/change-activation",
               defaults: new { controller = "Admin", action = "ChangeActivation" }
           );

            routes.MapRoute(
               name: "Delete",
               url: "admin/delete",
               defaults: new { controller = "Admin", action = "Delete" }
           );

            routes.MapRoute(
               name: "AdminGalleryList",
               url: "admin/gallery-list",
               defaults: new { controller = "Admin", action = "GaleryList" }
           );

            routes.MapRoute(
               name: "AdminDeleteGallery",
               url: "admin/gallery/delete",
               defaults: new { controller = "Admin", action = "DeleteGallery" }
           );

            routes.MapRoute(
               name: "AdminChangeGalleryStatus",
               url: "admin/gallery/change-status",
               defaults: new { controller = "Admin", action = "ChangeGalleryStatus" }
           );

            routes.MapRoute(
              name: "AdminGalleryImageList",
              url: "admin/image-list",
              defaults: new { controller = "Admin", action = "GaleryImageList" }
          );

            routes.MapRoute(
               name: "AdminDeleteImage",
               url: "admin/image/delete",
               defaults: new { controller = "Admin", action = "DeleteImage" }
           );

            routes.MapRoute(
               name: "AdminChangeImageStatus",
               url: "admin/image/change-status",
               defaults: new { controller = "Admin", action = "ChangeGalleryImageStatus" }
           );

            routes.MapRoute(
               name: "CreateGallery",
               url: "admin/gallery/create",
               defaults: new { controller = "Admin", action = "CreateGallery" }
           );

            routes.MapRoute(
               name: "CreateImage",
               url: "admin/image/create",
               defaults: new { controller = "Admin", action = "CreateImage" }
           );

            routes.MapRoute(
               name: "PaymentAdminList",
               url: "admin/payment-list",
               defaults: new { controller = "Admin", action = "PaymentList" }
           );

            routes.MapRoute(
              name: "ContactAdminList",
              url: "admin/contact-list",
              defaults: new { controller = "Admin", action = "ContactList" }
          );
            routes.MapRoute(
              name: "EditContact",
              url: "admin/edit-contact",
              defaults: new { controller = "Admin", action = "EditContact" }
          );
            routes.MapRoute(
              name: "ApproveContact",
              url: "admin/contact-approve",
              defaults: new { controller = "Admin", action = "ApproveContact" }
          );

            #endregion

            #region Routes for Account
            routes.MapRoute(
               name: "Registration",
               url: "register_AlfaJ_PestControl_ServiceS_admin_user",
               defaults: new { controller = "Account", action = "Register" }
            );
            routes.MapRoute(
                 name: "Login",
                 url: "admin/login",
                 defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapRoute(
                name: "Home-Index",
                url: "HomeIndex",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "SignOut",
                url: "signout",
                defaults: new { controller = "Account", action = "LogOff" }
            );
            #endregion

            #region Routes for Client
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Client", action = "Index" }
            );
            routes.MapRoute(
                name: "Gallery",
                url: "gallery",
                defaults: new { controller = "Client", action = "GalleryView" }
            );
            routes.MapRoute(
                name: "Contact",
                url: "contact-us",
                defaults: new { controller = "Client", action = "Contact" }
            );
            routes.MapRoute(
                name: "ContactApproval",
                url: "contact-approval",
                defaults: new { controller = "Client", action = "ConfirmContactApproval" }
            );
            routes.MapRoute(
                name: "Payment",
                url: "payment",
                defaults: new { controller = "Client", action = "Payment" }
            );

            #endregion

            #region Route for Menu

            routes.MapRoute(
               name: "Menu",
               url: "menu/create",
               defaults: new { controller = "Menu", action = "Create" }
           );

            #endregion

            #region Route for Service

            routes.MapRoute(
               name: "Service",
               url: "{friendlyUrl}",
               defaults: new { controller = "Menu", action = "Details", friendlyUrl = UrlParameter.Optional },
               constraints: new { friendlyUrl = new FriendlyURLConstraint() }
           );

            #endregion

            #region Route for GalleryImages
            routes.MapRoute(
               name: "ImageGalleryUplopad",
               url: "ImageGallery/Uplopad",
               defaults: new { controller = "ImageGallery", action = "Create" }
           );
            routes.MapRoute(
               name: "ImageGalleryUplopading",
               url: "ImageGallery/Uplopading",
               defaults: new { controller = "ImageGallery", action = "SaveGalleryImages" }
           );
            routes.MapRoute(
               name: "ImageGallery",
               url: "Dashboard",
               defaults: new { controller = "ImageGallery", action = "Dashboard" }
           );


            #endregion

            #region Route For Services
            // routes.MapRoute(
            //    name: "adminServiceAdd",
            //    url: "admin/Service/Add",
            //    defaults: new { controller = "ProductService", action = "Create" }
            //);

            #endregion
        }
    }
}
