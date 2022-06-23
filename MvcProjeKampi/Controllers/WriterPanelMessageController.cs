using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }

        public ActionResult InboxIsRead()
        {
            string p = (string)Session["WriterMail"];
            var inboxIsRead = mm.GetIsReadMessageList(p);
            return View(inboxIsRead);
        }

        public ActionResult InboxIsNotRead()
        {
            string p = (string)Session["WriterMail"];
            var inboxIsRead = mm.GetIsNotReadMessageList(p);
            return View(inboxIsRead);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];

            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];

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

        public ActionResult GetMessageDetails(int id)
        {
            var messageValues = mm.GetById(id);

            if (messageValues.IsRead == false)
            {
                messageValues.IsRead = true;
            }

            mm.MessageUpdate(messageValues);

            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message p)
        {
            string mail = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);

            if (results.IsValid)
            {
                p.SenderMail = mail;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.MessageStatus = true;
                p.IsRead = false;
                p.IsDraft = false;
                mm.MessageAdd(p);

                return RedirectToAction("Sendbox");
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
    }
}