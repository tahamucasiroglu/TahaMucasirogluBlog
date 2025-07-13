using TahaMucasirogluBlog.Domain.Entities.Base;

namespace TahaMucasirogluBlog.Domain.Entities.Concrete
{
    public class Info : Entity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty; // Konum
        public string CoverLetter {  get; set; } = string.Empty;
    }
}
