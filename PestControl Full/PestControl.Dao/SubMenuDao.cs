using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Dao.Base;
using PestControl.Model.Entity;

namespace PestControl.Dao
{
    public interface ISubMenuDao : IBaseDao<ProductServices, long>
    {
        
    }

    public class SubMenuDao : BaseDao<ProductServices, long>, ISubMenuDao
    {
        
    }
}
