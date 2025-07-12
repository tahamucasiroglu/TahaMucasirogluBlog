using TahaMucasirogluBlog.Infrastructure.Repository.Repository.Abstract;
using TahaMucasirogluBlog.Service.Cv.Abstract;

namespace TahaMucasirogluBlog.Service.Cv.Concrete
{
    public class CvService : ICvService
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly IInfoRepository infoRepository;
        private readonly ISkillRepository skillRepository;

        public CvService
            (
                IInfoRepository infoRepository,
                ISkillRepository skillRepository,
                IExperienceRepository experienceRepository
            )
        {
            this.skillRepository = skillRepository;
            this.infoRepository = infoRepository;
            this.experienceRepository = experienceRepository;
        }
        

    }
}
