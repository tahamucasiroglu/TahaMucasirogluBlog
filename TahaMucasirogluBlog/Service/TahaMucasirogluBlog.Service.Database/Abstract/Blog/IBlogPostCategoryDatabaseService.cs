using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.BlogPostCategory;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Blog
{
    public interface IBlogPostCategoryDatabaseService : IBlogDatabaseService<BlogPostCategory, GetBlogPostCategoryDTO, AddBlogPostCategoryDTO, UpdateBlogPostCategoryDTO, DeleteBlogPostCategoryDTO>
    {
    }
}
