﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Response;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Domain.Return.Abstract;
using TahaMucasirogluBlog.Domain.Return.Concrete;
using TahaMucasirogluBlog.Infrastructure.CvRepository.Repository.Abstract;
using TahaMucasirogluBlog.Service.CvDatabase.Abstract;

namespace TahaMucasirogluBlog.Service.CvDatabase.Concrete
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
