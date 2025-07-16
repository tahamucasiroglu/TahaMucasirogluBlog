using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluCv.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Cv
{
    public interface IExperienceDatabaseService : ICvDatabaseService<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>
    {
    }
}
