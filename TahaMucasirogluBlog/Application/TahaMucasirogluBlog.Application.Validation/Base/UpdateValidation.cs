using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Extensions;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;

namespace TahaMucasirogluBlog.Application.Validation.Base
{
    public class UpdateValidation<T> : Validator<T>
        where T : class, IUpdateDTO
    {
        public UpdateValidation() : base()
        {
            RuleFor(e => e.Id).IsGuid(nameof(IUpdateDTO.Id));
            RuleFor(e => e.IslemYapanKullaniciId).IsGuid(nameof(IUpdateDTO.IslemYapanKullaniciId));
        }
    }
}
