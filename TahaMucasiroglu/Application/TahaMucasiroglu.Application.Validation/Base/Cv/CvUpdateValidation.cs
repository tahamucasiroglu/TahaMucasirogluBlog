using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;

namespace TahaMucasiroglu.Application.Validation.Base.Cv
{
    public class CvUpdateValidation<T> : Validator<T>
        where T : class, ICvUpdateDTO
    {
    }
}
