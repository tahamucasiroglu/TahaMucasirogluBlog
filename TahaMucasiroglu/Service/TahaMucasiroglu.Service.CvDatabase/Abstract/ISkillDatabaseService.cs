using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Service.CvDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Abstract
{
    public interface ISkillDatabaseService : ICvDatabaseService<Skill, GetSkillDTO, AddSkillDTO, UpdateSkillDTO, DeleteSkillDTO>
    {
    }
}
