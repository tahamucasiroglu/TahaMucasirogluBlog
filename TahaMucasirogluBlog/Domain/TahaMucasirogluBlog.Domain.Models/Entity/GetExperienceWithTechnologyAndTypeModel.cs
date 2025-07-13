using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasirogluBlog.Domain.Models.Entity
{
    public class GetExperienceWithTechnologyAndTypeModel : Model
    {
        public string Title { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Reference { get; set; }
        public string? Url { get; set; }
        public string? ImageUrl { get; set; }

        public GetExperienceTypeModel ExperienceType { get; set; } = default!;
        public List<GetSubSkillModel> SubSkills { get; set; } = new();
    }
}
