using Microsoft.Extensions.Logging;
using TahaMucasiroglu.Domain.Return.Abstract;

namespace TahaMucasiroglu.Application.Managers.LoggerManager
{
    public abstract class LoggerManager<T> : ILoggerManager<T>
    {
        public ILogger<T> logger { get; init; }

        public LoggerManager(ILogger<T> logger)
        {
            this.logger = logger;
        }

        public void LogInfo(string message) => logger.LogInformation(message);

        public void LogWarn(string message) => logger.LogWarning(message);

        public void LogDebug(string message) => logger.LogDebug(message);

        public void LogError(string message, Exception? ex = null)
        {
            if (ex != null)
                logger.LogError(ex, message);
            else
                logger.LogError(message);
        }

        public void LogReturn(IReturn @return)
        {
            //if (@return.Status) { LogInfo(@return.GetLog()); }
            //else { LogError(@return.GetLog(), @return.Exception); }
        }
    }
}
