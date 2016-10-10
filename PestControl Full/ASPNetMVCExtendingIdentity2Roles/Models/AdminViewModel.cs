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
    public class MenuAdminViewModel
    {
        public IPagedList<MenuShortDetailModel> MenuList { get; set; }
    }

    public class SubMenuAdminViewModel
    {
        public IPagedList<MenuShortDetailModel> SubMenuList { get; set; }
    }

    public class MenuEditAdminModel
    {
        public long Id { get; set; }
        public string FriendlyUrl { get; set; }
        [Required(ErrorMessage = "Please enter the menu name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a short description.")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Please enter description.")]
        public string FullDescription { get; set; }

        public bool Active { get; set; }

        public IList<ImageViewModel> Images { get; set; }

        public HttpPostedFileBase Image1 { get; set; }
        public HttpPostedFileBase Image2 { get; set; }
        public HttpPostedFileBase Image3 { get; set; }
    }

    public class SubMenuEditAdminModel
    {
        public long Id { get; set; }
        public string FriendlyUrl { get; set; }
        [Required(ErrorMessage = "Please enter the menu name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a short description.")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Please enter description.")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string FullDescription { get; set; }

        public bool Active { get; set; }

        public string MenuId { get; set; }
        public IList<SelectListItem> AvailableMenus { get; set; }

        public IList<ImageViewModel> Images { get; set; }

        public HttpPostedFileBase Image1 { get; set; }
        public HttpPostedFileBase Image2 { get; set; }
        public HttpPostedFileBase Image3 { get; set; }
    }

    public class ImageViewModel
    {
        public string Name { get; set; }
    }

    public class AdminGalleryViewModel
    {
        public IPagedList<GalleryShortDetailsModel> Galleries { get; set; }
    }

    public class AdminGalleryImageViewModel
    {
        public long GalleryId { get; set; }
        public IPagedList<GalleryImageShortDetailsModel> Images { get; set; }
    }

    public class AdminGalleryEditModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class AdminGalleryImageEditModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public bool Active { get; set; }
        public long GalleryId { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
    public class PaymentListViewModel
    {
        public IPagedList<PaymentShortDetails> Payments { get; set; }
    }

    public class ContactListViewModel
    {
        public IPagedList<ContactShortDetails> Contacts { get; set; }
    }

    public class ContactEditAdminModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter state.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter zip/postal code.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered a valid phone number.")]
        public virtual string Phone { get; set; }
        [Required(ErrorMessage = "Please enter a message.")]
        public virtual string Message { get; set; }
        public DateTime Schedual { get; set; }
    }

}