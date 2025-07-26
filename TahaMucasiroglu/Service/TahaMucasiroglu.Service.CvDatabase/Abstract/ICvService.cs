
using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Response;
using TahaMucasiroglu.Domain.Return.Abstract;

namespace TahaMucasiroglu.Service.CvDatabase.Abstract
{
    public interface ICvService
    {
        public Task<IReturn<CvPageResponseDTO>> GetCV();
    }
}
