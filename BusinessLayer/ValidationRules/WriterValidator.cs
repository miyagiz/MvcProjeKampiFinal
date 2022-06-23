using EntitiyLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı Boş Bırakılamaz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmı Boş Bırakılamaz.");
            RuleFor(x => x.WriterAbout).Must(x=>x!=null&&x.ToLower().Contains("a")).WithMessage("Hakkımda kısmı en az bir 'a' harfi içermelidir.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Maili Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı 2 karakterden az olamaz.");
        }
    }
}
