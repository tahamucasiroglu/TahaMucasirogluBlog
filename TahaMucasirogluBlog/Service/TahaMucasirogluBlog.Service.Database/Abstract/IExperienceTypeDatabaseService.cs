using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract
{
    public interface IExperienceTypeDatabaseService : IDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>
    {
    }
}
