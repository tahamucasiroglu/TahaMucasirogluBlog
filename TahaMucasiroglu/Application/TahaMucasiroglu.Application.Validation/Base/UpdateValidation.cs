using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Extensions;
using TahaMucasiroglu.Domain.DTOs.Abstract;

namespace TahaMucasiroglu.Application.Validation.Base
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
