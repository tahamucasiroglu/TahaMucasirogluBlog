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
    public class ExperienceRepository : Repository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(TahaMucasirogluBlogContext context, ILogger<ExperienceRepository> logger) : base(context, logger)
        {
        }
    }
}
