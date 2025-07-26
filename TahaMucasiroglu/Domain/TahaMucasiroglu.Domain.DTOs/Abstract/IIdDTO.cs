using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasiroglu.Domain.DTOs.Abstract
{
    public interface IIdDTO : IDTO
    {
        public Guid Id { get; init; }
    }
}
