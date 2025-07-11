using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Request;

namespace TahaMucasirogluBlog.Presentation.API.Controllers.Abstract
{
    public interface IController
    {
        public IActionResult HealthCheck();
        public IActionResult HealthCheck([FromBody] HealthCheckRequestDTO model);
        public IActionResult GetAll([FromBody] IdRequest model);
        public Task<IActionResult> GetAllAsync([FromBody] IdRequest model);
        public IActionResult GetById([FromBody] IdRequest model);
        public Task<IActionResult> GetByIdAsync([FromBody] IdRequest model);
    }
    public interface IController<TAdd> : IController
        where TAdd : class, IAddDTO
    {
        public IActionResult Add([FromBody] TAdd survey);
        public Task<IActionResult> AddAsync([FromBody] TAdd survey);
    }
    public interface IController<TAdd, TUpdate> : IController<TAdd>
        where TAdd : class, IAddDTO
        where TUpdate : class, IUpdateDTO
    {
        public IActionResult Update([FromBody] TUpdate survey);
        public Task<IActionResult> UpdateAsync([FromBody] TUpdate survey);
    }
    public interface IController<TAdd, TUpdate, TDelete> : IController<TAdd, TUpdate>
        where TAdd : class, IAddDTO
        where TUpdate : class, IUpdateDTO
        where TDelete : class, IDeleteDTO
    {
        public IActionResult Delete([FromBody] TDelete survey);
        public Task<IActionResult> DeleteAsync([FromBody] TDelete survey);
    }

}
