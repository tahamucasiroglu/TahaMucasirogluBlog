using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract.Cv;
using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.Repository.Repository.Concrete.Cv
{
    public class ExperienceRepository : CvRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(CvTahaMucasirogluContext context, ILogger<ExperienceRepository> logger) : base(context, logger)
        {
        }
    }
}
