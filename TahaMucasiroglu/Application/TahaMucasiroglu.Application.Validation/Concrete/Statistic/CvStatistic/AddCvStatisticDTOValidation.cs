using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base.Statistic;
using TahaMucasiroglu.Application.Validation.Concrete.Statistic.P2PMessageStatistic;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.CvStatistic;
using TahaMucasiroglu.Domain.DTOs.Concrete.Statistic.P2PMessageStatistic;

namespace TahaMucasiroglu.Application.Validation.Concrete.Statistic.CvStatistic
{
    public class AddCvStatisticListDTOValidation : AbstractValidator<IEnumerable<AddCvStatisticDTO>>
    {
        public AddCvStatisticListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new AddCvStatisticDTOValidation());
        }
    }
    public class AddCvStatisticDTOValidation : StatisticAddValidation<AddCvStatisticDTO>
    {
        public AddCvStatisticDTOValidation() : base()
        {
            // Zorunlu alanlar
            RuleFor(x => x.SessionId)
                .NotEmpty().WithMessage("SessionId boş olamaz.");

            RuleFor(x => x.ProcessType)
                .IsInEnum().WithMessage("Geçersiz ProcessType.");

            RuleFor(x => x.ProcessDate)
                .NotEmpty().WithMessage("ProcessDate girilmelidir.");

            // String alanları maksimum uzunluk ile kontrol ederek placeholder.
            RuleFor(x => x.IpAddress)
                .MaximumLength(45).WithMessage("IP adresi çok uzun.");

            RuleFor(x => x.UserAgent)
                .MaximumLength(512).WithMessage("UserAgent çok uzun.");

            RuleFor(x => x.Browser)
                .MaximumLength(100).WithMessage("Browser bilgisi çok uzun.");

            RuleFor(x => x.OperatingSystem)
                .MaximumLength(100).WithMessage("OperatingSystem bilgisi çok uzun.");

            RuleFor(x => x.DeviceType)
                .MaximumLength(50).WithMessage("DeviceType bilgisi çok uzun.");

            // Enlem/Boylam için geçerli aralık
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue)
                .WithMessage("Latitude -90 ila 90 arasında olmalıdır.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue)
                .WithMessage("Longitude -180 ila 180 arasında olmalıdır.");

            // Country / Region / City için opsiyonel ama boş string olmasın:
            RuleFor(x => x.Country)
                .MaximumLength(100).WithMessage("Country çok uzun.");

            RuleFor(x => x.Region)
                .MaximumLength(100).WithMessage("Region çok uzun.");

            RuleFor(x => x.City)
                .MaximumLength(100).WithMessage("City çok uzun.");

            // Koşullu: Geo bilgisi yoksa, en azından IP var olsun
            RuleFor(x => x.IpAddress)
                .NotEmpty()
                .When(x => !x.Latitude.HasValue || !x.Longitude.HasValue)
                .WithMessage("Enlem veya boylam yoksa IP adresi zorunludur.");

        }
    }
}
