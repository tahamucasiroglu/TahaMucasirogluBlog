using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;

namespace TahaMucasiroglu.Application.Validation.Base.Cv
{
    public class CvRequestValidation<T> : Validator<T>
            where T : class, ICvRequestDTO
    {
    }
}
