using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Extensions;
using TahaMucasiroglu.Infrastructure.Repository.Context;

namespace TahaMucasiroglu.Presentation.API.Extensions
{
    static public class DatabaseExtension
    {
        static public void AddDatabase<T>(
           this WebApplicationBuilder builder,
           int logLevel,
           bool enableSensitiveDataLogging,
           bool enableDetailedErrors,
           string SqlServerConnectionStrings,
           Serilog.ILogger logger,
           QueryTrackingBehavior queryTrackingBehavior = QueryTrackingBehavior.NoTracking)
           where T : DbContext
        {
            builder.Services.AddDbContext<T>(opt =>
            {
                opt.UseSqlServer(SqlServerConnectionStrings);
                opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel((LogLevel)logLevel);
                }));
                opt.UseQueryTrackingBehavior(queryTrackingBehavior);
                opt.LogTo(message => logger.Information(message), LogLevel.Information);
                opt.EnableSensitiveDataLogging(enableSensitiveDataLogging);
                opt.EnableDetailedErrors(enableDetailedErrors);
            });
            logger.Information($"Genel Veritabanına Bağlanıldı.\nLoglevel = {(LogLevel)logLevel}\nEnableSensitiveDataLogging = {enableSensitiveDataLogging}\nEnableDetailedErrors = {enableDetailedErrors}");
        }
    }
}
