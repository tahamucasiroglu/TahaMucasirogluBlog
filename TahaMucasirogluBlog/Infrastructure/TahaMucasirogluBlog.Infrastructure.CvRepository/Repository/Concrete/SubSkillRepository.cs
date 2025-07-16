using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Context;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Concrete
{
    public class SubSkillRepository : CvRepository<SubSkill>, ISubSkillRepository
    {
        public SubSkillRepository(CvTahaMucasirogluContext context, ILogger<SubSkillRepository> logger) : base(context, logger)
        {
        }
    }
}
