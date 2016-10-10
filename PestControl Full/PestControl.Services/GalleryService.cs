using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PestControl.Dao;
using PestControl.Model.Entity;
using PestControl.Services.Base;
using PestControl.Core;
using PestControl.Services.Models;

namespace PestControl.Services
{
    public interface IGalleryService : IBaseService
    {
        IPagedList<GalleryShortDetailsModel> GalleryList(int pageIndex, int pageSize);
        Gallery GetGallery(long id);
        void DeleteImage(GalleryImages image);
        void DeleteGallery(Gallery gallery);

        void Save(Gallery gallery);

        IPagedList<GalleryImageShortDetailsModel> ImageList(long galleryId, int pageIndex, int pageSize);

        GalleryImages GetImage(long id);

        void Save(GalleryImages image);

        IList<Gallery> GetOk();
        bool IsGalleryExits(string name);
        Gallery LoadById(long id);

        void Update(Gallery gallery);
    }

    public class GalleryService : BaseService, IGalleryService
    {
        private readonly IGalleryDao _galleryDao;
        private readonly IGalleryImagesDao _galleryImagesDao;

        public GalleryService(ISession session)
        {
            _session = session;
            _galleryDao = new GalleryDao() { Session = _session };
            _galleryImagesDao = new GalleryImagesDao() { Session = _session };
        }

        public IList<Gallery> GetOk()
        {
            return _galleryDao.GetOk();
        }

        public bool IsGalleryExits(string name)
        {
            return _galleryImagesDao.IsGalleryExits(name);
        }

        public Gallery LoadById(long id)
        {
            return _galleryDao.LoadGalleryById(id);
        }

        public void Update(Gallery gallery)
        {
            _galleryDao.Update(gallery);
        }

        public IPagedList<GalleryShortDetailsModel> GalleryList(int pageIndex, int pageSize)
        {
            var query = _session.QueryOver<Gallery>().Where(x => x.Status != 404);
            var total = query.RowCount();


            if (total <= pageSize)
                pageIndex = 0;

            var items = query.OrderBy(x => x.Name).Asc.Skip(pageIndex * pageSize).Take(pageSize).List().Select(x => new GalleryShortDetailsModel
                {
                    Id = x.Id,
                    IsDisable = x.Status > 0,
                    Name = x.Name
                }).ToList();

            return new PagedList<GalleryShortDetailsModel>(items, pageIndex, pageSize, total);
        }

        public Gallery GetGallery(long id)
        {
            return _session.QueryOver<Gallery>().Where(x => x.Id == id).SingleOrDefault();
        }

        public void DeleteImage(GalleryImages image)
        {
            _galleryImagesDao.Delete(image);
        }
        public void DeleteGallery(Gallery gallery)
        {
            _galleryDao.Delete(gallery);
        }


        public IPagedList<GalleryImageShortDetailsModel> ImageList(long galleryId, int pageIndex, int pageSize)
        {
            var query = _session.QueryOver<GalleryImages>().Where(x => x.Status != 404 && x.Gallery.Id == galleryId);
            var total = query.RowCount();

            if (total <= pageSize)
                pageIndex = 0;

            var items = query.OrderBy(x => x.Name).Asc.Skip(pageIndex * pageSize).Take(pageSize).List().Select(x => new GalleryImageShortDetailsModel
            {
                Id = x.Id,
                Url = x.ImageUrl,
                IsDisable = x.Status > 0,
                Name = x.Name
            }).ToList();

            return new PagedList<GalleryImageShortDetailsModel>(items, pageIndex, pageSize, total);
        }

        public GalleryImages GetImage(long id)
        {
            return (GalleryImages)_galleryImagesDao.LoadById(id);
        }

        public void Save(GalleryImages image)
        {
            if (image.Id > 0)
                _galleryImagesDao.Update(image);
            else
                _galleryImagesDao.Save(image);
        }
        public void Save(Gallery gallery)
        {
            if (gallery.Id > 0)
                _galleryDao.Update(gallery);
            else
                _galleryDao.Save(gallery);
        }
    }
}
