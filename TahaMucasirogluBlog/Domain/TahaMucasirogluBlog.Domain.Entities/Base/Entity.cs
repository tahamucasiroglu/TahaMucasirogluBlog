using TahaMucasirogluBlog.Domain.Entities.Abstract;

namespace TahaMucasirogluBlog.Domain.Entities.Base
{
    abstract public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid InsertedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
