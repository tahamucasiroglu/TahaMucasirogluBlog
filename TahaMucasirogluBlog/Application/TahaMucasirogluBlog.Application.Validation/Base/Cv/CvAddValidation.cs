using TahaMucasirogluBlog.Domain.DTOs.Abstract.Cv;

namespace TahaMucasirogluBlog.Application.Validation.Base.Cv
{
    public class CvAddValidation<T> : AddValidation<T>
        where T : class, ICvAddDTO
    {
        public CvAddValidation() : base()
        {

        }
    }
}
