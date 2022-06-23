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
    public class SkillCardController : Controller
    {
        // GET: SkillCard

        SkillCardManager scm = new SkillCardManager(new EfSkillCardDal());

        public ActionResult Index(int id)
        {
            var values = scm.GetByID(id);
            ViewBag.name = values.Name;
            ViewBag.surname = values.Surname;
            return View(values);
        }

        public ActionResult AllSkillCards()
        {
            var values = scm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditSkillCard(int id)
        {
            var values = scm.GetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditSkillCard(SkillCard p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string fileExtention = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "~/Images/" + fileName + fileExtention;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                p.imageOfSkillCardHolder = "/Images/" + fileName + fileExtention;
            }
            scm.UpdateSkillCard(p);
            return RedirectToAction("AllSkillCards");
        }

        [HttpGet]
        public ActionResult AddSkillCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkillCard(SkillCard p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string fileExtention = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "~/Images/" + fileName + fileExtention;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                p.imageOfSkillCardHolder = "/Images/" + fileName + fileExtention;
            }
            scm.AddSkillCard(p);
            return RedirectToAction("AllSkillCards");
        }
    }
}