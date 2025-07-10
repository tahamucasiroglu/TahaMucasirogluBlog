using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Tag;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Tag
{
    public class DeleteTagDTOValidation : DeleteValidation<DeleteTagDTO>
    {
        public DeleteTagDTOValidation() : base()
        {
            
        }
    }
}
