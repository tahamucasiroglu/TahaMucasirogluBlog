using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;

namespace TahaMucasiroglu.Application.Validation.Base.Cv
{
    public class CvDeleteValidation<T> : DeleteValidation<T>
    where T : class, ICvDeleteDTO
    {
        public CvDeleteValidation() : base()
        {
            
        }
    }
}
