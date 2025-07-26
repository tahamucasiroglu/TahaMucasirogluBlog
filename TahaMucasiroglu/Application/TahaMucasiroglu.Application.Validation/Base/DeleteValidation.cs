using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Extensions;
using TahaMucasiroglu.Domain.DTOs.Abstract;

namespace TahaMucasiroglu.Application.Validation.Base
{
    public class DeleteValidation<T> : Validator<T>
        where T : class, IDeleteDTO
    {
        public DeleteValidation() : base()
        {
            RuleFor(e => e.Id).IsGuid(nameof(IDeleteDTO.Id));
            RuleFor(e => e.IslemYapanKullaniciId).IsGuid(nameof(IDeleteDTO.IslemYapanKullaniciId));
        }
    }
}
