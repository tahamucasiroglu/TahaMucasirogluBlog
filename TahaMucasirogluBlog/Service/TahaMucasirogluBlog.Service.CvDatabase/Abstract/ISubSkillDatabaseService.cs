using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.SubSkill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluCv.Service.CvDatabase.Abstract.Base;

namespace TahaMucasirogluBlog.Service.CvDatabase.Abstract
{
    public interface ISubSkillDatabaseService : ICvDatabaseService<SubSkill, GetSubSkillDTO, AddSubSkillDTO, UpdateSubSkillDTO, DeleteSubSkillDTO>
    {
    }
}
