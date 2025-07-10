using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Base;

namespace TahaMucasirogluBlog.Domain.DTOs.Concrete.Entity.Category
{
    public record AddCategoryDTO : AddDTO
    {
        public Guid? ParentCategoryId { get; init; }
        public string Name { get; init; } = null!;
        public string Slug { get; init; } = null!;
    }
}
