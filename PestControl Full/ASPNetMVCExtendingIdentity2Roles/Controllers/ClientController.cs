using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVCExtendingIdentity2Roles.App_code;
using NHibernate;
using PestControl.Model.Entity;
using PestControl.Services;
using ASPNetMVCExtendingIdentity2Roles.Models;
using PestControl.Core;

namespace ASPNetMVCExtendingIdentity2Roles.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        private readonly IMenuService _menuService;
        private readonly IGalleryService _galleryService;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;
        private readonly IContactService _contactService;
        private ISession _session;
        private ISessionFactory _sessionFactory;
        private string _storageRoot;

         private void CreateSession()
        {
            _sessionFactory = new NhSessionFactory().GetSessionFactory();
            _session = _sessionFactory.OpenSession();
        }
         public ClientController()
        {
            CreateSession();
            _emailService = new PestControl.Services.EmailService();
            _menuService = new MenuService(_session);
            _galleryService = new GalleryService(_session);
            _paymentService = new PaymentService(_session);
            _contactService = new ContactService(_session);
           _storageRoot = "media";
        }
         public ActionResult Index()
         {
             return View("_HomePageLayout");
             //return View("_template");
         }

        public ActionResult GalleryView()
        {
            IList<Gallery> galleryList = _galleryService.GetOk();
            ViewBag.GalleryObjList = galleryList;
            return View("GalleryView", galleryList);
        }

        public ActionResult Services()
        {
            return View("_ServicePageLayout");
        }
        public ActionResult Contact(string mes)
        {
            var model = new ContactViewModel();
            if (mes.IsNotNullOrWhiteSpace())
            {
                ViewBag.SuccessMessage = mes;
            }
            return View("");
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var scedual = DateTime.UtcNow;
            //DateTime.TryParse(model.Schedual, out scedual);

            var contact = new Contact
            {
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
            _contactService.Save(contact);
            var message = "Your contact request successfully submitted";

            _emailService.SendScheduleRequestToAdmin(contact.FirstName + " " + contact.LastName, contact);
            _emailService.SendScheduleRequestSubmitConfirmationToClient(contact.FirstName + " " + contact.LastName, contact);
            return RedirectToAction("Contact", new { mes = message });
        }

        public ActionResult Payment(string mes)
        {
            var model = new PaymentEditModel
            {
                AvaiableTypes = _paymentService.GetAllTypes().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList()
            };

            if(mes.IsNotNullOrWhiteSpace())
            {
                ViewBag.SuccessMessage = mes;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Payment(PaymentEditModel model)
        {
            model.AvaiableTypes = _paymentService.GetAllTypes().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            if (!ModelState.IsValid) return View(model);

            var expireDate = DateTime.UtcNow;
            //DateTime.TryParse(model.ExpireDate, out expireDate);
            var cardNo = model.CardNo.Replace(" ", "");
            var payment = new Payment
            {
                FirstName = model.Firstname,
                LastName = model.LastName,
                Email = model.Email,
                Amount = model.Amount,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.PostalCode,
                CardNo = cardNo,
                SecurityCode = model.SecurityCode,
                CreationDate = DateTime.UtcNow,
                ModificationDate = DateTime.UtcNow,
                Phone = model.Phone,
                InvoiceNo = model.Invoice,
                Message = model.Message,
                ExpireDate = model.ExpireDate   ,
                CardType = _paymentService.GetCardType(Convert.ToInt64(model.CardType))
            };

            _paymentService.Save(payment);

            var adminEmail = App.Configurations.AdminEmail.Value;

            _emailService.SendPaymentMessage(payment.Email, payment, false);
            _emailService.SendPaymentMessage(adminEmail, payment, true);

            var message = "Your payment is successfull";

            return RedirectToAction("Payment", new { mes = message });
        }

        public ActionResult ConfirmContactApproval(long id)
        {
            var contact = _contactService.GetContact(id);

            if(contact != null)
            {
                if (contact.ContactStatus == 2)
                {
                    var message = "Your schedule request link is already approved! please contact with our office.";
                    return RedirectToAction("Contact", new { mes = message });
                }
                else if(contact.ContactStatus == 0){
                    var message = "Your schedule request link is not approved by office! please contact with our office.";
                    return RedirectToAction("Contact", new { mes = message });
                }
                else
                {
                    bool isConfirmed = _contactService.ChangeContactStatus(contact, ContactStatusText.Confirmed);
                    if (isConfirmed)
                    {
                        var message = "Your schedule request is approved! Office will contact you soon!";
                        string name = contact.FirstName + " " + contact.LastName;
                        _emailService.SendContactConfirmationApprovalNotificationEmailToAdmin(name, contact);
                        return RedirectToAction("Contact", new { mes = message }); 
                    }
                    else
                    {
                        var message = "Something went wrong! please contact with our office.";
                        return RedirectToAction("Contact", new { mes = message });
                    }
                }
            }
            else
            {
                var message = "Your schedule request link is not valid one! please contact with our office.";
                return RedirectToAction("Contact", new { mes = message });
            }
        }
	}
}