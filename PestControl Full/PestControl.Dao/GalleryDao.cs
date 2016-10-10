using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Dao.Base;
using PestControl.Model.Entity;

namespace PestControl.Dao
{
    public interface IGalleryDao : IBaseDao<Gallery, long>
    {

        IList<Gallery> GetOk();
        Gallery LoadGalleryById(long id);
    }

    public class GalleryDao : BaseDao<Gallery, long>, IGalleryDao
    {
        public IList<Gallery> GetOk()
        {
            return Session.QueryOver<Gallery>().Where(x => x.Status ==1).List<Gallery>();
        }

        public Gallery LoadGalleryById(long id)
        {
            return Session.QueryOver<Gallery>().Where(x => x.Id == id && x.Status == 1).SingleOrDefault<Gallery>();
        }
    }
}
