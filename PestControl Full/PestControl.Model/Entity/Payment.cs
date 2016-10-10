using System;
using System.Text;
using System.Collections.Generic;

using PestControl.Model.Entity.Base;


namespace PestControl.Model.Entity
{
    
    public partial class Payment : BaseEntity
    {
        public Payment() 
        {
			//Gateways = new List<Gateway>();
        }

        public virtual string Email { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string CardNo { get; set; }
        public virtual string SecurityCode { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual double Amount { get; set; }
        public virtual long InvoiceNo { get; set; }
        public virtual CardType CardType { get; set; }

        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }

        public virtual string Phone { get; set; }
        public virtual string Message { get; set; }
    }
}
