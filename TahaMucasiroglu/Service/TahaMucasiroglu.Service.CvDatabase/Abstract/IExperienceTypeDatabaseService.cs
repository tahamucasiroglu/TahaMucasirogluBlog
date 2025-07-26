using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Service.CvDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Abstract
{
    public interface IExperienceTypeDatabaseService : ICvDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>
    {
    }
}
