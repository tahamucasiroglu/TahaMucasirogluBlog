using TahaMucasiroglu.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasiroglu.Domain.Entities.Concrete.Cv;
using TahaMucasiroglu.Service.CvDatabase.Abstract.Base;

namespace TahaMucasiroglu.Service.CvDatabase.Abstract
{
    public interface ISubSkillDatabaseService : ICvDatabaseService<SubSkill, GetSubSkillDTO, AddSubSkillDTO, UpdateSubSkillDTO, DeleteSubSkillDTO>
    {
    }
}
