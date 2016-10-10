using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Model.Entity.Base;

namespace PestControl.Model.Entity
{
    public class CardType:BaseEntity
    {
        public CardType() { }

        public virtual string Name { get; set; }

        public virtual IList<Payment> Payments { get; set; }
    }
}
