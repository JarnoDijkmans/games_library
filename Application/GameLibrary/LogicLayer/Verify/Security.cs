using System.Security.Cryptography;
using System.Text;

namespace LogicLayer.Verify
{
    public static class Security
    {
        private const int keySize = 64;
        private const int iterations = 350000;
        private readonly static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static (string Salt, string HashedPassword) CreateSaltAndHash(string password)
        {
            byte[] salt_bytes = RandomNumberGenerator.GetBytes(keySize);
            string salt = Convert.ToHexString(salt_bytes);
            string hashedPassword = CreateHash(salt, password);
            return (salt, hashedPassword);
        }

        public static string CreateHash(string salt, string password)
        {
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Convert.FromHexString(salt),
                iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }
    }
}