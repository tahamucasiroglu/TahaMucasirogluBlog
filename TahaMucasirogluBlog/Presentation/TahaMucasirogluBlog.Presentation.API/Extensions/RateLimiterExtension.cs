using System.Threading.RateLimiting;
using TahaMucasirogluBlog.Domain.Extensions;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    public static class RateLimiterExtension
    {
        static public void AddRateLimiter(this WebApplicationBuilder builder)
        {
            builder.Services.AddRateLimiter(options =>
            {
                options.AddPolicy("IpPerSecond", httpContext =>
                {
                    // Remote IP adresini al. Null ise fallback ver.
                    var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                    // Partition key olarak IP'yi kullan.
                    return RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: ip,
                        factory: key => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = builder.Configuration.GetIpRateLimitFromSecondAppSettings(), // Saniyede 10 istek
                            Window = TimeSpan.FromSeconds(1),
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0 // Kuyruğa alma, direk 429 dön
                        });
                });
            });
        }
    }
}
