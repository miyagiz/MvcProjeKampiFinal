using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer

        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                p.WriterStatus = true;
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetById(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                p.WriterStatus = true;
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> WriterLoginAsync(Writer p)
        {
            var captchaImage = HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(captchaImage))
            {
                return RedirectToAction("HomePage", "Home");
            }

            var verified =await CheckCaptcha();
            if (!verified)
            {
                return Content("Doğrulanmadı");
            }
            else
            {
                var writerUserInfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
                if (writerUserInfo != null)
                {
                    FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                    Session["WriterMail"] = writerUserInfo.WriterMail;
                    return RedirectToAction("MyContent", "WriterPanelContent");
                }
                else
                {
                    return RedirectToAction("HomePage", "Home");
                }
            }
            
            //Context c = new Context();
            //var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            
        }

        public async Task<bool> CheckCaptcha()
        {
            var postData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("secret", "6LfCEZcgAAAAAH3yKInoasljMsFFbU_a_SXTp8H3"),
                new KeyValuePair<string, string>("response", HttpContext.Request.Form["g-recaptcha-response"])
            };

            var client = new HttpClient();
            var response = await client.PostAsync("https://google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));
            var o = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return (bool)o["success"];
        }




        [AllowAnonymous]
        public PartialViewResult WriterLoginPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult SignUpWriterPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUpWriter(Writer p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string fileExtention = Path.GetExtension(Request.Files[0].FileName);
                string filePath = "~/Images/" + fileName + fileExtention;
                Request.Files[0].SaveAs(Server.MapPath(filePath));
                p.WriterImage = "/Images/" + fileName + fileExtention;
                p.WriterStatus = true;
                wm.WriterAdd(p);
            }
            return RedirectToAction("HomePage", "Home");
        }



    }
}