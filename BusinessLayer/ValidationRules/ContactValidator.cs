using EntitiyLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Alanı Boş Bırakılamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılamaz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter girişi yapmalısınız.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girişi yapmalısınız.");
        }
    }
}
