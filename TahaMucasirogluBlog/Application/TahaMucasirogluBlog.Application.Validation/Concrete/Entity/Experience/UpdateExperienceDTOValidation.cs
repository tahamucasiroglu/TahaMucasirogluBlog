using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Experience
{
    public class UpdateExperienceListDTOValidation : AbstractValidator<IEnumerable<UpdateExperienceDTO>>
    {
        public UpdateExperienceListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new UpdateExperienceDTOValidation());
        }
    }
    public class UpdateExperienceDTOValidation : UpdateValidation<UpdateExperienceDTO>
    {
        public UpdateExperienceDTOValidation() : base()
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
