﻿using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.Info
{
    public class UpdateInfoListDTOValidation : AbstractValidator<IEnumerable<UpdateInfoDTO>>
    {
        public UpdateInfoListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateInfoDTOValidation());
        }
    }
    public class UpdateInfoDTOValidation : CvUpdateValidation<UpdateInfoDTO>
    {
        public UpdateInfoDTOValidation() : base()
        {
            RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad soyad boş olamaz")
            .Length(2, 100).WithMessage("Ad soyad 2–100 karakter arasında olmalı");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin"); // :contentReference[oaicite:1]{index=1}

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz")
                .Matches(@"^\+?[0-9\s\-]{7,15}$")
                .WithMessage("Geçerli bir telefon numarası girin (7–15 rakam)");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Konum boş olamaz")
                .MaximumLength(200).WithMessage("Konum maksimum 200 karakter olabilir");

        }
    }
}
