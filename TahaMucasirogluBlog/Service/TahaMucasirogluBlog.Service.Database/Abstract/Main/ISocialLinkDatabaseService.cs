using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Main.SocialLink;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Main;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Main
{
    public interface ISocialLinkDatabaseService : IDatabaseService<SocialLink, GetSocialLinkDTO, AddSocialLinkDTO, UpdateSocialLinkDTO, DeleteSocialLinkDTO>
    {
    }
}
