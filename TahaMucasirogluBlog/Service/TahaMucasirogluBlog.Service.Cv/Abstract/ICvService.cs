using TahaMucasirogluBlog.Domain.DTOs.Concrete.Response;
using TahaMucasirogluBlog.Domain.Return.Abstract;

namespace TahaMucasirogluBlog.Service.Cv.Abstract
{
    public interface ICvService
    {
        public Task<IReturn<CvResponseDTO>> GetCV();
    }
}
