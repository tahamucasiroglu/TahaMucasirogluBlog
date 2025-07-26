using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Infrastructure.CvRepository.Context;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Base;

namespace TahaMucasiroglu.Infrastructure.CvRepository.Repository.Concrete
{
    public class SkillRepository : CvRepository<Skill>, ISkillRepository
    {
        public SkillRepository(CvTahaMucasirogluContext context, ILogger<SkillRepository> logger) : base(context, logger)
        {
        }
    }
}
