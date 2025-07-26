using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahaMucasiroglu.Domain.DTOs.Abstract
{
    public interface IGetDTO : IDTO, IIdDTO
    {
        public bool IsDeleted { get; init; }
        public DateTime InsertedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public DateTime? DeletedAt { get; init; }
        public Guid InsertedBy { get; init; }
        public Guid? UpdatedBy { get; init; }
        public Guid? DeletedBy { get; init; }
    }
}
