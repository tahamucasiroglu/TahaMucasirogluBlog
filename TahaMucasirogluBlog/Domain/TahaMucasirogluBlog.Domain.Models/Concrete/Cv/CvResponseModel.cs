using TahaMucasirogluBlog.Domain.Models.Base;

namespace TahaMucasirogluBlog.Domain.Models.Concrete.Cv
{
    public class CvResponseModel : CvModel
    {
        public GetInfoModel Info { get; set; } = default!;
        public List<GetSocialLinkModel> SocialLinks { get; set; } = new();
        public List<GetSkillWithSubSkillsModel> Skills { get; set; } = new();
        public List<GetExperienceWithTechnologyAndTypeModel> Experiences { get; set; } = new();
    }
}
