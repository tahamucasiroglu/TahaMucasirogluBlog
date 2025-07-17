
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Response;
using TahaMucasirogluBlog.Domain.Return.Abstract;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface ICvService
    {
        public Task<IReturn<CvPageResponseDTO>> GetCV();
    }
}
