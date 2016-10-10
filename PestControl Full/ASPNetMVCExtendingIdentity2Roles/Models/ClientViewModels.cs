using PestControl.Core;
using PestControl.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ASPNetMVCExtendingIdentity2Roles.Models
{
    public class PaymentEditModel
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter card number.")]
        [CreditCard(ErrorMessage = "Please enter a valid credit card number")]
        [Display(Name = "Card No")]
        public string CardNo { get; set; }

        [Required(ErrorMessage = "Please enter security code.")]
        [Display(Name = "Security Code")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "Please enter card expire date.")]
        [Display(Name = "Expire Date")]
        public DateTime ExpireDate { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter minimum $1 or more.")]
        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter invoice no.")]
        [Display(Name = "Invoice No")]
        public int Invoice { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Please enter city.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter state.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter zip/postal code.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered a valid phone number.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public string Message { get; set; }
        
        [Display(Name="Card Type")]
        public string CardType { get; set; }

        public IList<SelectListItem> AvaiableTypes { get; set; }
    }

    public class ContactViewModel
    {
        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email.")]
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
