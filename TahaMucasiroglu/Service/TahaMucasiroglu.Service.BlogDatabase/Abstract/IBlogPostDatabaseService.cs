using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.BlogPost;
using TahaMucasiroglu.Domain.Entities.Concrete.Blog;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.BlogDatabase.Abstract
{
    public interface IBlogPostDatabaseService : IBlogDatabaseService<BlogPost, GetBlogPostDTO, AddBlogPostDTO, UpdateBlogPostDTO, DeleteBlogPostDTO>
    {
    }
}
