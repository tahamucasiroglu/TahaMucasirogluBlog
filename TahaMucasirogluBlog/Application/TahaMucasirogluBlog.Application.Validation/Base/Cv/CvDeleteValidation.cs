using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Abstract.Cv;

namespace TahaMucasirogluBlog.Application.Validation.Base.Cv
{
    public class CvDeleteValidation<T> : DeleteValidation<T>
    where T : class, ICvDeleteDTO
    {
        public CvDeleteValidation() : base()
        {
            
        }
    }
}
