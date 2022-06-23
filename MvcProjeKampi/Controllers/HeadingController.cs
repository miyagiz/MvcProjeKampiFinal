using BusinessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index(int p = 1)
        {
            var headingValues = hm.GetList().ToPagedList(p, 6);
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingStatus = true;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValues = hm.GetById(id);
            return View(headingValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.HeadingStatus = true;
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingUpdate(headingValue);
            return RedirectToAction("Index");
        }

        public ActionResult HeadingsInCategories(int id)
        {
            var headingsInCategories = hm.GetListByCategories(id);
            return View(headingsInCategories);
        }

        public ActionResult InactiveHeadings()
        {
            var inactiveHeadingList = hm.GetListInactiveHeading();
            return View(inactiveHeadingList);
        }

        public ActionResult DoActiveHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = true;
            hm.HeadingUpdate(headingValue);
            return RedirectToAction("InactiveHeadings");
        }


    }
}