using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;

namespace TahaMucasiroglu.Application.Validation.Base.Cv
{
    public class CvAddValidation<T> : AddValidation<T>
        where T : class, ICvAddDTO
    {
        public CvAddValidation() : base()
        {

        }
    }
}
