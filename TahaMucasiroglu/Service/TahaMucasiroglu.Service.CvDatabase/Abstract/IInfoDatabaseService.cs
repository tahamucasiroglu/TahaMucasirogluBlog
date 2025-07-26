using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Info;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Service.CvDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Abstract
{
    public interface IInfoDatabaseService : ICvDatabaseService<Info, GetInfoDTO, AddInfoDTO, UpdateInfoDTO, DeleteInfoDTO>
    {
    }
}
