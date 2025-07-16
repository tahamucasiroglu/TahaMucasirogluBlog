using TahaMucasirogluBlog.Domain.DTOs.Abstract.Blog;

namespace TahaMucasirogluBlog.Application.Validation.Base.Blog
{
    public class BlogUpdateValidation<T> : Validator<T>
        where T : class, IBlogUpdateDTO
    {
    }
}
