using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluCv.Service.CvDatabase.Abstract.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface ISkillDatabaseService : ICvDatabaseService<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO>
    {
    }
}
