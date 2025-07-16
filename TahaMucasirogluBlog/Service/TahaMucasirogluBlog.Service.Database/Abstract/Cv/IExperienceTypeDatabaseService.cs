using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluCv.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Cv
{
    public interface IExperienceTypeDatabaseService : ICvDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>
    {
    }
}
