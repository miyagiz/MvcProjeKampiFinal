using EntitiyLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçemezisiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Bölümünü Boş Geçemezisiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Bölümünü Boş Geçemezisiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Adı 3 Karakterden Az Olamaz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu Adı 100 Karakterden Fazla Olamaz");
        }
    }
}
