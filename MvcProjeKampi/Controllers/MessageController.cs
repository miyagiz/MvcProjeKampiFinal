using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();


        public ActionResult Inbox()
        {
            string p = (string)Session["AdminUserName"];
            var messageListIn = mm.GetListInbox(p);
            return View(messageListIn);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminUserName"];
            var messageListSend = mm.GetListSendbox(p);
            return View(messageListSend);
        }

        public ActionResult Drafts()
        {
            string p = (string)Session["AdminUserName"];
            var draftMessageList = mm.GetDraftMessageList(p);
            return View(draftMessageList);
        }

        public ActionResult InboxIsRead()
        {
            string p = (string)Session["AdminUserName"];
            var inboxIsRead = mm.GetIsReadMessageList(p);
            return View(inboxIsRead);
        }

        public ActionResult InboxIsNotRead()
        {
            string p = (string)Session["AdminUserName"];
            var inboxIsNotRead = mm.GetIsNotReadMessageList(p);
            return View(inboxIsNotRead);
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
            string session = (string)Session["AdminUserName"];
            ValidationResult results = messageValidator.Validate(p);
            
            if (results.IsValid)
            {
                p.SenderMail = session;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.IsRead = false;
                p.IsDraft = false;
                p.MessageStatus = true;
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


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessageDraft(Message p)
        {
            string session = (string)Session["AdminUserName"];
            ValidationResult results = messageValidator.Validate(p);
            
            if (results.IsValid)
            {
                p.SenderMail = session;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.IsRead = false;
                p.IsDraft = true;
                p.MessageStatus = false;
                mm.MessageAdd(p);

                return RedirectToAction("Drafts");
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

        public PartialViewResult DraftMessagePartial()
        {
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

        public ActionResult IsRead(int id)
        {
            var results = mm.GetById(id);

            mm.MessageUpdate(results);
            return RedirectToAction("InboxIsRead");
        }
    }
}