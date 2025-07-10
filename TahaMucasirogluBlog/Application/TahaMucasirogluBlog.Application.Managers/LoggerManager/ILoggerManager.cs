using Microsoft.Extensions.Logging;

namespace TahaMucasirogluBlog.Application.Managers.LoggerManager
{
    public interface ILoggerManager<T>
    {
        public ILogger<T> logger { get; init; }
        public void LogInfo(string message);
        public void LogWarn(string message);
        public void LogDebug(string message);
        public void LogError(string message, Exception? ex = null);
    }
}
