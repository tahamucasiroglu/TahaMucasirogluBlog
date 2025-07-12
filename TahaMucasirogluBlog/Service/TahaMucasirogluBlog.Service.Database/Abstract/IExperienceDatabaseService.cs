using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract
{
    public interface IExperienceDatabaseService : IDatabaseService<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>
    {
    }
}
