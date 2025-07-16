using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluCv.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Cv
{
    public interface IExperienceTechnologyDatabaseService : ICvDatabaseService<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>
    {
    }
}
