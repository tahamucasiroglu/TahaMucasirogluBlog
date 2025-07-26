using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Client.MVC.Extensions
{
    public static class LoggerExtension
    {
        static public Serilog.ILogger AddLogger(this WebApplicationBuilder builder)
        {
            bool logStatus = builder.Configuration.GetAppSettingsValue<bool>("LoggerSettings:LogStatus");
            int logLevel = builder.Configuration.GetAppSettingsValue<int>("LoggerSettings:LogLevel");
            builder.Services.AddLogging();
            return builder.AddSeriLoggerToService(logLevel, logStatus);
        }

        static private Serilog.ILogger AddSeriLoggerToService(this WebApplicationBuilder builder, int logLevel, bool LOG_CONNECTION_STATUS)
        {
            if (LOG_CONNECTION_STATUS)
            {
                // Serilog yapılandırması
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Is((LogEventLevel)logLevel)
                    .WriteTo.Async(e => e.Console(theme: SystemConsoleTheme.Colored, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message:lj}{NewLine}{Exception}")) // Konsola loglama
                    .WriteTo.Async(e => e.File(
                        path: "../../Logs/TahaMucasirogluMvcLog-.txt", // Log dosyalarının bulunduğu klasör
                        rollingInterval: RollingInterval.Day, // Günlük loglama
                        rollOnFileSizeLimit: true,
                        fileSizeLimitBytes: 1L * 1024 * 1024 * 1024,//1GB
                        retainedFileCountLimit: 100, //100 adet 1 gb sonrası ne yapıyor bakmadım
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message:lj}{NewLine}{Exception}", // Log formatı
                        encoding: Encoding.UTF8
                    )) // Performans için asenkron dosya loglama
                    .CreateLogger();
                builder.Logging.ClearProviders();
                builder.Logging.AddSerilog(Log.Logger);
                // Serilog'u kullanması için Host yapılandırması
                builder.Host.UseSerilog();
                return Log.Logger;
            }
            else
            {
                return new LoggerConfiguration().MinimumLevel.Is(LogEventLevel.Fatal).CreateLogger(); //kapatılırsa en yüksek levele setleyip olabildiğince boş gönderiyorum tam kapatma nasıl bakmadım ama bunu ileride serilog kullanan kendi servisime çevirerek tam kontrol sağlamak istiyorum.
            }
        }
    }
}
