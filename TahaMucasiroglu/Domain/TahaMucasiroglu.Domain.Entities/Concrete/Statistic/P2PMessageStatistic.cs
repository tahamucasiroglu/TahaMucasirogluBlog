using TahaMucasiroglu.Domain.Constant;
using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Statistic
{
    public class P2PMessageStatistic : StatisticEntity
    {
        public Guid SessionId { get; set; }
        public P2PSessionProcessType ProcessType { get; set; }
        public DateTime ProcessDate { get; set; }

        // Loglanabilir Alanlar
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? Browser { get; set; }
        public string? OperatingSystem { get; set; }
        public string? DeviceType { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
    }
}
