using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Category;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Blog
{
    public interface ICategoryDatabaseService : IBlogDatabaseService<Category, GetCategoryDTO, AddCategoryDTO, UpdateCategoryDTO, DeleteCategoryDTO>
    {
    }
}
