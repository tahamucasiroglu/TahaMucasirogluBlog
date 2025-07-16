using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Blog.Tag;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Blog;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Blog
{
    public interface ITagDatabaseService : IBlogDatabaseService<Tag, GetTagDTO, AddTagDTO, UpdateTagDTO, DeleteTagDTO>
    {
    }
}
