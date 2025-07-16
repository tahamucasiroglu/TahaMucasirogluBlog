using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Context;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Base;

namespace TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Concrete
{
    public class ExperienceRepository : CvRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(CvTahaMucasirogluContext context, ILogger<ExperienceRepository> logger) : base(context, logger)
        {
        }
    }
}
