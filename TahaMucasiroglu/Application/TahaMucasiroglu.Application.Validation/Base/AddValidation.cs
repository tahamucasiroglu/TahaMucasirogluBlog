using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Extensions;
using TahaMucasiroglu.Domain.DTOs.Abstract;

namespace TahaMucasiroglu.Application.Validation.Base
{
    public class AddValidation<T> : Validator<T>
        where T : class, IAddDTO
    {
        public AddValidation() : base()
        {
            RuleFor(e => e.IslemYapanKullaniciId).IsGuid(nameof(IAddDTO.IslemYapanKullaniciId));
        }
    }
}
