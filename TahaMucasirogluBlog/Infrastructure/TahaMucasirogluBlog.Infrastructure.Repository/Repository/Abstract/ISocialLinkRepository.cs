using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Main;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract
{
    public interface ISocialLinkRepository : IRepository<SocialLink>
    {
    }
}
