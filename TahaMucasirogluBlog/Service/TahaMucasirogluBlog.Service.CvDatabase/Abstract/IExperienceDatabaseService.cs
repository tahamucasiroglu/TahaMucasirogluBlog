using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Experience;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluCv.Service.CvDatabase.Abstract.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface IExperienceDatabaseService : ICvDatabaseService<Experience, GetExperienceDTO, AddExperienceDTO, UpdateExperienceDTO, DeleteExperienceDTO>
    {
    }
}
