using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;
using TahaMucasirogluBlog.Domain.Extensions;

namespace TahaMucasirogluBlog.Presentation.API.Extensions
{
    static public class LoggerExtension
    {
        static public Serilog.ILogger AddLogger(this WebApplicationBuilder builder, bool LOG_CONNECTION_STATUS)
        {
            int logLevel = builder.Configuration.GetLogLevelAppSettings();

            builder.Services.AddLogging();
            return builder.AddSeriLoggerToService(logLevel, LOG_CONNECTION_STATUS);

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
                        path: "../../Logs/ApiLog-.txt", // Log dosyalarının bulunduğu klasör
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
