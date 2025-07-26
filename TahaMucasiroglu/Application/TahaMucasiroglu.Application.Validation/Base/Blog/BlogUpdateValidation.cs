using TahaMucasiroglu.Domain.DTOs.Abstract.Blog;

namespace TahaMucasiroglu.Application.Validation.Base.Blog
{
    public class BlogUpdateValidation<T> : Validator<T>
        where T : class, IBlogUpdateDTO
    {
    }
}
