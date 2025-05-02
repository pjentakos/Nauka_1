using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite_TEST.ApplicationController
{
    internal static class Password
    {
        // TODO: Przepisałem z netu. Wypadałoby się nauczyć:

        public static (string hash, string salt) HashPassword(string password)
        {
            // Generujemy losowy salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            // Hashujemy hasło + salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32); // 256-bit hash

            // Zamieniamy na stringi (Base64), żeby zapisać w bazie
            string hash = Convert.ToBase64String(hashBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return (hash, salt);
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100000, HashAlgorithmName.SHA256);
            byte[] hashBytes = pbkdf2.GetBytes(32);
            string computedHash = Convert.ToBase64String(hashBytes);

            return computedHash == storedHash;
        }
    }
}
