using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
namespace PestControl.Model.Entity.Base
{
    [Serializable]
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            this.CreationDate = DateTime.Now;
            this.ModificationDate = DateTime.Now;
        }

        //[Display(Name = "Created By")]
        public virtual long CreateBy { get; set; }
        //[Display(Name = "Modified By")]
        public virtual long ModifiedBy { get; set; }
        //[Required]
        
        public virtual string Name { get; set; }
        public virtual int VersionNumber { get; set; }
        public virtual string BusinessId { get; set; }
        public virtual int Status { get; set; }
        //[Display(Name = "Modified Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime ModificationDate { get; set; }
        public virtual long Id { get; set; }
        //[Display(Name = "Creation Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime CreationDate { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
                return Name;
            return "";
        }

        public class StatusText
        {
            public static int Active { get { return 1; } }
            public static int Inactive { get { return 0; } }
            public static int Delete { get { return -404; } }
        }
    }
}
