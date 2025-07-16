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
    public class SubSkillRepository : CvRepository<SubSkill>, ISubSkillRepository
    {
        public SubSkillRepository(CvTahaMucasirogluContext context, ILogger<SubSkillRepository> logger) : base(context, logger)
        {
        }
    }
}
