using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.DTOs.Base;

namespace TahaMucasiroglu.Domain.DTOs.Concrete.Main.SocialLink
{
    public record AddSocialLinkDTO : AddDTO
    {
        public string Name { get; init; } = string.Empty;
        public string Url { get; init; } = string.Empty;
        public string IconClass { get; init; } = string.Empty;
        public int DisplayOrder { get; init; } = 0;
        public bool IsVisible { get; init; } = true;
    }
}
