using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract
{
    public interface IExperienceTechnologyDatabaseService : IDatabaseService<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>
    {
    }
}
