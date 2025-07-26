using AutoMapper;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Response;
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Domain.Return.Abstract;
using TahaMucasiroglu.Domain.Return.Concrete;
using TahaMucasiroglu.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasiroglu.Service.CvDatabase.Abstract;

namespace TahaMucasiroglu.Service.CvDatabase.Concrete
{
    public class CvService : ICvService
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly IInfoRepository infoRepository;
        private readonly ISkillRepository skillRepository;
        private readonly ILogger<CvService> logger;
        private readonly IMapper mapper;

        public CvService
            (
                IInfoRepository infoRepository,
                ISkillRepository skillRepository,
                IExperienceRepository experienceRepository,
                ILogger<CvService> logger,
                IMapper mapper
            )
        {
            this.skillRepository = skillRepository;
            this.infoRepository = infoRepository;
            this.experienceRepository = experienceRepository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<IReturn<CvPageResponseDTO>> GetCV()
        {
            try
            {
                IReturn<Info> info = await infoRepository.GetLastAsync(e => !e.IsDeleted);
                IReturn<List<Skill>> skill = await skillRepository.GetAllWithIncludesAsync(null, e => e.SubSkills);
                IReturn<List<Experience>> experience = await experienceRepository.GetAllWithIncludesAsync(null, e => e.ExperienceType, e => e.ExperienceTechnologies);

                if (!info.Status || !skill.Status || !experience.Status)
                {
                    return new ErrorReturn<CvPageResponseDTO>("One or more database fetch operations failed.");
                }

                CvPageResponseDTO cvDto = new CvPageResponseDTO
                {
                    Info = mapper.Map<GetInfoDTO>(info.Data),
                    Skills = mapper.Map<List<GetSkillWithSubSkillsDTO>>(skill.Data),
                    Experiences = mapper.Map<List<GetExperienceWithTechnologyAndTypeDTO>>(experience.Data)
                };

                return new SuccessReturn<CvPageResponseDTO>(cvDto);



            }
            catch (Exception e)
            {
                logger.LogError(e, $"{nameof(CvService)} içinde {nameof(GetCV)} içinde hata var. hata mesajı = {e.Message}");
                return new ErrorReturn<CvPageResponseDTO>();
            }
        }



    }
}
