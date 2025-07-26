using System.Security.Cryptography;
using TahaMucasiroglu.Domain.Constant;
using TahaMucasiroglu.Domain.Extensions;

namespace TahaMucasiroglu.Application.Managers.PasswordManager
{
    public class PasswordManager : IPasswordManager
    {
        internal readonly string Password;
        internal readonly string? Salt;
        internal readonly PasswordHashType HashType;
        internal readonly int SaltLength;

        public PasswordManager(
        string Password,
        string? Salt = null,
        PasswordHashType HashType = PasswordHashType.SHA512_HEX,
        bool GenerateRandomSalt = false,
        int SaltLength = 16)
        {
            this.Password = Password;
            this.Salt = GenerateRandomSalt ? GenerateSalt() : Salt;
            this.HashType = HashType;
            this.SaltLength = SaltLength;
        }

        public string GenerateSalt()
        {
            var saltBytes = new byte[SaltLength];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public string HashPassword()
        {
            string combined = string.IsNullOrWhiteSpace(Salt) ? Password : Password + Salt;
            return HashType switch
            {
                PasswordHashType.MD5_BASE64 => combined.ToMd5Base64(),
                PasswordHashType.MD5_HEX => combined.ToMd5Hex(),
                PasswordHashType.SHA1_BASE64 => combined.ToSha1Base64(),
                PasswordHashType.SHA1_HEX => combined.ToSha1Hex(),
                PasswordHashType.SHA256_BASE64 => combined.ToSha256Base64(),
                PasswordHashType.SHA256_HEX => combined.ToSha256Hex(),
                PasswordHashType.SHA384_BASE64 => combined.ToSha384Base64(),
                PasswordHashType.SHA384_HEX => combined.ToSha384Hex(),
                PasswordHashType.SHA512_BASE64 => combined.ToSha512Base64(),
                PasswordHashType.SHA512_HEX => combined.ToSha512Hex(),
                _ => throw new NotSupportedException("Unsupported hash type")
            };
        }

    }
}
