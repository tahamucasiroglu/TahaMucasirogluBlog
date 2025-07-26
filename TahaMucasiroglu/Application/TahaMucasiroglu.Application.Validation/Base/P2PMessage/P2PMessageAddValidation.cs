using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract.P2PMessage;

namespace TahaMucasiroglu.Application.Validation.Base.P2PMessage
{
    public class P2PMessageAddValidation<T> : AddValidation<T>
        where T : class, IP2PMessageAddDTO
    {
        public P2PMessageAddValidation() : base()
        {
            
        }
    }
}
