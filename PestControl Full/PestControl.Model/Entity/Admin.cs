using System;
using System.Text;
using System.Collections.Generic;

using PestControl.Model.Entity.Base;


namespace PestControl.Model.Entity
{
    
    public partial class Admin : BaseEntity
    {
        public Admin() 
        {
			//Gateways = new List<Gateway>();
        }
        //public virtual long Id { get; set; }
        //public virtual System.DateTime CreationDate { get; set; }
        //public virtual int AdminType { get; set; }
        public virtual bool IsLocked { get; set; }
        //public virtual IList<Gateway> Gateways { get; set; }
        //public virtual AppUser AppUser { get; set; }

    }
}
