using TahaMucasiroglu.Domain.DTOs.Abstract.Blog;

namespace TahaMucasiroglu.Application.Validation.Base.Blog
{
    public class BlogDeleteValidation<T> : DeleteValidation<T>
    where T : class, IBlogDeleteDTO
    {
        public BlogDeleteValidation() : base()
        {

        }
    }
}
