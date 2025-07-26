
using TahaMucasiroglu.Domain.DTOs.Abstract.Cv;
using TahaMucasiroglu.Presentation.API.Controllers.Abstract;

namespace TahaMucasiroglu.Presentation.CvAPI.Controllers.Abstract
{
    public interface ICvController<TAdd, TUpdate, TDelete> : IController<TAdd, TUpdate, TDelete>
        where TAdd : class, ICvAddDTO
        where TUpdate : class, ICvUpdateDTO
        where TDelete : class, ICvDeleteDTO
    {
    }
}
