using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Managers.UrlManager;
using TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Abstract.Base;
using TahaMucasirogluBlog.Domain.Return.Abstract;
using TahaMucasirogluBlog.Domain.Return.Base;
using TahaMucasirogluBlog.Domain.Return.Concrete;

namespace TahaMucasirogluBlog.Client.TahaMucasirogluMVC.Services.ApiConnectionService.Base
{
    public abstract class ApiConnectionService : IApiConnectionService
    {
        public string controllerName { get; }
        protected readonly IUrlManager urlManager;
        protected readonly HttpClient httpClient;
        protected readonly ILogger<ApiConnectionService> logger;

        public ApiConnectionService(
            string controllerName,
            IUrlManager urlManager,
            HttpClient httpClient,
            ILogger<ApiConnectionService> logger)
        {
            this.controllerName = controllerName;
            this.urlManager = urlManager;
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public string Build(string action) => urlManager.Build(controllerName, action);

        /// <summary>
        /// GET isteği atar ve <see cref="IReturn{T}"/> paketini deserialize eder.
        /// </summary>
        public async Task<IReturn<T>> GetAsync<T>(string action)
        {
            string requestUri = Build(action);
            using HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                logger.LogWarning("GET isteği yetkisiz: {RequestUri}", requestUri);
                throw new UnauthorizedAccessException("API returned 401 Unauthorized");
            }
            string json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Return<T>>(json);
            if (result == null)
            {
                logger.LogError("GET isteği sonucu deserialize edilemedi: {RequestUri}", requestUri);
                return new ErrorReturn<T>(message: "Gelen veri parçalanamadı.");
            }
            return result;
        }

        public async Task<IReturn<List<T>>> GetListAsync<T>(string action)
        {
            string requestUri = Build(action);

            using HttpResponseMessage response = await httpClient.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                logger.LogWarning("GET list isteği yetkisiz: {RequestUri}", requestUri);
                throw new UnauthorizedAccessException("API returned 401 Unauthorized");
            }

            string json = await response.Content.ReadAsStringAsync();

            // Deserialize to IReturn<List<T>>
            var result = JsonConvert.DeserializeObject<Return<List<T>>>(json);
            if (result == null)
            {
                logger.LogError("GET list isteği sonucu deserialize edilemedi: {RequestUri}", requestUri);
                return new ErrorReturn<List<T>>(message: "Gelen veri parçalanamadı.");
            }

            return result;
        }

        public async Task<IReturn<TResponse>> PostAsync<TResponse, TRequest>(string action, TRequest request)
        {
            string requestUri = Build(action);
            try
            {
                using HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                // JSON içeriği oluşturuluyor
                string json = JsonConvert.SerializeObject(request);
                using StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // POST isteği gönderiliyor
                HttpResponseMessage response = await client.PostAsync(requestUri, content);

                // Yetkisiz ise özel durum fırlat
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    logger.LogWarning("POST isteği yetkisiz: {RequestUri}", requestUri);
                    throw new UnauthorizedAccessException("API returned 401 Unauthorized");
                }

                // Başarılı ise JSON cevabı parse et
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    IReturn<TResponse>? responseData = JsonConvert.DeserializeObject<Return<TResponse>>(jsonString);
                    if (responseData == null)
                    {
                        logger.LogError("POST isteği sonucu deserialize edilemedi: {RequestUri}", requestUri);
                        return new ErrorReturn<TResponse>(message: "Gelen veri parçalanamadı.");
                    }
                    return responseData;
                }

                // Başarısız durum için loglama yap
                string errorContent = await response.Content.ReadAsStringAsync();
                logger.LogError("POST isteği başarısız: {RequestUri} - StatusCode: {StatusCode} - İçerik: {Content}", requestUri, response.StatusCode, errorContent);
                return new ErrorReturn<TResponse>(message: $"API isteği başarısız oldu. StatusCode: {response.StatusCode}");
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Api isteği 401 döndü", ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "POST isteği sırasında bir hata oluştu: {RequestUri}", requestUri);
                return new ErrorReturn<TResponse>(message: "API isteği sırasında bir hata oluştu.");
            }
        }

        public async Task<IReturn<TResponse>> PostAsync<TResponse, TRequest>(string action, IReturn<TRequest> request)

        {
            if (request.Status && request.Data != null)
            {
                TRequest req = request.Data;
                return await PostAsync<TResponse, TRequest>(action, req);
            }
            else
            {
                return new ErrorReturn<TResponse>(message: $"Post isteği veri başarısız olduğu için iptal edildi. {request.Message}");
            }
        }

    






    }
}
