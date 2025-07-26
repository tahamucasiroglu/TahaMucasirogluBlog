using TahaMucasiroglu.Domain.Constant;
using TahaMucasiroglu.Domain.DTOs.Bsae.Statistic;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic
{
    public record AddCvStatisticDTO : StatisticAddDTO
    {
        public Guid SessionId { get; init; }
        public CvSessionProcessType ProcessType { get; init; }
        public DateTime ProcessDate { get; init; }

        // Loglanabilir Alanlar
        public string? IpAddress { get; init; }
        public string? UserAgent { get; init; }
        public string? Browser { get; init; }
        public string? OperatingSystem { get; init; }
        public string? DeviceType { get; init; }

        public double? Latitude { get; init; }
        public double? Longitude { get; init; }
        public string? Country { get; init; }
        public string? Region { get; init; }
        public string? City { get; init; }
    }
}
