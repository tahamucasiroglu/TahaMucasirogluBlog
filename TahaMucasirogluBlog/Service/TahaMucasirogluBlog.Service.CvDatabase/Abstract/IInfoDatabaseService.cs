using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluCv.Service.CvDatabase.Abstract.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface IInfoDatabaseService : ICvDatabaseService<Info, GetInfoDTO, AddInfoDTO, UpdateInfoDTO, DeleteInfoDTO>
    {
    }
}
