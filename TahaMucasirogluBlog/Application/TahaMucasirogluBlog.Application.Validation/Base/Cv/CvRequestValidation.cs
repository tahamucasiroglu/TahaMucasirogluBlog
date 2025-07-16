using TahaMucasirogluBlog.Domain.DTOs.Abstract.Cv;

namespace TahaMucasirogluBlog.Application.Validation.Base.Cv
{
    public class CvRequestValidation<T> : Validator<T>
            where T : class, ICvRequestDTO
    {
    }
}
