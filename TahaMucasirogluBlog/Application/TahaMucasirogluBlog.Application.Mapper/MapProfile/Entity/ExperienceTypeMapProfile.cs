using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
{
    public class ExperienceTypeMapProfile : Profile
    {
        public ExperienceTypeMapProfile()
        {
            CreateMap<AddExperienceTypeDTO, ExperienceType>().DefaultAddMapConfig();
            CreateMap<UpdateExperienceTypeDTO, ExperienceType>().DefaultUpdateMapConfig();
            CreateMap<DeleteExperienceTypeDTO, ExperienceType>().DefaultDeleteMapConfig();
            CreateMap<ExperienceType, GetExperienceTypeDTO>();
        }
    }
}
