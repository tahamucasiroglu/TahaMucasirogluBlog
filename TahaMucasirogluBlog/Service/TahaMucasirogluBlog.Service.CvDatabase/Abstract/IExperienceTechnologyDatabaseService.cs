using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.ExperienceTechnology;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluCv.Service.CvDatabase.Abstract.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface IExperienceTechnologyDatabaseService : ICvDatabaseService<ExperienceTechnology, GetExperienceTechnologyDTO, AddExperienceTechnologyDTO, UpdateExperienceTechnologyDTO, DeleteExperienceTechnologyDTO>
    {
    }
}
