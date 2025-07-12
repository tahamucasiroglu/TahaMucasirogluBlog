using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Comment;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
{
    public class ExperienceMapProfile : Profile
    {
        public ExperienceMapProfile()
        {
            CreateMap<AddExperienceDTO, Experience>().DefaultAddMapConfig();
            CreateMap<UpdateExperienceDTO, Experience>().DefaultUpdateMapConfig();
            CreateMap<DeleteExperienceDTO, Experience>().DefaultDeleteMapConfig();
            CreateMap<Experience, GetExperienceDTO>();
        }
    }
}
