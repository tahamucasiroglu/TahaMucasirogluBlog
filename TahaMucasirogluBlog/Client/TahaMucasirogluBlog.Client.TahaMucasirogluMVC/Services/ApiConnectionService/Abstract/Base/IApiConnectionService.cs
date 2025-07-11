using TahaMucasirogluBlog.Domain.Return.Abstract;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract.Base
{
    public interface IApiConnectionService
    {
        public string controllerName { get; }
        public string Build(string action);
        public Task<IReturn<T>> GetAsync<T>(string action);
        public Task<IReturn<List<T>>> GetListAsync<T>(string action);
        public Task<IReturn<TResponse>> PostAsync<TResponse, TRequest>(string action, TRequest request);
        public Task<IReturn<TResponse>> PostAsync<TResponse, TRequest>(string action, IReturn<TRequest> request);

    }
}
