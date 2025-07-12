using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Tag;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.User;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.User
{
    public class AddUserListDTOValidation : AbstractValidator<IEnumerable<AddUserDTO>>
    {
        public AddUserListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddUserDTOValidation());
        }
    }
    public class AddUserDTOValidation : AddValidation<AddUserDTO>
    {
        public AddUserDTOValidation() : base()
        {
            // FirstName: boş olamaz, uzunluk sınırı
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("FirstName zorunludur.")
                .Length(2, 50).WithMessage("FirstName 2–50 karakter olmalı.");

            // LastName: boş olamaz, uzunluk sınırı
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("LastName zorunludur.")
                .Length(2, 50).WithMessage("LastName 2–50 karakter olmalı.");

            // Email: boş olamaz, geçerli formatta olmalı
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girilmelidir."); // :contentReference[oaicite:1]{index=1}

        // PasswordHash: boş olamaz, minimum uzunluk kontrolü
        RuleFor(u => u.PasswordHash)
            .NotEmpty().WithMessage("Parola geçersiz (empty hash).")
            .MinimumLength(60).WithMessage("PasswordHash en az 60 karakter olmalı.");
            // Örneğin bcrypt hash’ler ~60 karakter olur. Gerektikçe sayıyı ayarlayabilirsin.
        }
    }
}
