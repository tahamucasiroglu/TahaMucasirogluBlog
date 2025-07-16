using TahaMucasirogluBlog.Domain.DTOs.Abstract.Blog;

namespace TahaMucasirogluBlog.Application.Validation.Base.Blog
{
    public class BlogRequestValidation<T> : Validator<T>
            where T : class, IBlogRequestDTO
    {
    }
}
