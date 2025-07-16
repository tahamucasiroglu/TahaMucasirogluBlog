using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Models.Base;

namespace TahaMucasirogluBlog.Domain.Models.Concrete.Cv
{
    public class GetExperienceTypeModel : CvModel
    {
        public string Name { get; set; } = string.Empty;
    }
}
