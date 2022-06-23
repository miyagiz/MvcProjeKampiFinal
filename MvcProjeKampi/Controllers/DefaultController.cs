using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings(int p = 1)
        {
            var headingList = hm.GetList().ToPagedList(p, 15);

            return View(headingList);
        }

        
        public PartialViewResult Index(int id = 1)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return PartialView(contentValues);
        }

        //public void HeadingDetail(int id)
        //{
        //    var values

        //    return View();
        //}
    }
}