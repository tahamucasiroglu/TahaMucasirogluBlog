using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Return.Concrete;

namespace TahaMucasiroglu.Domain.Return.Constant
{
    public sealed record Api404Error : ErrorReturn
    {
        public Api404Error() : base("Olmayan bir adrese istek denediniz.")
        {
            
        }
    }
}
