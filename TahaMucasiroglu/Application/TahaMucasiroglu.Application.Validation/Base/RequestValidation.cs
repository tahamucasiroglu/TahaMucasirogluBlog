using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Extensions;
using TahaMucasiroglu.Domain.DTOs.Abstract;

namespace TahaMucasiroglu.Application.Validation.Base
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
