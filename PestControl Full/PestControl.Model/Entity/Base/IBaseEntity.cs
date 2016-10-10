using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestControl.Model.Entity.Base
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        int VersionNumber { get; set; }
        string BusinessId { get; set; }
        DateTime CreationDate { get; set; }
        DateTime ModificationDate { get; set; }
        int Status { get; set; }
        string Name { get; set; }
        long CreateBy { get; set; }
        long ModifiedBy { get; set; }
    }
}
