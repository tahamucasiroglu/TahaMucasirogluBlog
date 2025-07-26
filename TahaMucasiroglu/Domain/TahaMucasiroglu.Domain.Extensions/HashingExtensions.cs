using System.Security.Cryptography;
using System.Text;

namespace TahaMucasiroglu.Domain.Extensions
{
    public static class HashingExtensions
    {
        public static string ToMd5Hex(this string input) => input.ToHashHex(MD5.Create());
        public static string ToMd5Base64(this string input) => input.ToHashBase64(MD5.Create());

        public static string ToSha1Hex(this string input) => input.ToHashHex(SHA1.Create());
        public static string ToSha1Base64(this string input) => input.ToHashBase64(SHA1.Create());

        public static string ToSha256Hex(this string input) => input.ToHashHex(SHA256.Create());
        public static string ToSha256Base64(this string input) => input.ToHashBase64(SHA256.Create());

        public static string ToSha384Hex(this string input) => input.ToHashHex(SHA384.Create());
        public static string ToSha384Base64(this string input) => input.ToHashBase64(SHA384.Create());

        public static string ToSha512Hex(this string input) => input.ToHashHex(SHA512.Create());
        public static string ToSha512Base64(this string input) => input.ToHashBase64(SHA512.Create());

        private static string ToHashHex(this string input, HashAlgorithm algorithm)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }
            using (algorithm)
            {
                byte[] hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        private static string ToHashBase64(this string input, HashAlgorithm algorithm)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }
            using (algorithm)
            {
                byte[] hashBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
