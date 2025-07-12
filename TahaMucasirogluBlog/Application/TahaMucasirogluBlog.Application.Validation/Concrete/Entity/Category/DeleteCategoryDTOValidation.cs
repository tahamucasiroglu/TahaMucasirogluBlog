using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Application.Validation.Base;
using TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Category;

namespace TahaMucasirogluBlog.Application.Validation.Concrete.Entity.Category
{
    public class DeleteCategoryListDTOValidation : AbstractValidator<IEnumerable<DeleteCategoryDTO>>
    {
        public DeleteCategoryListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteCategoryDTOValidation());
        }
    }
    public class DeleteCategoryDTOValidation : DeleteValidation<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidation() : base()
        {
            
        }
    }
}
