using System.Security.Cryptography;
using System.Text;

namespace TahaMucasirogluBlog.Client.P2PMessage.TahaMucasirogluMVC.Services
{
    public static class CryptoService
    {
        public static (string publicKey, string privateKey) GenerateKeyPair()
        {
            using var rsa = RSA.Create(2048);
            var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            return (publicKey, privateKey);
        }

        public static string Encrypt(string plainText, string publicKeyBase64)
        {
            using var rsa = RSA.Create();
            rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKeyBase64), out _);

            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var encryptedBytes = rsa.Encrypt(plainBytes, RSAEncryptionPadding.OaepSHA256);

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedTextBase64, string privateKeyBase64)
        {
            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKeyBase64), out _);

            var encryptedBytes = Convert.FromBase64String(encryptedTextBase64);
            var decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
