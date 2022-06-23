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
    public class AboutController : Controller
    {
        // GET: About

        AboutManager am = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = am.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult AboutActiveOrPassive(int id)
        {
            var results = am.GetById(id);

            if (results.AboutStatus == true)
            {
                results.AboutStatus = false;
            }
            else
            {
                results.AboutStatus = true;
            }
            am.AboutUpdate(results);
            return RedirectToAction("Index");
        }
    }
}