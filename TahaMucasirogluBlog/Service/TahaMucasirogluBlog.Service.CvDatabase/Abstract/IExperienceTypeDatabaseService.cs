using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceType;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluCv.Service.CvDatabase.Abstract.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface IExperienceTypeDatabaseService : ICvDatabaseService<ExperienceType, GetExperienceTypeDTO, AddExperienceTypeDTO, UpdateExperienceTypeDTO, DeleteExperienceTypeDTO>
    {
    }
}
