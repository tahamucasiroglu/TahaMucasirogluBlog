using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Constant;
using TahaMucasiroglu.Domain.Models.Base;

namespace TahaMucasiroglu.Domain.Models.Concrete.Cv
{
    public class CvStatisticAddRequest : CvModel
    {
        public Guid SessionId { get; set; }
        public CvSessionProcessType ProcessType { get; set; }
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
