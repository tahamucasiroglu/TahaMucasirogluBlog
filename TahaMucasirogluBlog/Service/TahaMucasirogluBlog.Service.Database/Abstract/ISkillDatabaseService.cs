using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Skill;
using TahaMucasirogluBlog.Domain.Entities.Concrete;
using TahaMucasirogluBlog.Service.Database.Abstract.Base;
using TahaMucasirogluBlog.Service.Database.Base;

namespace TahaMucasirogluBlog.Service.Database.Abstract
{
    public interface ISkillDatabaseService : IDatabaseService<Skill, GetSkillDTO, AddSkillDTO,UpdateSkillDTO,DeleteSkillDTO>
    {
    }
}
