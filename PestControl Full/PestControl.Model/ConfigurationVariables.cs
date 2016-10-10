using PestControl.Core.WebContext;

namespace PestControl.Model
{
    public class ConfigurationVariables
    {

        public ConfigurationVariable<string> SiteLogoPath = new ConfigurationVariable<string>("SiteLogoPath");
        public ConfigurationVariable<string> FromEmail = new ConfigurationVariable<string>("FromEmail");
        public ConfigurationVariable<string> FromEmailName = new ConfigurationVariable<string>("FromEmailName");
        public ConfigurationVariable<string> EmailTemplatePath = new ConfigurationVariable<string>("EmailTemplatePath");

        public ConfigurationVariable<string> PaymentEmailName = new ConfigurationVariable<string>("PaymentEmailName");
        public ConfigurationVariable<string> PaymentEmailSubject = new ConfigurationVariable<string>("PaymentEmailSubject");

        public ConfigurationVariable<int> ItemPerPage = new ConfigurationVariable<int>("ItemPerPage");
        public ConfigurationVariable<string> AdminEmail = new ConfigurationVariable<string>("AdminEmail");

        public ConfigurationVariable<string> ContactApproveMail = new ConfigurationVariable<string>("ContactApproveMail");
        public ConfigurationVariable<string> ContactApproveSubject = new ConfigurationVariable<string>("ContactApproveSubject");

        public ConfigurationVariable<string> ContactReceivedMail = new ConfigurationVariable<string>("ContactReceivedMail");
        public ConfigurationVariable<string> ContactReceivedSubject = new ConfigurationVariable<string>("ContactReceivedSubject");

        public ConfigurationVariable<string> ContactSubmitedMail = new ConfigurationVariable<string>("ContactRequestSubmittedSucessfully");
        public ConfigurationVariable<string> ContactSubmitedSubject = new ConfigurationVariable<string>("ContactRequestSubmittedSubject");

        public ConfigurationVariable<string> ContactApprovalConfirmationNotificationMail = new ConfigurationVariable<string>("ContactApprovalConfirmationNotificationMail");
        public ConfigurationVariable<string> ContactApprovalConfirmationNotificationSubject = new ConfigurationVariable<string>("ContactApprovalConfirmationNotificationSubject");
    }
}
