using Microsoft.AspNetCore.Builder;
using System.Threading.RateLimiting;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Presentation.API.Extensions
{
    public static class RateLimiterExtension
    {
        static public void AddRateLimiter(this WebApplicationBuilder builder, string PolicyName = "IpPerSecond")
        {
            builder.Services.AddRateLimiter(options =>
            {
                options.AddPolicy(PolicyName, httpContext =>
                {
                    // Remote IP adresini al. Null ise fallback ver.
                    string ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

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
