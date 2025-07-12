using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Mapper.Extensions.ConfigExtension;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete;

namespace TahaMucasirogluBlog.Application.Mapper.MapProfile.Entity
{
    public class InfoMapProfile : Profile
    {
        public InfoMapProfile()
        {
            CreateMap<AddInfoDTO, Info>().DefaultAddMapConfig();
            CreateMap<UpdateInfoDTO, Info>().DefaultUpdateMapConfig();
            CreateMap<DeleteInfoDTO, Info>().DefaultDeleteMapConfig();
            CreateMap<Info, GetInfoDTO>();
        }
    }
}
