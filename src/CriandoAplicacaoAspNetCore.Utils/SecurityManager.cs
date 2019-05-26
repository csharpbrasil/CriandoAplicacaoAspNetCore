using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CriandoAplicacaoAspNetCore.Utils
{
    public class SecurityManager
    {
        private const int ITERATION_COUNT = 10000;

        public static string CreateSalt()
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[128 / 8];
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public static string CreateHash(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(password: value, salt: Encoding.UTF8.GetBytes(salt),
                                                  prf: KeyDerivationPrf.HMACSHA512, iterationCount: ITERATION_COUNT,
                                                  numBytesRequested: 256 / 8);
            return Convert.ToBase64String(valueBytes);
        }

        public static bool Validate(string value, string salt, string hash)
            => CreateHash(value, salt) == hash;
    }
}
