using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Constant;
using TahaMucasiroglu.Domain.DTOs.Bsae.Statistic;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic
{
    public record GetP2PMessageStatisticDTO : StatisticGetDTO
    {
        public Guid SessionId { get; init; }
        public P2PSessionProcessType ProcessType { get; init; }
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
