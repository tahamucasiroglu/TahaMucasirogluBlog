using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasiroglu.Domain.DTOs.Abstract
{
    public interface IDTO //marker
    {
        public Guid IslemYapanKullaniciId { get; init; }
    }
}
