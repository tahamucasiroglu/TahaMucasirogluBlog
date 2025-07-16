using TahaMucasirogluBlog.Domain.DTOs.Abstract.Blog;

namespace TahaMucasirogluBlog.Application.Validation.Base.Blog
{
    public class BlogDeleteValidation<T> : DeleteValidation<T>
    where T : class, IBlogDeleteDTO
    {
        public BlogDeleteValidation() : base()
        {

        }
    }
}
