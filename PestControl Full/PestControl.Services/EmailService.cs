
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.IO;
using PestControl.Services.Base;
using PestControl.Core;
using PestControl.Model.Entity;

namespace PestControl.Services
{
    public interface IEmailService
    {
        void SendPaymentMessage(string receiverEmail, Payment payment, bool admin);
        void SendContactApprovalLinkToClient(string name, string email, string id);
        void SendScheduleRequestToAdmin(string name, Contact contact);
        void SendContactApproval(string name, string email);
        void SendScheduleRequestSubmitConfirmationToClient(string name, Contact contact);
        void SendContactConfirmationApprovalNotificationEmailToAdmin(string name, Contact contact);
    }
    public class EmailService : BaseService, IEmailService
    {
        protected string TemplateFolder { get; private set; }

        public EmailService()
        {
            if (HttpContext.Current != null)
            {
                string path = HttpContext.Current.Server.MapPath(App.Configurations.EmailTemplatePath.Value);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                TemplateFolder = path;
            }
        }

        public void SendPaymentMessage(string receiverEmail, Payment payment, bool admin)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.PaymentEmailName.Value);
            string subject = App.Configurations.PaymentEmailSubject.Value;


            body = body.Replace("$ReceiverName$", (admin ? "Admin" : payment.FirstName + " " + payment.LastName));
            body = body.Replace("$Logo$", LinkHelper.Domain + "~/Content/assets/images/logo.png");
            body = body.Replace("$To$", (admin ? "client's" : "your"));
            body = body.Replace("$Recipient$", receiverEmail);

            /*Billing*/
            body = body.Replace("$FirstName$", payment.FirstName);
            body = body.Replace("$LastName$", payment.LastName);
            body = body.Replace("$Email$", payment.Email);
            body = body.Replace("$Phone$", payment.Phone);
            body = body.Replace("$Invoice$", payment.InvoiceNo.ToString());
            body = body.Replace("$Amount$", payment.Amount.ToString());
            body = body.Replace("$CardNo$", payment.CardNo.CreditCardViewFormat());
            body = body.Replace("$SecurityCode$", payment.SecurityCode);
            body = body.Replace("$ExpireDate$", payment.ExpireDate.ToString("dd-MMMM-yyyy"));
            body = body.Replace("$Address$", payment.Address);
            body = body.Replace("$City$", payment.City);
            body = body.Replace("$Zip$", payment.ZipCode);
            body = body.Replace("$State$", payment.State);
            body = body.Replace("$Message$", payment.Message);

            EmailSender.Send(receiverEmail, subject, body);
        }

        public void SendContactApprovalLinkToClient(string name, string email, string id)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.ContactApproveMail.Value);
            string subject = App.Configurations.ContactApproveSubject.Value;

            body = body.Replace("$Logo$", LinkHelper.Domain + App.Configurations.SiteLogoPath.Value);
            //body = body.Replace("$Link$", LinkHelper.Domain + (LinkHelper.Domain.EndsWith("/") ? "" : "/") + "contact-approval?code={0}".FormatWith(id));
            body = body.Replace("$Link$", LinkHelper.Domain + (LinkHelper.Domain.EndsWith("/") ? "" : "/") + "contact-approval?id="+id);

            body = body.Replace("$Recipient$", email);
            body = body.Replace("$Name$", name);

            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(email, name);

            EmailSender.Send(receivers, subject, body);
        }

        public void SendContactApproval(string name, string email)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.ContactApproveMail.Value);
            string subject = App.Configurations.ContactApproveSubject.Value;

            body = body.Replace("$Logo$", LinkHelper.Domain + App.Configurations.SiteLogoPath);
            body = body.Replace("$Recipient$", email);
            body = body.Replace("$Name$", name);

            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(email, name);
            EmailSender.Send(receivers, subject, body);
        }
        public void SendScheduleRequestToAdmin(string name, Contact contact)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            var adminEmail = App.Configurations.AdminEmail.Value;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.ContactReceivedMail.Value);
            string subject = App.Configurations.ContactReceivedSubject.Value;

            body = body.Replace("$Logo$", LinkHelper.Domain + App.Configurations.SiteLogoPath.Value);
            body = body.Replace("$Recipient$", adminEmail);
            body = body.Replace("$FirstName$", contact.FirstName);
            body = body.Replace("$LastName$", contact.LastName);
            body = body.Replace("$Email$", contact.Email);
            body = body.Replace("$Phone$", contact.Phone);
            body = body.Replace("$Address$", contact.Address);
            body = body.Replace("$City$", contact.City);
            body = body.Replace("$State$", contact.State);
            body = body.Replace("$Zip$", contact.ZipCode);
            body = body.Replace("$Schedual$", contact.Schedual.ToString("dd-MMMM-yyyy H:mm"));
            body = body.Replace("$Message$", contact.Message);

            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(adminEmail, name);

            EmailSender.Send(receivers, subject, body);
        }

        public void SendScheduleRequestSubmitConfirmationToClient(string name, Contact contact)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            var adminEmail = App.Configurations.AdminEmail.Value;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.ContactSubmitedMail.Value);
            string subject = App.Configurations.ContactSubmitedSubject.Value;

            body = body.Replace("$Logo$", LinkHelper.Domain + App.Configurations.SiteLogoPath.Value);
            body = body.Replace("$Recipient$", adminEmail);
            body = body.Replace("$ClientName$", name);
            body = body.Replace("$Email$", contact.Email);
            body = body.Replace("$Phone$", contact.Phone);
            body = body.Replace("$Address$", contact.Address);
            body = body.Replace("$City$", contact.City);
            body = body.Replace("$State$", contact.State);
            body = body.Replace("$Zip$", contact.ZipCode);
            body = body.Replace("$Schedual$", contact.Schedual.ToString("dd-MMMM-yyyy H:mm"));
            body = body.Replace("$Message$", contact.Message);

            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(contact.Email, name);
            EmailSender.Send(receivers, subject, body);
        }

        public void SendContactConfirmationApprovalNotificationEmailToAdmin(string name, Contact contact)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;
            var adminEmail = App.Configurations.AdminEmail.Value;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.ContactApprovalConfirmationNotificationMail.Value);
            string subject = App.Configurations.ContactApprovalConfirmationNotificationSubject.Value;

            body = body.Replace("$Logo$", LinkHelper.Domain + App.Configurations.SiteLogoPath.Value);
            body = body.Replace("$Recipient$", adminEmail);
            body = body.Replace("$ClientName$", name);
            body = body.Replace("$Email$", contact.Email);
            body = body.Replace("$Phone$", contact.Phone);
            body = body.Replace("$Address$", contact.Address);
            body = body.Replace("$City$", contact.City);
            body = body.Replace("$State$", contact.State);
            body = body.Replace("$Zip$", contact.ZipCode);
            body = body.Replace("$Schedual$", contact.Schedual.ToString("dd-MMMM-yyyy H:mm"));
            body = body.Replace("$Message$", contact.Message);

            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(adminEmail, name);
            EmailSender.Send(receivers, subject, body);
        }
    }
}
