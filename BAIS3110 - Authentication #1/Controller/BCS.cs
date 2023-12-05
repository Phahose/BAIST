using BAIS3110___Authentication__1.Domain;
using BAIS3110___Authentication__1.Technical_Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
namespace BAIS3110___Authentication__1.Controller
{
    public class BCS
    {
        public void AddUser(User addeduser)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            byte[] hashedPassword = HashPasswordWithSalt (addeduser.Password, salt);

            // Convert the salt and hashed password to Base64 for storage
            string saltBase64 = Convert.ToBase64String(salt);
            string hashedPasswordBase64 = Convert.ToBase64String(hashedPassword);

            SecurityManager controll= new SecurityManager();
            addeduser.Password = hashedPasswordBase64;
            addeduser.Salt = saltBase64;
            Console.WriteLine(addeduser.Password);
            controll.AddUser(addeduser);
        }

        public User GetUser(string existingUseremail)
        {
            User user = new User();
            SecurityManager controll = new SecurityManager();
            user = controll.GetUser(existingUseremail);

            return user;
        }

        // Hash the Passwords
        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            // Hash the password with PBKDF2 using HMACSHA256
            return new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256).GetBytes(32);
        }
    }
}
