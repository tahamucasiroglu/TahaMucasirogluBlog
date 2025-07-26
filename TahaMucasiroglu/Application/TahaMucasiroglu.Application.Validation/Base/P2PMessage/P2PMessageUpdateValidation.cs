using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;

namespace TahaMucasiroglu.Application.Validation.Base.P2PMessage
{
    public class P2PMessageUpdateValidation<T> : UpdateValidation<T>
        where T : class, IP2PMessageUpdateDTO
    {
        public P2PMessageUpdateValidation() : base()
        {
            
        }
    }
}
