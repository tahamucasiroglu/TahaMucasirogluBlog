using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.Models.Base;

namespace TahaMucasirogluBlog.Domain.Models.Concrete.Cv
{
    public class GetInfoModel : CvModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty; // Konum
        public string CoverLetter { get; set; } = string.Empty;
    }
}
