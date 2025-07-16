using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
{
    public class ExperienceTechnologyMapProfile : Profile
    {
        public ExperienceTechnologyMapProfile()
        {
            CreateMap<AddExperienceTechnologyDTO, ExperienceTechnology>().DefaultAddMapConfig();
            CreateMap<UpdateExperienceTechnologyDTO, ExperienceTechnology>().DefaultUpdateMapConfig();
            CreateMap<DeleteExperienceTechnologyDTO, ExperienceTechnology>().DefaultDeleteMapConfig();
            CreateMap<ExperienceTechnology, GetExperienceTechnologyDTO>();
        }
    }
}
