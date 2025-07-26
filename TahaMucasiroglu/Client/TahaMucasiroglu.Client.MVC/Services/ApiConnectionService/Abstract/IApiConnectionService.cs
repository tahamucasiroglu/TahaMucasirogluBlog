using TahaMucasiroglu.Domain.Return.Abstract;

namespace TahaMucasiroglu.Client.MVC.Services.ApiConnectionService.Abstract
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
