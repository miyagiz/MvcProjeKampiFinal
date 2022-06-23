using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());

        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contacValues = cm.GetList();
            return View(contacValues);
        }

        [AllowAnonymous]
        public PartialViewResult GetContact()
        {
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult GetMessageAdmin(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContactAdd(p);
            ViewBag.successMessage = "Mesajınız Başarı İle İletilmiştir.";
            return RedirectToAction("HomePage", "Home");
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["AdminUserName"];

            var contactCount = cm.GetList().Count();
            ViewBag.contactCount = contactCount;

            var inboxCount = mm.GetListInbox(p).Count();
            ViewBag.inboxCount = inboxCount;

            var sendboxCount = mm.GetListSendbox(p).Count();
            ViewBag.sendboxCount = sendboxCount;

            var draftMessageCount = mm.GetDraftMessageList(p).Count();
            ViewBag.draftMessageCount = draftMessageCount;

            var inboxIsRead = mm.GetIsReadMessageList(p).Count();
            ViewBag.inboxIsRead = inboxIsRead;

            var inboxNotIsRead = mm.GetIsNotReadMessageList(p).Count();
            ViewBag.inboxNotIsRead = inboxNotIsRead;


            return PartialView();
        }


    }
}