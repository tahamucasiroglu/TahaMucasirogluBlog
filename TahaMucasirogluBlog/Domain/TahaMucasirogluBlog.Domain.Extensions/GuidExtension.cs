namespace TahaMucasirogluBlog.Domain.Extensions
{
    static public class GuidExtension
    {
        static public Guid ZeroGuid(this Guid value) => Guid.Parse("00000000-0000-0000-0000-000000000000");
        static public Guid OneGuid(this Guid value) => Guid.Parse("11111111-1111-1111-1111-111111111111");
    }
}
