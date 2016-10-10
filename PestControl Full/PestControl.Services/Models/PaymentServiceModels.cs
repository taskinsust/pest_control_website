using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControl.Services.Models
{
    public class PaymentShortDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CardNo { get; set; }
        public string InvoiceNo { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public string Email { get; set; }
    }

    public class ContactShortDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Schedule { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public bool IsPending { get; set; }
    }

}
