using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public int id;
        public ActionResult Index()
        {
            var countOfCategory = c.Categories.Count();

            var countHeading = c.Headings.Where(x => x.Category.CategoryID == 9).Count();

            var countWriter = c.Writers.Where(x => x.WriterName.Contains("a")).Count();

            var countTrueCategory = c.Categories.Where(x => x.CategoryStatus == true).Count();
            var countFalseCategory = c.Categories.Where(x => x.CategoryStatus == false).Count();
            var difTrueFalseFromCategory = countTrueCategory - countFalseCategory;

            var countCategoryList = c.Headings.GroupBy(x => x.CategoryID).Select(y => new { y.Key, Count = y.Count() }).ToList();


            int max = 0;

            foreach (var items in countCategoryList)
            {
                if (items.Count > max)
                {
                    max = items.Count;
                    id = items.Key;
                }
            }

            var categoryName = c.Categories.Where(x => x.CategoryID == id).Select(y => y.CategoryName).FirstOrDefault();


            ViewBag.countOfCategory = countOfCategory;
            ViewBag.countHeading = countHeading;
            ViewBag.countWriter = countWriter;
            ViewBag.difTrueFalseFromCategory = difTrueFalseFromCategory;
            ViewBag.categoryName = categoryName;

            return View("Index");
        }
    }
}