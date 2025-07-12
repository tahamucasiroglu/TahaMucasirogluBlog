using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete
{
    public class SubSkillRepository : Repository<SubSkill>, ISubSkillRepository
    {
        public SubSkillRepository(TahaMucasirogluBlogContext context, ILogger<SubSkillRepository> logger) : base(context, logger)
        {
        }
    }
}
