namespace TahaMucasirogluBlog.Domain.Extensions
{
    static public class IntegerExtension
    {
        static public string ToSha256Base64(this int num) => num.ToString().ToSha256Base64();
        static public string ToSha256Hex(this int num) => num.ToString().ToSha256Hex();
        static public string ToSha512Base64(this int num) => num.ToString().ToSha512Base64();
        static public string ToSha512Hex(this int num) => num.ToString().ToSha512Hex();
    }
}
