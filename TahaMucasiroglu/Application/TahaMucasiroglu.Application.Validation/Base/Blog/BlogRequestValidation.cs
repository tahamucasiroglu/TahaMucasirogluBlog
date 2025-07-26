using TahaMucasiroglu.Domain.DTOs.Abstract.Blog;

namespace TahaMucasiroglu.Application.Validation.Base.Blog
{
    public class BlogRequestValidation<T> : Validator<T>
            where T : class, IBlogRequestDTO
    {
    }
}
