using TahaMucasirogluBlog.Domain.Models.Entity;

namespace TahaMucasirogluBlog.Domain.Models.Response
{
    public class CvResponseModel : Model
    {
        public GetInfoModel Info { get; set; } = default!;
        public List<GetSocialLinkModel> SocialLinks { get; set; } = new();
        public List<GetSkillWithSubSkillsModel> Skills { get; set; } = new();
        public List<GetExperienceWithTechnologyAndTypeModel> Experiences { get; set; } = new();
    }
}
