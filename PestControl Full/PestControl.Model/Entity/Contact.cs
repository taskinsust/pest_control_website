using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class Contact:BaseEntity
    {
        public Contact() { }

        public virtual string Email { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }

        public virtual string Phone { get; set; }
        public virtual string Message { get; set; }

        public virtual DateTime Schedual { get; set; }

        public virtual int ContactStatus { get; set; }

        
    }

    public class ContactStatusText
    {
        public static int Pending { get { return 0; } }
        public static int Approved { get { return 1; } }
        public static int Confirmed { get { return 2; } }
    }


}
