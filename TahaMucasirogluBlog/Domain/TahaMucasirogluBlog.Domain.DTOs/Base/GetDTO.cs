using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahaMucasirogluBlog.Domain.DTOs.Abstract;

namespace TahaMucasirogluBlog.Domain.DTOs.Base
{
    abstract public record GetDTO : IGetDTO
    {
        public Guid Id { get; init; }
        public Guid IslemYapanKullaniciId { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime InsertedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public DateTime? DeletedAt { get; init; }
        public Guid InsertedBy { get; init; }
        public Guid? UpdatedBy { get; init; }
        public Guid? DeletedBy { get; init; }
    }
}
