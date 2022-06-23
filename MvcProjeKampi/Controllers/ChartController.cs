using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryPieChart()
        {
            return View();
        }

        public ActionResult WriterColumnChart()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingLineChart()
        {
            return View();
        }

        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> ct = new List<CategoryChart>();
            ct.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryChart()
            {
                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            ct.Add(new CategoryChart()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryChart()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
            //bir başlıktaki yazı sayısı - Line - Column
            //bir kategorideki başlık sayısı
        }

        public List<CategoryChart> CategoryList()
        {
            List<CategoryChart> categoryCharts = new List<CategoryChart>();
            using (var context = new Context())
            {
                categoryCharts = context.Categories.Select(c => new CategoryChart
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.Headings.Count()
                }).ToList();
            }

            return categoryCharts;
        }

        public ActionResult CategoryCharts()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterChart> WriterList()
        {
            List<WriterChart> writerCharts = new List<WriterChart>();
            using (var context = new Context())
            {
                writerCharts = context.Writers.Select(c => new WriterChart
                {
                    WriterName = c.WriterName,
                    WriterCount = c.Headings.Count()
                }).ToList();
            }

            return writerCharts;
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        public List<HeadingChart> HeadingList()
        {
            List<HeadingChart> headingCharts = new List<HeadingChart>();
            using (var context = new Context())
            {
                headingCharts = context.Headings.Select(c => new HeadingChart
                {
                    HeadingName = c.HeadingName,
                    HeadingCount = c.Contents.Count()
                }).ToList();
            }

            return headingCharts;
        }

        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }
    }
}