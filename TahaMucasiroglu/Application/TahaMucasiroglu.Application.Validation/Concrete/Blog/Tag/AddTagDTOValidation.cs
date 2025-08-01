﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Tag;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.Tag
{
    public class AddTagListDTOValidation : AbstractValidator<IEnumerable<AddTagDTO>>
    {
        public AddTagListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddTagDTOValidation());
        }
    }
    public class AddTagDTOValidation : BlogAddValidation<AddTagDTO>
    {
        public AddTagDTOValidation() : base()
        {
            // Name: boş olamaz, minimum/maximum uzunluk kontrolü
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name alanı zorunludur ve boş olamaz.") // null veya boşluk dahil kontrol eder :contentReference[oaicite:1]{index=1}
                .Length(2, 100).WithMessage("Name 2‑100 karakter arasında olmalıdır.");

            // Slug: boş olamaz, regex ile küçük harf/rakam ve '-' formatı sağlanır
            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug alanı zorunludur.") // boşluklu stringleri de engeller :contentReference[oaicite:2]{index=2}
                .Matches("^[a-z0-9]+(-[a-z0-9]+)*$")
                .WithMessage("Slug yalnızca küçük harf, rakam ve '-' içermeli (ör. örnek-erik123).");
        }
    }
}
