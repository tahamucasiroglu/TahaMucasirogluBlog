using TahaMucasiroglu.Domain.DTOs.Abstract.Blog;

namespace TahaMucasiroglu.Application.Validation.Base.Blog
{
    public class BlogAddValidation<T> : AddValidation<T>
        where T : class, IBlogAddDTO
    {
    }
}
