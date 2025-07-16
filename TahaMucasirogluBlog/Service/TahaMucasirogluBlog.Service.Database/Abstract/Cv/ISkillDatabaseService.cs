using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Cv.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete.Cv;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Base;
using TahaMucasirogluCv.Service.Database.Abstract.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract.Cv
{
    public interface ISkillDatabaseService : ICvDatabaseService<Skill, GetSkillDTO, AddSkillDTO,UpdateSkillDTO,DeleteSkillDTO>
    {
    }
}
