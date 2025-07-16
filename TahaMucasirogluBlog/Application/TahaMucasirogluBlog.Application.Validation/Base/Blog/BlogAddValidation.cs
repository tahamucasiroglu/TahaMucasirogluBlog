using TahaMucasirogluBlog.Domain.DTOs.Abstract.Blog;

namespace TahaMucasirogluBlog.Application.Validation.Base.Blog
{
    public class BlogAddValidation<T> : AddValidation<T>
        where T : class, IBlogAddDTO
    {
    }
}
