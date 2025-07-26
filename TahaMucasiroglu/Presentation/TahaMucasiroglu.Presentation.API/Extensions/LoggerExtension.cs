using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Text;

namespace TahaMucasiroglu.Presentation.API.Extensions
{
    static public class LoggerExtension
    {
        static public Serilog.ILogger AddSeriLoggerToService(
            this WebApplicationBuilder builder, 
            int logLevel, 
            bool logStatus,
            string path,// Log dosyalarının bulunduğu klasör
            string consoleOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message:lj}{NewLine}{Exception}",
            string fileOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message:lj}{NewLine}{Exception}",
            RollingInterval rollingInterval = RollingInterval.Day,// Günlük loglama
            bool rollOnFileSizeLimit = true,
            long fileSizeLimitBytes = 1L * 1024 * 1024 * 1024,  //1GB
            int retainedFileCountLimit = 100//100 adet 1 gb sonrası ne yapıyor bakmadım
            
            )
        {
            if (logStatus)
            {
                // Serilog yapılandırması
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Is((LogEventLevel)logLevel)
                    .WriteTo.Async(e => e.Console(theme: SystemConsoleTheme.Colored, outputTemplate: consoleOutputTemplate)) // Konsola loglama
                    .WriteTo.Async(e => e.File(
                        path: path, 
                        rollingInterval: rollingInterval, 
                        rollOnFileSizeLimit: rollOnFileSizeLimit,
                        fileSizeLimitBytes: fileSizeLimitBytes,
                        retainedFileCountLimit: retainedFileCountLimit, 
                        outputTemplate: fileOutputTemplate, // Log formatı
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
