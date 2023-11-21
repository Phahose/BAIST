using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;
namespace EncryptionLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Password");
            string password = Console.ReadLine();

            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
           string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt:salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount:100000,
               numBytesRequested: 256/8));
            Console.WriteLine($"Hashed: {hashed}");
        }
    }
}