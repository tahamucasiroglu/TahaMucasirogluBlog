﻿using FluentValidation;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Cv;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience;

namespace TahaMucasiroglu.Application.Validation.Concrete.Cv.Experience
{
    public class AddExperienceListDTOValidation : AbstractValidator<IEnumerable<AddExperienceDTO>>
    {
        public AddExperienceListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddExperienceDTOValidation());
        }
    }
    public class AddExperienceDTOValidation : CvAddValidation<AddExperienceDTO>
    {
        public AddExperienceDTOValidation() : base()
        {
            RuleFor(x => x.ExperienceTypeId)
            .NotEmpty()
            .WithMessage("ExperienceTypeId boş olamaz.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlık boş olamaz.")
                .MaximumLength(200);

            RuleFor(x => x.Provider)
                .NotEmpty()
                .WithMessage("Provider (kurum/şirket) boş olamaz.")
                .MaximumLength(200);

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Başlangıç tarihi bugünden büyük olamaz.");

            RuleFor(x => x)
                .Must(dto => dto.EndDate == null || dto.EndDate >= dto.StartDate)
                .WithMessage("Bitiş tarihi, başlangıç tarihinden önce olamaz.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Açıklama boş olamaz.")
                .MinimumLength(20)
                .WithMessage("Açıklama en az 20 karakter olmalı.");

            RuleFor(x => x.Reference)
                .MaximumLength(200)
                .When(x => !string.IsNullOrEmpty(x.Reference))
                .WithMessage("Referans maksimum 200 karakter olabilir.");
        }
    }
}
