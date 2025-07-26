using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink;
using TahaMucasiroglu.Domain.Entities.Concrete.Main;
using TahaMucasiroglu.Service.Database.Abstract.Base;

namespace TahaMucasiroglu.Service.Database.Abstract
{
    public interface ISocialLinkDatabaseService : IDatabaseService<SocialLink, GetSocialLinkDTO, AddSocialLinkDTO, UpdateSocialLinkDTO, DeleteSocialLinkDTO>
    {
    }
}
