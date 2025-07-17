using Microsoft.AspNetCore.Mvc;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Request;
using TahaMucasirogluBlog.Domain.Entities.Abstract;
using TahaMucasirogluBlog.Presentation.SharedAPI.Attributes;
using TahaMucasirogluBlog.Presentation.SharedAPI.Controllers.Abstract;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Controllers.Base
{
    abstract public class Controller<TEntity, TResponse> : ControllerBase, IController
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
    {
        internal readonly IDatabaseService<TEntity, TResponse> service;
        public Controller(IDatabaseService<TEntity, TResponse> service)
        {
            this.service = service;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public IActionResult GetAll([FromBody] IdRequestDTO model)
        {
            return new OkObjectResult(service.GetAll(model));
        }
        [HttpGet("[action]Async")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetAllAsync([FromBody] IdRequestDTO model)
        {
            return new OkObjectResult(await service.GetAllAsync(model));
        }
        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public IActionResult GetById([FromBody] IdRequestDTO model)
        {
            return new OkObjectResult(service.GetById(model));
        }
        [HttpGet("[action]Async")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public async Task<IActionResult> GetByIdAsync([FromBody] IdRequestDTO model)
        {
            return new OkObjectResult(await service.GetByIdAsync(model));
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public IActionResult HealthCheck()
        {
            return Ok("Sistem Çalışırıyor");
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public IActionResult HealthCheck([FromBody] HealthCheckRequestDTO model)
        {
            return Ok($"Sistem çalışıyor. İşlem Sonucu {model.Num1} + {model.Num2} = {model.Num1 + model.Num2}");
        }
    }



    abstract public class Controller<TEntity, TResponse, TAddRequest> : Controller<TEntity, TResponse>
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
    {
        internal new readonly IDatabaseService<TEntity, TResponse, TAddRequest> service;
        public Controller(IDatabaseService<TEntity, TResponse, TAddRequest> service) : base(service)
        {
            this.service = service;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public virtual IActionResult Add([FromBody] TAddRequest model)
        {
            return new OkObjectResult(service.Add(model));
        }
        [HttpPost("[action]Async")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public virtual async Task<IActionResult> AddAsync([FromBody] TAddRequest model)
        {
            return new OkObjectResult(await service.AddAsync(model));
        }
    }


    abstract public class Controller<TEntity, TResponse, TAddRequest, TUpdateRequest> : Controller<TEntity, TResponse, TAddRequest>
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
        where TUpdateRequest : class, IUpdateDTO
    {
        internal new readonly IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest> service;
        public Controller(IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest> service) : base(service)
        {
            this.service = service;
        }


        [HttpPost("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public virtual IActionResult Update([FromBody] TUpdateRequest model)
        {
            return new OkObjectResult(service.Update(model));
        }
        [HttpPost("[action]Async")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TUpdateRequest model)
        {
            return new OkObjectResult(await service.UpdateAsync(model));
        }
    }

    abstract public class Controller<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> : Controller<TEntity, TResponse, TAddRequest, TUpdateRequest>
        where TEntity : class, IEntity
        where TResponse : class, IGetDTO
        where TAddRequest : class, IAddDTO
        where TUpdateRequest : class, IUpdateDTO
        where TDeleteRequest : class, IDeleteDTO
    {
        internal new readonly IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> service;
        public Controller(IDatabaseService<TEntity, TResponse, TAddRequest, TUpdateRequest, TDeleteRequest> service) : base(service)
        {
            this.service = service;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public virtual IActionResult Delete([FromBody] TDeleteRequest model)
        {
            return new OkObjectResult(service.Delete(model));
        }
        [HttpPost("[action]Async")]
        [ServiceFilter(typeof(LogConnectionAttribute))]
        public virtual async Task<IActionResult> DeleteAsync([FromBody] TDeleteRequest model)
        {
            return new OkObjectResult(await service.DeleteAsync(model));
        }
    }
}
