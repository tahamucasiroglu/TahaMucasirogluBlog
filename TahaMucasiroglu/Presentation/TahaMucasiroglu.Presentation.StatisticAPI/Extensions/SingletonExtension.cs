namespace TahaMucasiroglu.Presentation.StatisticAPI.Extensions
{
    static public class SingletonExtension
    {
        public static void AddSingleton(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
