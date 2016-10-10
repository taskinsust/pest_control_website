using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNetMVCExtendingIdentity2Roles.App_code;
using NHibernate;
using PestControl.Model.Entity;
using PestControl.Services;

namespace ASPNetMVCExtendingIdentity2Roles.Controllers
{
    public class ImageGalleryController : Controller
    {
        // GET: ImageGallery
        private readonly IMenuService _menuService;
        private readonly IGalleryService _galleryService;
        private ISession _session;
        private ISessionFactory _sessionFactory;
        private string _storageRoot;
        List<string> array = new List<String>();
        private void CreateSession()
        {
            _sessionFactory = new NhSessionFactory().GetSessionFactory();
            _session = _sessionFactory.OpenSession();
        }
        public ImageGalleryController()
        {
            CreateSession();
            _menuService = new MenuService(_session);
            _galleryService = new GalleryService(_session);
            _storageRoot = "media";
        }


        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            IList<Gallery> galleryList = _galleryService.GetOk();
            var imageObj = new GalleryImages();
            ViewBag.gallery = new SelectList(galleryList, "Id", "Name");
            return View(imageObj);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(GalleryImages galleryImage,long Gallery)
        {
            TempData["GalleryImageObj"] = galleryImage;
            TempData["GalleryId"] = Gallery;
            return View("ImageUpload");
        }

        [Authorize]
        public string Thumbnail(int width, int height, string fileName, string filePath)
        {
            var thumbImageFile = Path.Combine(Server.MapPath("~/Images/Thumb"), fileName);
            //thumbImageFile += ".png";
            using (var srcImage = Image.FromFile(filePath))
            using (var newImage = new Bitmap(width, height))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(srcImage, new Rectangle(0, 0, width, height));
                newImage.Save(stream, ImageFormat.Png);
                newImage.Save(thumbImageFile, ImageFormat.Png);
                return thumbImageFile;
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult SaveGalleryImages(HttpPostedFileBase file)
        {
            var galleryImage = (GalleryImages)TempData["GalleryImageObj"];
            string thumbImageFile = "";
            if (file != null && file.ContentLength > 0)
            {
                var validImageType = new string[] { ".png", ".PNG", ".jpg", ".JPG", ".bmp", ".BMP", ".jpeg", ".JPEG", ".gif", ".GIF" };
                string defaultFileUrl = System.IO.Path.GetFileName(file.FileName);
                string filePath = System.IO.Path.Combine(
                                   Server.MapPath("/Images/GalleryImages/"), defaultFileUrl);
                foreach (string vit in validImageType)
                {
                    if (file.FileName.EndsWith(vit))
                    {
                        var fileName = file.FileName;
                        
                        //array.Add(filePath);
                        var fileInfo = new FileInfo(filePath);
                        if (fileInfo.Exists)
                        {
                            filePath = System.IO.Path.Combine(
                                   Server.MapPath("/Images/GalleryImages"), Guid.NewGuid().ToString().Substring(0, 10) + defaultFileUrl);
                            file.SaveAs(filePath);
                            thumbImageFile = Thumbnail(100, 100, fileName, filePath);
                            //array.Add(filePath);
                            break;
                        }
                        else
                        {
                            file.SaveAs(filePath);
                            thumbImageFile = Thumbnail(120, 80, fileName, filePath);
                            //array.Add(filePath);
                            break;
                        }
                    }
                }
                //bool isGalleryExit = _galleryService.IsGalleryExits(galleryImage.Name);
                //if (!isGalleryExit)
                //{
                    IList<GalleryImages> galleryImageses = new List<GalleryImages>();
                    //foreach (var pImage in array)
                   // {
                        GalleryImages galleryImages = new GalleryImages();
                        galleryImages.CreationDate = DateTime.Now;
                        galleryImages.ModificationDate = DateTime.Now;
                        galleryImages.ImageUrl = filePath;
                        galleryImages.ThumbUrl = thumbImageFile;
                        long galleryId =(long)TempData["GalleryId"];
                        Gallery gallery = _galleryService.LoadById(galleryId);
                        galleryImages.Gallery = gallery;
                        gallery.GalleryImages.Add(galleryImages);
                        _galleryService.Update(gallery);
                    //}
                //}
                //else
                //{

                //}
                    
            }
            return RedirectToAction("Dashboard", new {message ="Image Uploaded Successfully"});
        }

        [Authorize]
        public ActionResult Dashboard(string message = "")
        {
            if (!String.IsNullOrEmpty(message))
            {
                ViewBag.SuccessMessage = message;
            }
            return View();
        }
    }
    
}