using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class SocialLink : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
        public bool IsVisible { get; set; } = true;
    }
}
