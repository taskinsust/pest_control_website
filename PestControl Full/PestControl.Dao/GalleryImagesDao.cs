using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PestControl.Dao.Base;
using PestControl.Model.Entity;

namespace PestControl.Dao
{
    public interface IGalleryImagesDao : IBaseDao<GalleryImages, long>
    {
        bool IsGalleryExits(string name);
    }

    public class GalleryImagesDao : BaseDao<GalleryImages, long>, IGalleryImagesDao
    {
        public bool IsGalleryExits(string name)
        {
            var galleryImg =
                Session.QueryOver<GalleryImages>().Where(x => x.Name == name.Trim() && x.Status == 1).RowCount();
            if (galleryImg > 0)
            {
                return true;
            }
            return false;
        }
    }
}
