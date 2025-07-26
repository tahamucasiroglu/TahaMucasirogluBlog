using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Domain.Entities.Base;

namespace TahaMucasiroglu.Domain.Entities.Concrete.Main
{
    public class SocialLink : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty;
        public int DisplayOrder { get; set; } = 0;
        public bool IsVisible { get; set; } = true;
        public bool Cv {  get; set; }
        public bool Blog { get; set; }
    }
}
