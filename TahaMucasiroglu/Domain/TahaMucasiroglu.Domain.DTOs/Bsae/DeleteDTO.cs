using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract;

namespace TahaMucasiroglu.Domain.DTOs.Base
{
    abstract public record DeleteDTO : IDeleteDTO
    {
        public Guid Id { get; init; }
        public Guid IslemYapanKullaniciId { get; init; }
    }
}
