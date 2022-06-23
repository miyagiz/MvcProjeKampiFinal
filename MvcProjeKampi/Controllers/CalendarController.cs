using BusinessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class CalendarController : Controller
    {
        // GET: Calendar
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

		[HttpGet]
        public ActionResult Index()
        {
            return View(new Calendar());
        }

		public JsonResult GetEvents()
		{
			var events = new List<Calendar>();
			var start = DateTime.Today.AddDays(-14);
			var end = DateTime.Today.AddDays(-14);

			foreach (var item in hm.GetList())
			{
				events.Add(new Calendar()
				{
					title = item.HeadingName,
					start = item.HeadingDate,
					end = item.HeadingDate.AddDays(-14),
					allDay = false
				});

				start = start.AddDays(7);
				end = end.AddDays(7);
			}


			return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
		}
	}
}