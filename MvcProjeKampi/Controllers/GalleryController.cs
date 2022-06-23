using BusinessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }

        [HttpPost]
        public ActionResult UploadImage(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string fileExtention = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "~/Images/" + fileName + fileExtention;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                p.ImagePath = "/Images/" + fileName + fileExtention;
                ifm.ImageAdd(p);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult ImageUploadPartialView()
        {
            return PartialView();
        }
    }
}