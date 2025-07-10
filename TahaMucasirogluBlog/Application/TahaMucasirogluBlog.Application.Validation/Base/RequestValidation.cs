using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Extensions;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;

namespace TahaMucasirogluBlog.Application.Validation.Base
{
    public class RequestValidation<T> : Validator<T>
            where T : class, IRequestDTO
    {
        public RequestValidation() : base()
        {
            RuleFor(e => e.IslemYapanKullaniciId).IsGuid(nameof(IRequestDTO.IslemYapanKullaniciId));
        }
    }
}
