using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus == true && x.IsDraft == false);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.MessageStatus == true && x.IsDraft == false);
        }

        public List<Message> GetDraftMessageList(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.MessageStatus == false && x.IsDraft == true);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> GetIsReadMessageList(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus == true && x.IsRead == true);
        }

        public List<Message> GetIsNotReadMessageList(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.MessageStatus == true && x.IsRead == false);
        }
    }
}
