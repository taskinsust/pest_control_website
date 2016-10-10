using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Dao.Base;
using PestControl.Model.Entity;

namespace PestControl.Dao
{
    public interface IMenuDao : IBaseDao<Menu, long>
    {

        Menu LoadmenuById(long id);
    }

    public class MenuDao : BaseDao<Menu, long>, IMenuDao
    {
        public Menu LoadmenuById(long id)
        {
            var menu  =Session.QueryOver<Menu>().Where(x => x.Id == id).SingleOrDefault<Menu>();
            return menu;
        }
    }
}
