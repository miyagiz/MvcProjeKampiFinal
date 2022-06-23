using BusinessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);

            if (values.Count == 0)
            {
                var allContents = cm.GetList();
                return View(allContents);
            }
            return View(values);

            //if (p == null)
            //{
            //    var allContents = cm.GetList();
            //    return View(allContents);
            //}
            //else
            //{
            //    var values = cm.GetList(p);
            //    return View(values);
            //}
        }

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult ContentByHeadingForWriter(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }

        public ActionResult ContentByWriter(int id)
        {
            var values = cm.GetListByWriter(id);
            return View(values);
        }
    }
}