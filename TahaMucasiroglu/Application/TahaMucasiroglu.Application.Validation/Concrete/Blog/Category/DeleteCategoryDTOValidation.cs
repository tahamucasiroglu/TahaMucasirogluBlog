using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasiroglu.Application.Validation.Base;
using TahaMucasiroglu.Application.Validation.Base.Blog;
using TahaMucasiroglu.Domain.DTOs.Concrete.Blog.Category;

namespace TahaMucasiroglu.Application.Validation.Concrete.Blog.Category
{
    public class DeleteCategoryListDTOValidation : AbstractValidator<IEnumerable<DeleteCategoryDTO>>
    {
        public DeleteCategoryListDTOValidation()
        {
            RuleForEach(x => x).SetValidator(new DeleteCategoryDTOValidation());
        }
    }
    public class DeleteCategoryDTOValidation : BlogDeleteValidation<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidation() : base()
        {
            
        }
    }
}
