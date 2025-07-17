using Microsoft.EntityFrameworkCore;
using TahaMucasirogluBlog.Domain.Extensions;
using TahaMucasirogluBlog.Infrastructure.Repository.Context;

namespace TahaMucasirogluBlog.Presentation.SharedAPI.Extensions
{
    static public class DatabaseExtension
    {
        static public void AddDatabases(this WebApplicationBuilder builder, Serilog.ILogger logger)
        {
            builder.AddDatabase(logger);
        }

        static public void AddDatabase(this WebApplicationBuilder builder, Serilog.ILogger logger)
        {
            int logLevel = builder.Configuration.GetAppSettingsValue<int>("DatabaseSettings:DatabaseLogLevel");
            bool enableSensitiveDataLogging = builder.Configuration.GetAppSettingsValue<bool>("DatabaseSettings:EnableSensitiveDataLogging");
            bool enableDetailedErrors = builder.Configuration.GetAppSettingsValue<bool>("DatabaseSettings:EnableDetailedErrors");
            string SqlServerConnectionStrings = builder.Configuration.GetConnectionString("SqlServerConnectionStrings") ?? throw new Exception("Connection String Bulunamadı");
            builder.Services.AddDbContext<MainTahaMucasirogluContext>(opt =>
            {
                opt.UseSqlServer(SqlServerConnectionStrings);
                opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel((LogLevel)logLevel);
                }));
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.LogTo(message => logger.Information(message), LogLevel.Information);
                opt.EnableSensitiveDataLogging(enableSensitiveDataLogging);
                opt.EnableDetailedErrors(enableDetailedErrors);
            });
            logger.Information($"Genel Veritabanına Bağlanıldı.\nLoglevel = {(LogLevel)logLevel}\nEnableSensitiveDataLogging = {enableSensitiveDataLogging}\nEnableDetailedErrors = {enableDetailedErrors}");
        }
    }
}
